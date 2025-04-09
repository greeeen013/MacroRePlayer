﻿using Gma.System.MouseKeyHook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Formatting = Newtonsoft.Json.Formatting;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Text;
using Microsoft.Win32; // kvuli thread sleepu

namespace MacroRePlayer
{
    public partial class RePlayerForm : Form
    {
        private List<IInputEvent> events = new List<IInputEvent>();
        private DateTime lastEventTime; // Poslední zaznamenaný čas události
        private bool isRecording; // Indikátor nahrávání
        private IKeyboardMouseEvents globalHook; // Globální hook pro sledování vstupů
        private HashSet<string> pressedKeys = new HashSet<string>(); // Sledování stisknutých kláves
        private readonly string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer"); // Cesta k adresáři pro ukládání souborů

        //kvuli zavolání funkce pro ziskání konkrétní hardware klávesy
        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        const uint MAPVK_VK_TO_VSC = 0;

        public RePlayerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JsonFileSelectorForm.Text = $"MacroRecord{DateTime.Now:HH-mm_dd.MM.yyyy}"; // nastavení výchozího názvu souboru do textového pole s datem a časem pro ukládání makra 

            this.PlayerStartStopPlayingKeybindTextBox.AutoSize = false;
            this.PlayerStartStopPlayingKeybindTextBox.Size = new System.Drawing.Size(85, 43); // nastavení velikosti textového pole pro klávesovou zkratku na keybind pro spouštění/zastavení přehrávání

            this.PlayerPlaybackMethodComboBox.SelectedIndex = 0; // nastavení výchozího indexu na 0 (první položka v ComboBoxu což je one time play)

            this.PlayerPlaybackSpeedComboBox.SelectedIndex = 3; // nastavení výchozího indexu na 3 (čtvrtá položka v ComboBoxu což je 1x speed)

            CheckAndCreateSettingsFile(); // kontrola a vytvoření konfiguračního souboru, pokud neexistuje a rovnou načte hodnoty

        } // tento event se spouští při načtení formuláře a předepíše výchozí název souboru (což je dnešní datum a čas) pro ukládání makra

        private void CheckAndCreateSettingsFile()
        {
            string settingsFilePath = Path.Combine(directoryPath, "settings.cfg"); // vytvoření cesty k souboru s nastavením

            if (!File.Exists(settingsFilePath)) // pokud soubor neexistuje
            {
                using (StreamWriter sw = File.CreateText(settingsFilePath)) // vytvoření nového souboru
                {
                    sw.WriteLine("[Settings]");
                    sw.WriteLine("autosave = true");
                    sw.WriteLine("theme = \"white\"");
                    sw.WriteLine("default_speed = 1");
                    sw.WriteLine("startup_delay = 1000");
                    sw.WriteLine("hotkey_record = \"\"");
                    sw.WriteLine("hotkey_play = \"\"");
                } // s výchozími hodnotami nastavení
            }

            LoadSettings(); // zavolá funkci pro načtení hodnot ze souboru
        }

        private void LoadSettings()
        {
            string settingsFilePath = Path.Combine(directoryPath, "settings.cfg"); // vytvoření cesty k souboru s nastavením

            if (File.Exists(settingsFilePath)) // pokud soubor existuje
            {
                var settings = File.ReadAllLines(settingsFilePath) // načtení všech řádků ze souboru
                                   .Skip(1) // přeskakujeme první řádek, který je nadpis
                                   .Select(line => line.Split(new[] { '=' }, 2)) // rozdělení řádku na klíč a hodnotu
                                   .ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim().Trim('"')); // vytvoření slovníku s klíči a hodnotami

                
                //autosaveCheckBox.Checked = bool.Parse(settings["autosave"]);
                //themeComboBox.SelectedItem = settings["theme"];
                //defaultSpeedTextBox.Text = settings["default_speed"];
                //startupDelayTextBox.Text = settings["startup_delay"];
                //hotkeyRecordTextBox.Text = settings["hotkey_record"];
                //hotkeyPlayTextBox.Text = settings["hotkey_play"];
            }
        }

        private void StartRecording_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(directoryPath); // vytvoření složky pro ukládání souborů, pokud neexistuje

            events.Clear(); // vyčistí seznam událostí
            isRecording = true; // nastaví nahrávání na true
            lastEventTime = DateTime.Now; // nastaví poslední čas události na aktuální čas
            ToggleRecordingButtons(true); // přepíná povolení tlačítek pro nahrávání a zastavení nahrávání

            globalHook = Hook.GlobalEvents(); // inicializace globálního hooku pro sledování vstupů
            globalHook.MouseDownExt += GlobalHook_MouseDownExt; // přidání event handleru pro stisknutí myši
            globalHook.MouseUpExt += GlobalHook_MouseUpExt; // přidání event handleru pro uvolnění myši
            globalHook.KeyDown += GlobalHook_KeyDown; // přidání event handleru pro stisknutí klávesy
            globalHook.KeyUp += GlobalHook_KeyUp; // přidání event handleru pro uvolnění klávesy
        } // tento event se spouští při kliknutí na tlačítko "Start Recording" a inicializuje nahrávání událostí

        private void StopRecording_Click(object sender, EventArgs e)
        {
            isRecording = false; // nastavuje nahrávání na false
            ToggleRecordingButtons(false); // přepíná povolení tlačítek pro nahrávání a zastavení nahrávání
            UnsubscribeGlobalHook(); // odhlášení event handlerů
            SaveEventsToJson(); // uložení událostí do JSON souboru
        } // tento event se spouští při kliknutí na tlačítko "Stop Recording" a ukončuje nahrávání událostí a uložení do souboru

        private void ToggleRecordingButtons(bool recording)
        {
            StopRecording.Enabled = recording; // povolení nebo zakázání tlačítka pro zastavení nahrávání
            StartRecording.Enabled = !recording; // povolení nebo zakázání tlačítka pro zahájení nahrávání
        } // přepíná povolení tlačítek pro nahrávání a zastavení nahrávání

        private void UnsubscribeGlobalHook()
        {
            if (globalHook != null) // pokud je globální hook inicializován
            {
                globalHook.MouseDownExt -= GlobalHook_MouseDownExt; // odhlášení event handleru pro stisknutí myši
                globalHook.MouseUpExt -= GlobalHook_MouseUpExt; // odhlášení event handleru pro uvolnění myši
                globalHook.KeyDown -= GlobalHook_KeyDown; // odhlášení event handleru pro stisknutí klávesy
                globalHook.KeyUp -= GlobalHook_KeyUp; // odhlášení event handleru pro uvolnění klávesy
                globalHook.Dispose(); // uvolnění prostředků globálního hooku
            }
        } // tento event se spouští při ukončení nahrávání a odpojuje všechny event handlery pro sledování vstupů

        private void SaveEventsToJson()
        {
            string fileName = Path.Combine(directoryPath, JsonFileSelectorForm.Text + ".json"); // vytvoření cesty k souboru s koncovkou .json
            File.WriteAllText(fileName, JsonConvert.SerializeObject(events, Formatting.Indented)); // uložení událostí do JSON souboru
            MessageBox.Show($"Soubor {fileName} byl úspěšně vytvořen."); // informace o úspěšném vytvoření souboru
        } // tento event se spouští při uložení událostí do JSON souboru a informuje uživatele o úspěšném vytvoření souboru

        private void GlobalHook_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            if (isRecording) // pokud je nahrávání povoleno
            {
                AddDelayEvent(); // přidání zpoždění mezi událostmi
                events.Add(new MouseDownEvent { X = e.X, Y = e.Y, Button = e.Button.ToString() }); // zaznamenání události stisknutí myši
                lastEventTime = DateTime.Now; // aktualizace posledního času události
            }
        } // tento event se spouští při stisknutí myši a zaznamenává událost do seznamu událostí

        private void GlobalHook_MouseUpExt(object sender, MouseEventExtArgs e)
        {
            if (isRecording) // pokud je nahrávání povoleno
            {
                AddDelayEvent(); // přidání zpoždění mezi událostmi
                events.Add(new MouseUpEvent { X = e.X, Y = e.Y, Button = e.Button.ToString() }); // zaznamenání události uvolnění myši
                lastEventTime = DateTime.Now; // aktualizace posledního času události
            }
        } // tento event se spouští při uvolnění myši a zaznamenává událost do seznamu událostí

        private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (isRecording && pressedKeys.Add(e.KeyCode.ToString()))
            {
                AddDelayEvent();

                uint scancode = MapVirtualKey((uint)e.KeyCode, MAPVK_VK_TO_VSC);

                events.Add(new KeyDownEvent
                {
                    Key = e.KeyCode.ToString(),
                    Code = $"0x{scancode:X}" // např. "0x1E"
                });

                lastEventTime = DateTime.Now;
            }
        }
        // tento event se spouští při stisknutí klávesy a zaznamenává událost do seznamu událostí

        private void GlobalHook_KeyUp(object sender, KeyEventArgs e)
        {
            if (isRecording)
            {
                AddDelayEvent(); // přidání zpoždění mezi událostmi

                uint scancode = MapVirtualKey((uint)e.KeyCode, MAPVK_VK_TO_VSC); // získání skenovacího kódu klávesy

                events.Add(new KeyUpEvent // zaznamenání události uvolnění klávesy
                {
                    Key = e.KeyCode.ToString(), // název klávesy
                    Code = $"0x{scancode:X}" // skenovací kód ve formátu hexadecimálního čísla
                });

                lastEventTime = DateTime.Now;
                pressedKeys.Remove(e.KeyCode.ToString());
            }
        } // tento event se spouští při uvolnění klávesy a zaznamenává událost do seznamu událostí

        private void AddDelayEvent()
        {
            int delay = (int)(DateTime.Now - lastEventTime).TotalMilliseconds; // výpočet zpoždění mezi událostmi
            if (delay > 0) // přidání zpoždění pouze pokud je větší než 0 (což asi ani není možné, ale pro jistotu)
            {
                events.Add(new DelayEvent { Duration = delay }); // přidání události zpoždění do seznamu událostí
            }
        } // tento event se spouští vždy mezi událostmi a zaznamenává událost do seznamu událostí

        private void FolderOpenerButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(directoryPath)) // ověření existence složky
            {
                System.Diagnostics.Process.Start("explorer.exe", directoryPath); // otevření složky v Průzkumníku
            }
            else
            {
                MessageBox.Show("Složka neexistuje."); // zobrazí chybovou hlášku, pokud složka neexistuje
            }
        } // tento event se spouští při kliknutí na tlačítko pro otevření složky a otevírá složku s makry v Průzkumníku nebo zobrazuje chybovou hlášku, pokud složka neexistuje

        private void OpenEditor_Click(object sender, EventArgs e)
        {
            EditorForm editorForm = new EditorForm(); // vytvoření instance editoru
            editorForm.Show(); // zobrazení editoru
            this.Enabled = false; // zakáže hlavní formulář
            editorForm.FormClosed += (s, args) => this.Enabled = true; // po zavření editoru opět povolí hlavní formulář
        }  // tento event se spouští při kliknutí na tlačítko pro otevření editoru a zobrazuje editor pro úpravu makra

        private void FolderDeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Opravdu chcete smazat složku s makry?", "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); // zobrazí dialogové okno pro potvrzení smazání složky
            if (result == DialogResult.Yes) // pokud uživatel potvrdí smazání
            {
                if (Directory.Exists(directoryPath)) // a pokud složka existuje
                {
                    Directory.Delete(directoryPath, true); // tak smaže složku a všechny její podadresáře a soubory
                    MessageBox.Show("Složka byla úspěšně smazána."); // informuje uživatele o úspěšném smazání složky
                }
                else
                {
                    MessageBox.Show("Složka neexistuje."); // pokud složka neexistuje, zobrazí chybovou hlášku
                }
            }
        } // tento event se spouští při kliknutí na tlačítko pro smazání složky a zobrazuje dialogové okno pro potvrzení smazání složky a pokud uživatel potvrdí, smaže složku a všechny její podadresáře a soubory

        private void PlayerComboBox_DropDown(object sender, EventArgs e)
        {
            PlayerComboBox.Items.Clear(); // vyčistí položky ComboBoxu
            if (Directory.Exists(directoryPath)) // ověří existenci složky
            {
                var files = Directory.GetFiles(directoryPath, "*.json"); // získá všechny .json soubory ve složce
                foreach (var file in files)
                {
                    PlayerComboBox.Items.Add(Path.GetFileName(file)); // přidá název souboru do ComboBoxu
                }
            }
        } // tento event se spouští při rozbalení Player ComboBoxu a načítá všechny .json soubory ze složky do ComboBoxu

        private void PlayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayerComboBox.SelectedItem != null) // pokud je vybrán nějaký soubor
            {
                PlayerStartPlayingMacroButton.Enabled = true; // povolí tlačítko pro spuštění makra
            }
            else
            {
                PlayerStartPlayingMacroButton.Enabled = false; // zakáže tlačítko pro spuštění makra
            }
        } // tento event se spouští při změně výběru v Player ComboBoxu a povolí nebo zakáže tlačítko pro spuštění makra podle toho, zda je vybrán nějaký soubor

        private bool isPlayingMacro = false; // Flag to track if macro is playing

        private async void PlayerStartPlayingMacroButton_Click(object sender, EventArgs e)
        {
            if (PlayerComboBox.SelectedItem == null) return; // pokud není vybrán žádný soubor, nic se nestane (ošetření)

            string fileName = Path.Combine(directoryPath, PlayerComboBox.SelectedItem.ToString()); // vytvoření cesty k souboru
            if (!File.Exists(fileName)) return; // pokud soubor neexistuje, nic se nestane (ošetření)

            var settings = new JsonSerializerSettings(); // vytvoření nastavení pro JSON serializaci
            settings.Converters.Add(new InputEventConverter()); // přidání konvertoru pro události
            var events = JsonConvert.DeserializeObject<List<IInputEvent>>(File.ReadAllText(fileName), settings); // načtení událostí ze souboruisPlayingMacro = true; // Set playing flag to true

            isPlayingMacro = true; // nastaví přehrávání na true

            foreach (var inputEvent in events) // pro každou událost
            {
                if (!isPlayingMacro) break; // pokud je přehrávání zastaveno, ukončí smyčku

                switch (inputEvent.Type) // podle typu události
                {
                    case "DelayEvent":
                        var delayEvent = (DelayEvent)inputEvent; // převede událost na DelayEvent
                        await Task.Delay(delayEvent.Duration); // čeká na zpoždění
                        break;
                    case "MouseDown":
                        InputSender.SetCursorPosition(((MouseDownEvent)inputEvent).X, ((MouseDownEvent)inputEvent).Y); // nastaví kurzor na pozici
                        switch (((MouseDownEvent)inputEvent).Button) // podle tlačítka myši
                        {
                            case "Left":
                                MouseOperation((uint)InputSender.MouseEventF.LeftDown); // zavolá funkci pro stisknutí levého tlačítka myši
                                break;
                            case "Right":
                                MouseOperation((uint)InputSender.MouseEventF.RightDown); // zavolá funkci pro stisknutí pravého tlačítka myši
                                break;
                            case "Middle":
                                MouseOperation((uint)InputSender.MouseEventF.MiddleDown); // zavolá funkci pro stisknutí prostředního tlačítka myši
                                break;
                        }
                        break;
                    case "MouseUp":
                        InputSender.SetCursorPosition(((MouseUpEvent)inputEvent).X, ((MouseUpEvent)inputEvent).Y); // nastaví kurzor na pozici
                        switch (((MouseUpEvent)inputEvent).Button) // podle tlačítka myši
                        {
                            case "Left":
                                MouseOperation((uint)InputSender.MouseEventF.LeftUp); // zavolá funkci pro uvolnění levého tlačítka myši
                                break;
                            case "Right":
                                MouseOperation((uint)InputSender.MouseEventF.RightUp); // zavolá funkci pro uvolnění pravého tlačítka myši
                                break;
                            case "Middle":
                                MouseOperation((uint)InputSender.MouseEventF.MiddleUp); // zavolá funkci pro uvolnění prostředního tlačítka myši
                                break;
                        }
                        break;
                    case "KeyDown":
                        var keyDownEvent = (KeyDownEvent)inputEvent; // převede událost na KeyDownEvent
                        InputSender.SendKeyboardInput(new InputSender.KeyboardInput[] // odesílá událost stisknutí klávesy
                        {
                            new InputSender.KeyboardInput // vytvoří novou instanci klávesové události
                            {
                                wScan = Convert.ToUInt16(keyDownEvent.Code, 16), // převede hexadecimální kód na číslo
                                dwFlags = (uint)InputSender.KeyEventF.KeyDown | (uint)InputSender.KeyEventF.Scancode // příznak pro stisknutí klávesy
                            }
                        });
                        break;
                    case "KeyUp":
                        var keyUpEvent = (KeyUpEvent)inputEvent; // převede událost na KeyUpEvent
                        InputSender.SendKeyboardInput(new InputSender.KeyboardInput[] // odesílá událost uvolnění klávesy
                        {
                            new InputSender.KeyboardInput // vytvoří novou instanci klávesové události
                            {
                                wScan = Convert.ToUInt16(keyUpEvent.Code, 16), // převede hexadecimální kód na číslo
                                dwFlags = (uint)InputSender.KeyEventF.KeyUp | (uint)InputSender.KeyEventF.Scancode // příznak pro uvolnění klávesy
                            }
                        });
                        break;
                }
            }

            isPlayingMacro = false; // resetuje přehrávání na false po dokončení událostí
        }

        private void PlayerStopPlayingMacroButton_Click(object sender, EventArgs e)
        {
            isPlayingMacro = false; // nastaví přehrávání na false
        }

        private void PlayerStartStopKeybindSetButton_Click(object sender, EventArgs e)
        {
            //TODO
        }




        private void ShowCurrentKeyboardLayout()
        {
            string layoutText = KeyboardLayoutHelper.GetKeyboardLayoutText();
            MessageBox.Show($"Current keyboard layout: {layoutText} keyboard");
        } //funkce kterou zavoláme a vrátí název aktuálního jazykového rozložení klávesnice s pomocí KeyboardLayoutHelper.cs TODO


        private void MouseOperation(uint button)
        {
            //InputSender.SetCursorPosition(x, y); // Nastaví kurzor na pozici
            InputSender.SendMouseInput(new InputSender.MouseInput[]
            {
                new InputSender.MouseInput
                {
                    dwFlags = button,
                }
            });
        } // funkce pro stisknutí nebo uvolnění tlačítka myši používá se v přehrávači makra

        private void Type(string str)
        {
            char c; // proměnná pro znak
            ushort scanCode; // proměnná pro skenovací kód

            for (int i = 0; i < str.Length; i++) // pro každý znak v řetězci
            {
                c = char.Parse(str.Substring(i,1)); // získá znak z řetězce
                scanCode = GetScanCode(c); // získá skenovací kód pro znak

                if (ShiftRequired(c)) // pokud je potřeba shift
                {
                    
                    PressCombo(0x2a, scanCode); // zavolá funkci pro stisknutí kombinace kláves
                }
                else
                {
                    InputSender.ClickKey(scanCode); // když není potřeba shift, zavolá funkci pro stisknutí klávesy

                }

            }
        } // funkce pro napsání textu pomocí stisknutí klávesy, používá se v přehrávači makra

        private ushort GetScanCode(char c)
        {
            switch (KeyboardLayoutHelper.GetKeyboardLayoutText())
            {
                case "Czech":
                    switch (Char.ToLower(c))
                    {
                        case 'a': return 0x1e;
                        case 'b': return 0x30;
                        case 'c': return 0x2e;
                        case 'd': return 0x20;
                        case 'e': return 0x12;
                        case 'f': return 0x21;
                        case 'g': return 0x22;
                        case 'h': return 0x23;
                        case 'i': return 0x17;
                        case 'j': return 0x24;
                        case 'k': return 0x25;
                        case 'l': return 0x26;
                        case 'm': return 0x32;
                        case 'n': return 0x31;
                        case 'o': return 0x18;
                        case 'p': return 0x19;
                        case 'q': return 0x10;
                        case 'r': return 0x13;
                        case 's': return 0x1f;
                        case 't': return 0x14;
                        case 'u': return 0x16;
                        case 'v': return 0x2f;
                        case 'w': return 0x11;
                        case 'x': return 0x2d;
                        case 'y': return 0x2c; // Y is Z in Czech layout
                        case 'z': return 0x15; // Z is Y in Czech layout
                        case '0': return 0x0b;
                        case '1': return 0x02;
                        case '2': return 0x03;
                        case '3': return 0x04;
                        case '4': return 0x05;
                        case '5': return 0x06;
                        case '6': return 0x07;
                        case '7': return 0x08;
                        case '8': return 0x09;
                        case '9': return 0x0a;
                        case '.': return 0x34; // tečka
                        case ',': return 0x33; // čárka
                        case ';': return 0x33; // česká čárka s Shiftem (např. pro středník)
                        case ':': return 0x34; // česká tečka s Shiftem (např. pro dvojtečku)
                        case '-': return 0x0c;
                        case '=': return 0x0d;
                        case '+': return 0x0d; // Shift na stejné klávese jako =
                        case '\\': return 0x2b;
                        case '\'': return 0x28;
                        case '"': return 0x28;
                        case '/': return 0x35;
                        case '?': return 0x35;
                        case '<': return 0x56; // český `<` na extra klávese vedle levého Shiftu
                        case ' ': return 0x39;
                        case '\n': return 0x1c;
                        case '\t': return 0x0f;
                        case '\b': return 0x0e;
                        case '\x1b': return 0x01;
                        case '\x7f': return 0x0e;
                        default: return 0x00;
                    }
                case "US":
                    switch (Char.ToLower(c))
                    {
                        case 'a': return 0x1e;
                        case 'b': return 0x30;
                        case 'c': return 0x2e;
                        case 'd': return 0x20;
                        case 'e': return 0x12;
                        case 'f': return 0x21;
                        case 'g': return 0x22;
                        case 'h': return 0x23;
                        case 'i': return 0x17;
                        case 'j': return 0x24;
                        case 'k': return 0x25;
                        case 'l': return 0x26;
                        case 'm': return 0x32;
                        case 'n': return 0x31;
                        case 'o': return 0x18;
                        case 'p': return 0x19;
                        case 'q': return 0x10;
                        case 'r': return 0x13;
                        case 's': return 0x1f;
                        case 't': return 0x14;
                        case 'u': return 0x16;
                        case 'v': return 0x2f;
                        case 'w': return 0x11;
                        case 'x': return 0x2d;
                        case 'y': return 0x15;
                        case 'z': return 0x2c;
                        case '0': return 0x0b;
                        case '1': return 0x02;
                        case '2': return 0x03;
                        case '3': return 0x04;
                        case '4': return 0x05;
                        case '5': return 0x06;
                        case '6': return 0x07;
                        case '7': return 0x08;
                        case '8': return 0x09;
                        case '9': return 0x0a;
                        case '.': return 0x34;
                        case ',': return 0x33;
                        case ';': return 0x27;
                        case ':': return 0x27;
                        case '!': return 0x02;
                        case '@': return 0x03;
                        case '#': return 0x04;
                        case '$': return 0x05;
                        case '%': return 0x06;
                        case '^': return 0x07;
                        case '&': return 0x08;
                        case '*': return 0x09;
                        case '(': return 0x0a;
                        case ')': return 0x0b;
                        case '-': return 0x0c;
                        case '_': return 0x0c;
                        case '=': return 0x0d;
                        case '+': return 0x0d;
                        case '[': return 0x1a;
                        case ']': return 0x1b;
                        case '{': return 0x1a;
                        case '}': return 0x1b;
                        case '\\': return 0x2b;
                        case '|': return 0x2b;
                        case '\'': return 0x28;
                        case '"': return 0x28;
                        case '/': return 0x35;
                        case '?': return 0x35;
                        case '<': return 0x33;
                        case '>': return 0x34;
                        case '`': return 0x29;
                        case '~': return 0x29;
                        case '\t': return 0x0f; // Tab
                        case '\b': return 0x0e; // Backspace
                        case '\n': return 0x1c; // Enter
                        case ' ': return 0x39; // Space
                        case '\x1b': return 0x01; // Escape
                        case '\x7f': return 0x0e; // Delete
                        default: return 0x00; // Unknown character
                    }
                default:
                    MessageBox.Show("Error please select english keyboard your keyboard:"+ KeyboardLayoutHelper.GetKeyboardLayoutText()); // Unknown layout
                    return 0x00; // Return a default value
            }
        } // funkce pro získání skenovacího kódu pro znak podle jazykového rozložení klávesnice, používá se v přehrávači makra (TODO asi to dám do souboru bokem)

        private bool ShiftRequired(char c)
        {
            char[] chars = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '{', '}', '|', ':', '"', '<', '>', '?' }; //seznam znaků, které vyžadují Shift TODO každý jazyk je má jiný
            if (chars.Contains(c))
            {
                return true; // Pokud znak vyžaduje Shift, vrátí true
            }
            
            if(Char.IsUpper(c)) // TODO ? kdz6 je velkz C ma to uplne jinaci funcknost ?? absolutně nevím co jsem tím myslel
            {
                return true; // Pokud je znak velké písmeno, vrátí true
            }

            return false; // Jinak vrátí false
        } // funkce pro kontrolu, zda je potřeba Shift pro daný znak, používá se v přehrávači makra (TODO asi to dám do souboru bokem)

        private static void PressCombo(ushort code1, ushort code2)
        {

            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[] // odesílá skenovací kódy pro stisknutí klávesy
            {
                      new InputSender.KeyboardInput // první klávesa
                      {
                          wScan = code1, // skenovací kód
                          dwFlags = (uint)(InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode) // příznak pro stisknutí klávesy
                      },
                      new InputSender.KeyboardInput // druhá klávesa
                      {
                          wScan = code2, // skenovací kód
                          dwFlags = (uint)(InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode) // příznak pro stisknutí klávesy
                      }
            });


            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[] // odesílá skenovací kódy pro uvolnění klávesy
            {
                      new InputSender.KeyboardInput // první klávesa
                      {
                          wScan = code2, // skenovací kód
                          dwFlags = (uint)(InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode) // příznak pro uvolnění klávesy
                      },
                      new InputSender.KeyboardInput // druhá klávesa
                      {
                          wScan = code1, // skenovací kód
                          dwFlags = (uint)(InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode) // příznak pro uvolnění klávesy
                      }
            });


        } // funkce pro stisknutí kombinace kláves (např. Shift + A) používá se v přehrávači makra

        private static void PressExtended(ushort code)
        {

            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
            {
                new InputSender.KeyboardInput
                {
                    wScan = 0xe0,
                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.Scancode),
                },
                new InputSender.KeyboardInput
                {
                    wScan = code,
                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.Scancode)
                }
            });
        } // funkce pro stisknutí rozšířené klávesy (např. Ctrl + A) používá se v přehrávači makra nevím k čemu to tady je TODO

        async void TestButton_ClickAsync(object sender, EventArgs e)
        {
            // Spustí Notepad
            System.Diagnostics.Process.Start("notepad.exe");
            await Task.Delay(1000); // -1432 1015, -1432 942
            InputSender.ClickKey(0x14); // Z TODO meni se to podle rozložení klávesnice
            Type(Environment.NewLine);



            //InputSender.SetCursorPosition(-1432, 1015);
            //await Task.Delay(50);
            //MouseOperation((uint)InputSender.MouseEventF.LeftDown);
            //await Task.Delay(400);
            //InputSender.SetCursorPosition(-1432, 942);
            //await Task.Delay(50);
            //MouseOperation((uint)InputSender.MouseEventF.LeftUp);

            //SendToBack(); // Přesune okno na pozadí
            //Activate();
            //MessageBox.Show("Test"); // Zobrazí zprávu


        } //TESTOVACI FUNKCE

        


        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(); // vytvoření instance nastavení
            settingsForm.Show(); // zobrazení nastavení
            this.Enabled = false; // Disable the current form to make it non-clickable
            settingsForm.FormClosed += SettingsForm_FormClosed; // Attach event handler for FormClosed event
        } // tento event se spouští při kliknutí na tlačítko pro otevření nastavení a zobrazuje formulář pro nastavení aplikace

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true; // Re-enable the current form when the settings form is closed
            //TODO
        } // tento event se spouští při zavření formuláře nastavení a opět povolí hlavní formulář


        //TODO: na bookmarku mam jednu vec u ktery si nejsem jistej
        //TODO: nejako zjistit a fixnou verticalní zarovnání v StartStopPlayingKeybindTextBox (idk jestli to je vubec possible)
    }
}
