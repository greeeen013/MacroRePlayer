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
using System.Threading; // kvuli thread sleepu

namespace MacroRePlayer
{
    public partial class Form1 : Form
    {
        private List<IInputEvent> events = new List<IInputEvent>();
        private DateTime lastEventTime; // Poslední zaznamenaný čas události
        private bool isRecording; // Indikátor nahrávání
        private IKeyboardMouseEvents globalHook; // Globální hook pro sledování vstupů
        private HashSet<string> pressedKeys = new HashSet<string>(); // Sledování stisknutých kláves
        private readonly string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer"); // Cesta k adresáři pro ukládání souborů


        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JsonFileSelectorForm.Text = $"MacroRecord{DateTime.Now:HH-mm_dd.MM.yyyy}"; // nastavení výchozího názvu souboru do textového pole s datem a časem pro ukládání makra 

            this.EditorStartStopPlayingKeybindTextBox.AutoSize = false;
            this.EditorStartStopPlayingKeybindTextBox.Size = new System.Drawing.Size(85, 43); // nastavení velikosti textového pole pro klávesovou zkratku na keybind pro spouštění/zastavení přehrávání

            this.EditorPlaybackMethodComboBox.DropDownStyle = ComboBoxStyle.DropDownList; // nastavení stylu ComboBoxu na DropDownList
            this.EditorPlaybackMethodComboBox.SelectedIndex = 0; // nastavení výchozího indexu na 0 (první položka v ComboBoxu což je one time play)

            this.EditorPlaybackSpeedComboBox.DropDownStyle = ComboBoxStyle.DropDownList; // nastavení stylu ComboBoxu na DropDownList
            this.EditorPlaybackSpeedComboBox.SelectedIndex = 3; // nastavení výchozího indexu na 3 (čtvrtá položka v ComboBoxu což je 1x speed)


        } // tento event se spouští při načtení formuláře a předepíše výchozí název souboru (což je dnešní datum a čas) pro ukládání makra

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
            if (isRecording && pressedKeys.Add(e.KeyCode.ToString())) // pokud je nahrávání povoleno a klávesa ještě nebyla stisknuta
            {
                AddDelayEvent(); // přidání zpoždění mezi událostmi
                events.Add(new KeyDownEvent { Key = e.KeyCode.ToString() }); // zaznamenání události stisknutí klávesy
                lastEventTime = DateTime.Now; // aktualizace posledního času události
            }
        } // tento event se spouští při stisknutí klávesy a zaznamenává událost do seznamu událostí

        private void GlobalHook_KeyUp(object sender, KeyEventArgs e)
        {
            if (isRecording) // pokud je nahrávání povoleno
            {
                AddDelayEvent(); // přidání zpoždění mezi událostmi
                events.Add(new KeyUpEvent { Key = e.KeyCode.ToString() }); // zaznamenání události uvolnění klávesy
                lastEventTime = DateTime.Now; // aktualizace posledního času události
                pressedKeys.Remove(e.KeyCode.ToString()); // odstranění klávesy ze sledovaných stisknutých kláves
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
            EditorForm form = new EditorForm();
            form.Show();
        } //working on it

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
        }

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
        }

        private void PlayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayerComboBox.SelectedItem != null) // pokud je vybrán nějaký soubor
            {
                StartPlayingMacroButton.Enabled = true; // povolí tlačítko pro spuštění makra
            }
            else
            {
                StartPlayingMacroButton.Enabled = false; // zakáže tlačítko pro spuštění makra
            }
        }

        private async void StartPlayingMacroButton_Click(object sender, EventArgs e)
        {
            if (PlayerComboBox.SelectedItem == null) return; // pokud není vybrán žádný soubor, nic se nestane (ošetření)

            string fileName = Path.Combine(directoryPath, PlayerComboBox.SelectedItem.ToString()); // vytvoření cesty k souboru
            if (!File.Exists(fileName)) return; // pokud soubor neexistuje, nic se nestane (ošetření)

            
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new InputEventConverter());
            var events = JsonConvert.DeserializeObject<List<IInputEvent>>(File.ReadAllText(fileName), settings); // načtení událostí ze souboru
            foreach (var inputEvent in events)
            {
                switch (inputEvent.Type)
                {
                    case "DelayEvent":
                        var delayEvent = (DelayEvent)inputEvent;
                        var end = DateTime.Now.AddMilliseconds(delayEvent.Duration);
                        await Task.Delay(delayEvent.Duration);

                        break;
                   // case "MouseDown":
                   //     var mouseDownEvent = (MouseDownEvent)inputEvent;
                   //     MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown, mouseDownEvent.X, mouseDownEvent.Y);
                   //     break;
                   // case "MouseUp":
                   //     var mouseUpEvent = (MouseUpEvent)inputEvent;
                   //     MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp, mouseUpEvent.X, mouseUpEvent.Y);
                   //     break;
                    case "KeyDown":
                        var keyDownEvent = (KeyDownEvent)inputEvent;
                        //SimulateKeyDown((Keys)Enum.Parse(typeof(Keys), keyDownEvent.Key));
                        break;
                    case "KeyUp":
                        var keyUpEvent = (KeyUpEvent)inputEvent;
                        //SimulateKeyUp((Keys)Enum.Parse(typeof(Keys), keyUpEvent.Key));
                        break;
                }
            }
        }

        private void StopPlayingMacroButton_Click(object sender, EventArgs e)
        {

        }

        private void EditorStartStopKeybindSetButton_Click(object sender, EventArgs e)
        {

        }



        //VECI KE KEYUP A KEYDOWN
        //private const int KEYEVENTF_KEYDOWN = 0x0000;   // Nic speciálního, jen "stisk"
        //private const int KEYEVENTF_KEYUP = 0x0002;   // Uvolnění (pusť klávesu)
        //
        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        
        private void LeftDrag(Point start, Point end)
        {
            InputSender.SetCursorPosition(start.X, start.Y); // Nastaví kurzor na počáteční pozici

            InputSender.SendMouseInput(new InputSender.MouseInput[]
            {
                new InputSender.MouseInput
                {
                    dwFlags = (uint)InputSender.MouseEventF.LeftDown,
                }
            });

            Thread.Sleep(100);

            InputSender.SetCursorPosition(end.X, end.Y); // Přetáhne kurzor na koncovou pozici

            InputSender.SendMouseInput(new InputSender.MouseInput[]
            {
                new InputSender.MouseInput
                {
                    dwFlags = (uint)InputSender.MouseEventF.LeftUp,
                }
            });
        }

        private void RightDrag(Point start, Point end)
        {
            InputSender.SetCursorPosition(start.X, start.Y); // Nastaví kurzor na počáteční pozici

            InputSender.SendMouseInput(new InputSender.MouseInput[]
            {
                new InputSender.MouseInput
                {
                    dwFlags = (uint)InputSender.MouseEventF.RightDown,
                }
            });

            Thread.Sleep(100);

            InputSender.SetCursorPosition(end.X, end.Y); // Přetáhne kurzor na koncovou pozici

            InputSender.SendMouseInput(new InputSender.MouseInput[]
            {
                new InputSender.MouseInput
                {
                    dwFlags = (uint)InputSender.MouseEventF.RightUp,
                }
            });
        }

        private void PaintLines()
        {
            Point p = new Point(15, 175);
            Rectangle r = Screen.GetWorkingArea(this);

            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    LeftDrag(p, new Point(r.Width - 25, p.Y)); // Přetáhne kurzor na koncovou pozici
                }
                else
                {
                    RightDrag(p, new Point(r.Width - 25, p.Y)); // Přetáhne kurzor na koncovou pozici
                }

                p = new Point(p.X, p.Y + 50); // Posune kurzor dolů o 50 pixelů

                Thread.Sleep(500); // Počká 500ms mezi tahy
            }
        }

        async void TestButton_ClickAsync(object sender, EventArgs e)
        {
            // Spustí Notepad
            //System.Diagnostics.Process.Start("notepad.exe");
            await Task.Delay(1000);

            SendToBack(); // Přesune okno na pozadí
            Thread.Sleep(1000); // Počká 1 sekundu
            PaintLines();
            Activate();
            MessageBox.Show("Test"); // Zobrazí zprávu

            
        }




        //TODO: smazání složky s makrama button s "are you sure message"
        //TODO: na bookmarku mam jednu vec u ktery si nejsem jistej
        //TODO: nejako zjistit a fixnou verticalní zarovnání v StartStopPlayingKeybindTextBox (idk jestli to je vubec possible)
    }
}
