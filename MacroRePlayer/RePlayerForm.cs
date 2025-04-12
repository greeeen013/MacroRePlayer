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
        private readonly List<IInputEvent> events = [];
        private DateTime lastEventTime; // Poslední zaznamenaný čas události
        private bool isRecording; // Indikátor nahrávání
        private IKeyboardMouseEvents? globalHook; // Globální hook pro sledování vstupů
        private HashSet<string> pressedKeys = []; // Sledování stisknutých kláves
        private readonly string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer"); // Cesta k adresáři pro ukládání souborů
        private bool isPlayingMacro = false; // indikátor přehrávání makra


        //kvuli zavolání funkce pro ziskání konkrétní hardware klávesy
        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        private const uint MAPVK_VK_TO_VSC = 0;

        public RePlayerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JsonFileSelectorForm.Text = $"MacroRecord{DateTime.Now:HH-mm_dd.MM.yyyy}"; // nastavení výchozího názvu souboru do textového pole s datem a časem pro ukládání makra 

            this.PlayerPlaybackMethodComboBox.SelectedIndex = 0; // nastavení výchozího indexu na 0 (první položka v ComboBoxu což je one time play)

            this.PlayerPlaybackSpeedComboBox.SelectedIndex = 3; // nastavení výchozího indexu na 3 (čtvrtá položka v ComboBoxu což je 1x speed)

            RecordKeybindButton(true); // nastavení výchozího textu pro tlačítko pro nahrávání klávesových zkratek na "Record Keybind" (nahrát klávesovou zkratku)

            LoadSettingsIfExisted(); // kontrola a vytvoření konfiguračního souboru, pokud neexistuje a rovnou načte hodnoty

        } // tento event se spouští při načtení formuláře a předepíše výchozí název souboru (což je dnešní datum a čas) pro ukládání makra

        private void RePlayerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnsubscribeGlobalHook();
        }

        private int startUpDelay; // zpoždění při spuštění aplikace
        private bool autoDeleteLastClick; // indikátor pro automatické mazání posledního kliknutí
        private string HexKeyStartStopMacro; // hexadecimální kód pro klávesovou zkratku pro spuštění/zastavení přehrávání makra
        private int delayOffSet = 0; // offset pro přehrávání makra (odchylka)

        private void LoadSettingsIfExisted()
        {
            string settingsFilePath = Path.Combine(directoryPath, "settings.cfg"); // vytvoření cesty k souboru s nastavením

            if (File.Exists(settingsFilePath)) // pokud soubor existuje
            {
                var settings = File.ReadAllLines(settingsFilePath) // načtení všech řádků ze souboru
                                   .Skip(1) // přeskakujeme první řádek, který je nadpis
                                   .Select(line => line.Split(new[] { '=' }, 2)) // rozdělení řádku na klíč a hodnotu
                                   .ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim().Trim('"')); // vytvoření slovníku s klíči a hodnotami

                startUpDelay = int.Parse(settings["PlayerStartUpDelay"]); // přečtení zpoždění při spuštění aplikace
                PlayerPlaybackMethodComboBox.SelectedItem = settings["DefaultPlaybackMethod"]; // přečtení metody přehrávání
                PlayerPlaybackSpeedComboBox.SelectedItem = settings["DefaultPlaybackSpeed"]; // přečtení výchozí rychlosti přehrávání
                autoDeleteLastClick = bool.Parse(settings["AutoDeleteLastClick"]); // přečtení nastavení pro automatické mazání posledního kliknutí
                HexKeyStartStopMacro = settings["StartStopPlayingMacroHexKey"]; // přečtení klávesové zkratky pro spuštění/zastavení přehrávání makra
                delayOffSet = int.Parse(settings["PlayerDelayEventOffset"]); // přečtení offsetu pro zpoždění
                PlayerHowManyTimesNumericUpDown.Value = int.Parse(settings["DefaultPlaybackHowManyTimesRepeat"]); // přečtení počtu opakování přehrávání makra
            }

        }

        private void StartRecording_Click(object sender, EventArgs e)
        {
            // Zajistěte, že před inicializací hooku je odpojen jakýkoli existující hook
            UnsubscribeGlobalHook();
            RecordKeybindButton(false);


            Directory.CreateDirectory(directoryPath); // vytvoření složky pro ukládání souborů, pokud neexistuje
            events.Clear(); // vyčistí seznam událostí
            isRecording = true; // nastaví nahrávání na true
            lastEventTime = DateTime.Now; // nastaví poslední čas události na aktuální čas
            ToggleRecordingButtons(true); // přepíná povolení tlačítek pro nahrávání a zastavení nahrávání

            // Inicializace globálního hooku
            globalHook = Hook.GlobalEvents();
            globalHook.MouseDownExt += GlobalHook_MouseDownExt;
            globalHook.MouseUpExt += GlobalHook_MouseUpExt;
            globalHook.KeyDown += GlobalHook_KeyDown;
            globalHook.KeyUp += GlobalHook_KeyUp;
        }

        private void StopRecording_Click(object sender, EventArgs e)
        {
            if (autoDeleteLastClick && events.Count >= 4) // pokud je povoleno automatické mazání posledního kliknutí a počet událostí je větší nebo roven 4
            {
                var lastFourEvents = events.Skip(events.Count - 4).ToList(); // vezme poslední 4 události ze seznamu
                if (lastFourEvents[0] is DelayEvent && // pokud první událost je DelayEvent
                    lastFourEvents[1] is MouseDownEvent && // pokud druhá událost je MouseDownEvent
                    lastFourEvents[2] is DelayEvent && // pokud třetí událost je DelayEvent
                    lastFourEvents[3] is MouseUpEvent) // pokud čtvrtá událost je MouseUpEvent
                {
                    events.RemoveRange(events.Count - 4, 4); // tak odstraní poslední 4 události
                }
            }

            isRecording = false; // nastavuje nahrávání na false
            ToggleRecordingButtons(false); // přepíná povolení tlačítek pro nahrávání a zastavení nahrávání
            UnsubscribeGlobalHook(); // odhlášení event handlerů
            RecordKeybindButton(true); // znovu povolí sledování klávesových zkratek
            SaveEventsToJson(); // uložení událostí do JSON souboru
        } // tento event se spouští při kliknutí na tlačítko "Stop Recording" a zastavuje nahrávání událostí

        private void ToggleRecordingButtons(bool recording)
        {
            StopRecording.Enabled = recording; // povolení nebo zakázání tlačítka pro zastavení nahrávání
            StartRecording.Enabled = !recording; // povolení nebo zakázání tlačítka pro zahájení nahrávání
        } // přepíná povolení tlačítek pro nahrávání a zastavení nahrávání

        private void UnsubscribeGlobalHook()
        {
            if (globalHook != null) // pokud je globální hook inicializován
            {
                globalHook.MouseDownExt -= GlobalHook_MouseDownExt;
                globalHook.MouseUpExt -= GlobalHook_MouseUpExt;
                globalHook.KeyDown -= GlobalHook_KeyDown;
                globalHook.KeyUp -= GlobalHook_KeyUp;
                globalHook.KeyDown -= HookManager_KeyDown; // odhlášení event handleru pro makro klávesu
                globalHook.Dispose(); // uvolnění prostředků globálního hooku
                globalHook = null; // nastavte na null, aby bylo jasné, že hook byl odpojen
            }
        }

        private void SaveEventsToJson()
        {
            try
            {
                string fileName = Path.Combine(directoryPath, JsonFileSelectorForm.Text + ".json"); // vytvoření cesty k souboru s koncovkou .json
                File.WriteAllText(fileName, JsonConvert.SerializeObject(events, Formatting.Indented)); // uložení událostí do JSON souboru
                MessageBox.Show($"File {fileName} was successfully created."); // informace o úspěšném vytvoření souboru

                // Přidání nově vytvořeného souboru do PlayerComboBox
                if (!PlayerComboBox.Items.Contains(JsonFileSelectorForm.Text + ".json"))
                {
                    PlayerComboBox.Items.Add(JsonFileSelectorForm.Text + ".json");
                }
                PlayerComboBox.SelectedItem = JsonFileSelectorForm.Text + ".json"; // Předvyplnění ComboBoxu novým souborem
                JsonFileSelectorForm.Text = $"MacroRecord{DateTime.Now:HH-mm_dd.MM.yyyy}"; // aktualizování názvu souboru pro další nahrávání

            }
            catch (ArgumentException ex) // zachytí chybu při neplatném názvu souboru
            {
                MessageBox.Show($"Error: Invalid file name. Please check the name and try again.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // zachytí jiné chyby
            {
                MessageBox.Show($"Error while saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // tento event se spouští při uložení událostí do JSON souboru a informuje uživatele o úspěšném vytvoření souboru

        private void RecordEvent(IInputEvent inputEvent)
        {
            if (isRecording)
            {
                AddDelayEvent();
                events.Add(inputEvent);
                lastEventTime = DateTime.Now;
            }
        } // tento event se spouští při zaznamenávání události a přidává zpoždění mezi událostmi do seznamu událostí

        private void GlobalHook_MouseDownExt(object? sender, MouseEventExtArgs e)
        {
            RecordEvent(new MouseDownEvent { X = e.X, Y = e.Y, Button = e.Button.ToString() });
        } // tento event se spouští při stisknutí myši a zaznamenává událost do seznamu událostí

        private void GlobalHook_MouseUpExt(object? sender, MouseEventExtArgs e)
        {
            RecordEvent(new MouseUpEvent { X = e.X, Y = e.Y, Button = e.Button.ToString() });
        } // tento event se spouští při uvolnění myši a zaznamenává událost do seznamu událostí

        private void GlobalHook_KeyDown(object? sender, KeyEventArgs e)
        {
            // Získání scancode a hexadecimální reprezentace klávesy
            uint scancode = MapVirtualKey((uint)e.KeyCode, MAPVK_VK_TO_VSC);
            var hexKey = $"0x{scancode:X}";

            // Kontrola, zda je stisknuta klávesa pro spuštění/zastavení makra
            if (hexKey == HexKeyStartStopMacro)
            {
                if (!isPlayingMacro)
                {
                    PlayerStartPlayingMacroButton.PerformClick(); // Simulace kliknutí na tlačítko Start
                }
                else
                {
                    isPlayingMacro = false; // Zastavení přehrávání makra
                }
                return; // Ukončení metody, aby se tato klávesa nezaznamenávala jako událost
            }

            // Záznam klávesové události, pokud klávesa ještě nebyla stisknuta
            if (pressedKeys.Add(e.KeyCode.ToString()))
            {
                RecordEvent(new KeyDownEvent
                {
                    Key = e.KeyCode.ToString(),
                    Code = hexKey
                });
            }
        }

        private void GlobalHook_KeyUp(object? sender, KeyEventArgs e)
        {
            uint scancode = MapVirtualKey((uint)e.KeyCode, MAPVK_VK_TO_VSC);
            RecordEvent(new KeyUpEvent
            {
                Key = e.KeyCode.ToString(),
                Code = $"0x{scancode:X}"
            });
            pressedKeys.Remove(e.KeyCode.ToString());
        } // tento event se spouští při uvolnění klávesy a zaznamenává událost do seznamu událostí a odstraňuje klávesu ze seznamu stisknutých kláves (aby se zabránilo opakovanému zaznamenávání stejné klávesy)

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
        } // tento event se spouští při kliknutí na tlačítko pro otevření editoru a zobrazuje editor pro úpravu makra

        private void FolderDeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Opravdu chcete smazat složku s makry?", "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); // zobrazí dialogové okno pro potvrzení smazání složky
            if (result == DialogResult.Yes) // pokud uživatel potvrdí smazání
            {
                if (Directory.Exists(directoryPath)) // a pokud složka existuje
                {
                    Directory.Delete(directoryPath, true); // tak smaže složku a všechny její podadresáře a soubory
                    PlayerComboBox.SelectedIndex = -1; // vyčistí text v ComboBoxu
                    PlayerComboBox.Items.Clear(); // vyčistí položky v ComboBoxu
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
            if (Directory.Exists(directoryPath)) // ověří existenci složky
            {
                var files = Directory.GetFiles(directoryPath, "*.json") // získá všechny .json soubory ve složce
                                    .Select(Path.GetFileName) // získá pouze názvy souborů
                                    .ToHashSet(); // převede na HashSet pro rychlé porovnání

                var existingItems = PlayerComboBox.Items.Cast<string>().ToHashSet(); // získá existující položky v ComboBoxu jako HashSet

                var missingFiles = files.Except(existingItems); // najde soubory, které chybí v ComboBoxu

                foreach (var file in missingFiles)
                {
                    PlayerComboBox.Items.Add(file); // přidá chybějící soubory do ComboBoxu
                }
            }
        } // tento event se spouští při rozbalení Player ComboBoxu a přidává pouze chybějící .json soubory ze složky do ComboBoxu

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

        // HLAVNI PLAYER !!!!
        private bool isWaitingForStartUpDelay = false; // indikátor pro čekání na zpoždění při spuštění
        private async void PlayerStartPlayingMacroButton_Click(object sender, EventArgs e)
        {
            if (PlayerComboBox.SelectedItem == null) return; // pokud není vybrán žádný soubor, nic se nestane (ošetření)
            if (isPlayingMacro) return; // pokud je makro již přehráváno, nic se nestane (ošetření)

            string fileName = Path.Combine(directoryPath, PlayerComboBox.SelectedItem?.ToString() ?? ""); // vytvoření cesty k souboru
            if (!File.Exists(fileName)) return; // pokud soubor neexistuje, nic se nestane (ošetření)

            TogglePlayStopButtons(true); // Deaktivuje tlačítko Start a aktivuje tlačítko Stop
            isPlayingMacro = true; // nastaví přehrávání na true
            RecordKeybindButton(false); // zakáže sledování klávesových zkratek pro jistotu
            //PlayerStopPlayingMacroButton.Enabled = false; // zakáže tlačítko pro zastavení přehrávání
            if (startUpDelay > 0) // pokud je nastaveno zpoždění při spuštění
            {
                if (isWaitingForStartUpDelay) return; // pokud už čeká na zpoždění, nic se nestane (ošetření)
                isWaitingForStartUpDelay = true; // nastaví indikátor pro čekání na zpoždění
                await Task.Delay(startUpDelay); // čeká na zpoždění
                if (!isPlayingMacro) // kontrola, zda je přehrávání makra zastaveno
                {
                    return; // pokud je přehrávání zastaveno, ukončí metodu
                }
                isWaitingForStartUpDelay = false; // resetuje indikátor pro čekání na zpoždění
            }
           //PlayerStopPlayingMacroButton.Enabled = true; // povolí tlačítko pro zastavení přehrávání
            RecordKeybindButton(true); // znovu povolí sledování klávesových zkratek

            var settings = new JsonSerializerSettings(); // vytvoření nastavení pro JSON serializaci
            settings.Converters.Add(new InputEventConverter()); // přidání konvertoru pro události
            var events = JsonConvert.DeserializeObject<List<IInputEvent>>(File.ReadAllText(fileName), settings); // načtení událostí ze souboru

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            long previousTimestamp = stopwatch.ElapsedMilliseconds;

            int currentIteration = 0; // počáteční iterace pro přehrávání událostí (cykly)

            double playbackSpeed = double.Parse(PlayerPlaybackSpeedComboBox.SelectedItem.ToString().Replace("x", "").Replace(",", "."), CultureInfo.InvariantCulture); // konvertuje to DefaultPlaybackSpeed (což je: "1x", "1.25x", "2x",...) do double

            do
            {
                foreach (var inputEvent in events ?? Enumerable.Empty<IInputEvent>()) // pro každou událost
                {
                    if (!isPlayingMacro) break; // pokud je přehrávání zastaveno, ukončí smyčku

                    switch (inputEvent)
                    {
                        case DelayEvent delayEvent:
                            // Calculate the base delay duration adjusted by playback speed
                            long adjustedDuration = (long)(delayEvent.Duration / playbackSpeed);

                            // Add a random offset within the range of -delayOffSet to +delayOffSet
                            long randomOffset = new Random().Next(-delayOffSet, delayOffSet + 1);

                            // Calculate the final target timestamp
                            long targetTimestamp = previousTimestamp + adjustedDuration + randomOffset;

                            // Wait until the target timestamp is reached
                            while (stopwatch.ElapsedMilliseconds < targetTimestamp)
                            {
                                await Task.Delay(1); // Small polling delay
                            }

                            // Update the previous timestamp
                            previousTimestamp = targetTimestamp;
                            break;

                        case MouseDownEvent mouseDownEvent:
                            InputSender.SetCursorPosition(mouseDownEvent.X, mouseDownEvent.Y);
                            switch (mouseDownEvent.Button)
                            {
                                case "Left":
                                    MouseOperation((uint)InputSender.MouseEventF.LeftDown);
                                    break;
                                case "Right":
                                    MouseOperation((uint)InputSender.MouseEventF.RightDown);
                                    break;
                                case "Middle":
                                    MouseOperation((uint)InputSender.MouseEventF.MiddleDown);
                                    break;
                            }
                            break;

                        case MouseUpEvent mouseUpEvent:
                            InputSender.SetCursorPosition(mouseUpEvent.X, mouseUpEvent.Y);
                            switch (mouseUpEvent.Button)
                            {
                                case "Left":
                                    MouseOperation((uint)InputSender.MouseEventF.LeftUp);
                                    break;
                                case "Right":
                                    MouseOperation((uint)InputSender.MouseEventF.RightUp);
                                    break;
                                case "Middle":
                                    MouseOperation((uint)InputSender.MouseEventF.MiddleUp);
                                    break;
                            }
                            break;

                        case KeyDownEvent keyDownEvent:
                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                            {
                                new InputSender.KeyboardInput
                                {
                                    wScan = Convert.ToUInt16(keyDownEvent.Code, 16),
                                    dwFlags = (uint)InputSender.KeyEventF.KeyDown | (uint)InputSender.KeyEventF.Scancode
                                }
                            });
                            break;

                        case KeyUpEvent keyUpEvent:
                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                            {
                                new InputSender.KeyboardInput
                                {
                                    wScan = Convert.ToUInt16(keyUpEvent.Code, 16),
                                    dwFlags = (uint)InputSender.KeyEventF.KeyUp | (uint)InputSender.KeyEventF.Scancode
                                }
                            });
                            break;
                    }
                }

                currentIteration++;
            } while (isPlayingMacro && (PlayerHowManyTimesNumericUpDown.Value == 0 || currentIteration < PlayerHowManyTimesNumericUpDown.Value));
            // dělej dokud je přehrávání povoleno a buď je nastaveno 0 opakování nebo aktuální iterace je menší než počet opakování

            isPlayingMacro = false; // resetuje přehrávání na false po dokončení událostí
            TogglePlayStopButtons(false); // Resetuje tlačítka po dokončení makra
        }

        private void PlayerStopPlayingMacroButton_Click(object sender, EventArgs e)
        {
            isPlayingMacro = false; // nastaví přehrávání na false
            TogglePlayStopButtons(false); // Resetuje tlačítka
        } // tento event se spouští při kliknutí na tlačítko pro zastavení přehrávání makra a nastaví přehrávání na false a resetuje tlačítka pro spuštění/zastavení přehrávání makra

        private void TogglePlayStopButtons(bool isPlaying)
        {
            PlayerStartPlayingMacroButton.Enabled = !isPlaying; // Aktivuje/deaktivuje tlačítko pro spuštění
            PlayerStopPlayingMacroButton.Enabled = isPlaying;   // Aktivuje/deaktivuje tlačítko pro zastavení
        } // přepíná povolení tlačítek pro spuštění a zastavení přehrávání makra podle parametru isPlaying

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

        private void HookManager_KeyDown(object? sender, KeyEventArgs e)
        {
            uint scancode = MapVirtualKey((uint)e.KeyCode, MAPVK_VK_TO_VSC);
            var HexKey = $"0x{scancode:X}";
            if (HexKey == HexKeyStartStopMacro)
            {
                if (isPlayingMacro == false)
                {
                    PlayerStartPlayingMacroButton.PerformClick(); // Simulate clicking the start button
                }
                else
                {
                    isPlayingMacro = false;
                }
            }
        } // tento event se spouští při stisknutí klávesy a kontroluje zda je stisknuta klávesa pro spuštění/zastavení přehrávání makra a pokud ano, tak spustí nebo zastaví přehrávání makra

        private void RecordKeybindButton(bool a)
        {
            if (a)
            {
                globalHook = Hook.GlobalEvents(); // inicializace globálního hooku pro sledování vstupů
                globalHook.KeyDown += HookManager_KeyDown; // přidání event handleru pro stisknutí klávesy
            }
            else
            {
                if (globalHook != null)
                {
                    globalHook.KeyDown -= HookManager_KeyDown; // odhlášení event handleru pro stisknutí klávesy
                    globalHook.Dispose();
                    globalHook = null;
                }
            }
        } // tento event se spouští při kliknutí na tlačítko pro nahrávání klávesových zkratek a inicializuje nebo uvolňuje globální hook pro sledování vstupů podle parametru a

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(); // vytvoření instance nastavení
            settingsForm.Show(); // zobrazení nastavení
            this.Enabled = false; // zakáže hlavní formulář
            settingsForm.FormClosed += SettingsForm_FormClosed; // přidání event handleru pro zavření nastavení
        } // tento event se spouští při kliknutí na tlačítko pro otevření nastavení a zobrazuje formulář pro nastavení aplikace

        private void SettingsForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Enabled = true; // znovu povolí hlavní formulář
            LoadSettingsIfExisted(); // načtení nastavení z konfiguračního souboru pokud existuje což by měl v tomto případě
        } // tento event se spouští při zavření formuláře nastavení a opět povolí hlavní formulář

        private void UpdatePlaybackMethodUI(string method)
        {
            bool isRepeat = method == "Play X times";
            PlayerHowManyTimesNumericUpDown.Visible = isRepeat;
            PlayerHowManyTimesLabel.Visible = isRepeat;
            PlayerHowManyTimesNumericUpDown.Value = isRepeat ? 1 : 0;

            PlayerHowManyTimesNumericUpDown.Value = method == "Repeat until stopped" ? 0 : 1;
        }

        private void PlayerPlaybackMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayerPlaybackMethodComboBox.SelectedItem != null)
            {
                UpdatePlaybackMethodUI(PlayerPlaybackMethodComboBox.SelectedItem.ToString());
            }

        } // tento event se spouští při změně výběru v ComboBoxu pro metodu přehrávání a nastavuje viditelnost a hodnoty pro nastavení počtu opakování podle vybrané metody přehrávání

        


        //TODO: nejako zjistit a fixnou verticalní zarovnání v StartStopPlayingKeybindTextBox (idk jestli to je vubec possible)
    }
}
