using Gma.System.MouseKeyHook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Formatting = Newtonsoft.Json.Formatting;

namespace MacroRePlayer
{
    public partial class Form1 : Form
    {
        // Seznam událostí, které budou zaznamenány
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
            // Nastavení výchozího názvu souboru s aktuálním časem
            JsonFileSelectorForm.Text = $"MacroRecord{DateTime.Now:HH-mm_dd.MM.yyyy}";
        }

        private void StartRecording_Click(object sender, EventArgs e)
        {
            // Vytvoří složku, pokud neexistuje
            Directory.CreateDirectory(directoryPath);

            events.Clear(); // Vyčistí seznam událostí
            isRecording = true;
            lastEventTime = DateTime.Now;
            ToggleRecordingButtons(true);

            // Inicializace globálního hooku pro sledování vstupů
            globalHook = Hook.GlobalEvents();
            globalHook.MouseDownExt += GlobalHook_MouseDownExt;
            globalHook.MouseUpExt += GlobalHook_MouseUpExt;
            globalHook.KeyDown += GlobalHook_KeyDown;
            globalHook.KeyUp += GlobalHook_KeyUp;
        }

        private void StopRecording_Click(object sender, EventArgs e)
        {
            isRecording = false;
            ToggleRecordingButtons(false);
            UnsubscribeGlobalHook(); // Odhlášení event handlerů
            SaveEventsToJson(); // Uložení událostí do JSON souboru
        }

        private void ToggleRecordingButtons(bool recording)
        {
            // Přepnutí viditelnosti tlačítek start/stop
            StopRecording.Visible = recording;
            StartRecording.Visible = !recording;
        }

        private void UnsubscribeGlobalHook()
        {
            // Odpojení všech event handlerů
            if (globalHook != null)
            {
                globalHook.MouseDownExt -= GlobalHook_MouseDownExt;
                globalHook.MouseUpExt -= GlobalHook_MouseUpExt;
                globalHook.KeyDown -= GlobalHook_KeyDown;
                globalHook.KeyUp -= GlobalHook_KeyUp;
                globalHook.Dispose();
            }
        }

        private void SaveEventsToJson()
        {
            // Uložení seznamu událostí do JSON souboru
            string fileName = Path.Combine(directoryPath, JsonFileSelectorForm.Text + ".json");
            File.WriteAllText(fileName, JsonConvert.SerializeObject(events, Formatting.Indented));
            MessageBox.Show($"Soubor {fileName} byl úspěšně vytvořen.");
        }

        private void GlobalHook_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            // Záznam stisknutí myši
            if (isRecording)
            {
                AddDelayEvent(); // Přidání zpoždění mezi událostmi
                events.Add(new MouseDownEvent { X = e.X, Y = e.Y, Button = e.Button.ToString() });
                lastEventTime = DateTime.Now;
            }
        }

        private void GlobalHook_MouseUpExt(object sender, MouseEventExtArgs e)
        {
            // Záznam uvolnění myši
            if (isRecording)
            {
                AddDelayEvent(); // Přidání zpoždění mezi událostmi
                events.Add(new MouseUpEvent { X = e.X, Y = e.Y, Button = e.Button.ToString() });
                lastEventTime = DateTime.Now;
            }
        }

        private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            // Záznam stisknutí klávesy, pouze pokud nebyla zaznamenána dříve
            if (isRecording && pressedKeys.Add(e.KeyCode.ToString()))
            {
                AddDelayEvent();
                events.Add(new KeyDownEvent { Key = e.KeyCode.ToString() });
                lastEventTime = DateTime.Now;
            }
        }

        private void GlobalHook_KeyUp(object sender, KeyEventArgs e)
        {
            // Záznam uvolnění klávesy
            if (isRecording)
            {
                AddDelayEvent();
                events.Add(new KeyUpEvent { Key = e.KeyCode.ToString() });
                lastEventTime = DateTime.Now;
                pressedKeys.Remove(e.KeyCode.ToString());
            }
        }

        private void AddDelayEvent()
        {
            // Přidání časového zpoždění mezi událostmi
            int delay = (int)(DateTime.Now - lastEventTime).TotalMilliseconds;
            if (delay > 0)
            {
                events.Add(new DelayEvent { Duration = delay });
            }
        }

        private void FolderOpenerButton_Click(object sender, EventArgs e)
        {
            // Otevření složky s uloženými makry
            if (Directory.Exists(directoryPath))
            {
                System.Diagnostics.Process.Start("explorer.exe", directoryPath);
            }
            else
            {
                MessageBox.Show("Složka neexistuje.");
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            // Naplnění seznamu dostupných JSON souborů
            JsonFileSelectorComboBox.Items.Clear();

            // Přidání prázdné položky na začátek
            JsonFileSelectorComboBox.Items.Add("");

            if (Directory.Exists(directoryPath))
            {
                JsonFileSelectorComboBox.Items.AddRange(Directory.GetFiles(directoryPath, "*.json").Select(Path.GetFileName).ToArray());
            }
        }

        private void JsonFileSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Načtení vybraného souboru a jeho zobrazení
            string selectedFile = Path.Combine(directoryPath, JsonFileSelectorComboBox.SelectedItem.ToString());

            if (File.Exists(selectedFile))
            {
                // Pridaní InputEventConverter aby se správně parsovala InputEvent interface
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new InputEventConverter());

                List<IInputEvent> loadedEvents = JsonConvert.DeserializeObject<List<IInputEvent>>(File.ReadAllText(selectedFile), settings);
                Console.WriteLine(loadedEvents);

                // Display the loaded events
                DisplayEvents(loadedEvents);
            }
            else if (JsonFileSelectorComboBox.SelectedItem == null || JsonFileSelectorComboBox.SelectedItem.ToString() == "")
            {
                // Clear the editor panel if no file is selected
                EditorEventPanel.Controls.Clear();
            }
        }

        private void DisplayEvents(List<IInputEvent> events)
        {
            for (int i = 0; i < events.Count; i++)
            {
                // TODO: pridat ke všem eventum draw funkci
                events[i].draw();
            }
        }

    }
}
