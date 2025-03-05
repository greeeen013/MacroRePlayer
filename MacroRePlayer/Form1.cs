using Gma.System.MouseKeyHook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
                //MessageBox.Show($"{loadedEvents}");

                // Display the loaded events
                DisplayEvents(loadedEvents);
            }
            else if (JsonFileSelectorComboBox.SelectedItem == null || JsonFileSelectorComboBox.SelectedItem.ToString() == "")
            {
                // vycisti to Table pokud je vybrano prazdne políčko
                EditorEventPanel.Controls.Clear();
            }
        }

        private void DisplayEvents(List<IInputEvent> events)
        {
            EditorEventPanel.Controls.Clear(); // Vyčistí panel před přidáním nových událostí

            int yOffset = 0; // Počáteční pozice Y

            foreach (var inputEvent in events)
            {
                var panel = new Panel
                {
                    Size = new Size(320, 30),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Location = new Point(0, yOffset) // Zarovnání doleva
                };

                var label = new Label
                {
                    Text = $"{inputEvent.Type}:",
                    AutoSize = false,
                    Size = new Size(80, 20),
                    Location = new Point(5, 5)
                };

                var textBox = new System.Windows.Forms.TextBox
                {
                    Text = GetEventValue(inputEvent), // Získání hodnoty události
                    Size = new Size(200, 20),
                    Location = new Point(90, 5)
                };

                var dragLabel = new Label
                {
                    Text = "≡",
                    AutoSize = false,
                    Size = new Size(20, 20),
                    Location = new Point(300, 5),
                    Cursor = Cursors.Hand // Změna kurzoru na ruku
                };

                // Přidání Label, TextBox a dragLabel do Panelu
                panel.Controls.Add(label);
                panel.Controls.Add(textBox);
                panel.Controls.Add(dragLabel);

                // Povolení drag-and-drop pro dragLabel
                dragLabel.MouseDown += DragLabel_MouseDown;
                dragLabel.MouseMove += DragLabel_MouseMove;
                dragLabel.MouseUp += DragLabel_MouseUp;

                // Přidání Panelu do EditorEventPanel
                EditorEventPanel.Controls.Add(panel);

                yOffset += 35; // Posunutí pozice Y pro další panel (30 výška panelu + 5 mezera)
            }
        }

        // DRAG AND DROP FUNKCIONALITA !!!
        private bool isDragging = false;
        private Point dragStartPoint;
        private Control draggedControl;
        private int draggedIndex;
        private Label _insertIndicator; // Indikátor pro vložení

        private void DragLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                draggedControl = ((Label)sender).Parent as Panel; // Chytáme celý Panel
                dragStartPoint = e.Location;
                draggedIndex = EditorEventPanel.Controls.IndexOf(draggedControl);
                draggedControl.BringToFront(); // Přesun panelu na vrchol
                draggedControl.BackColor = Color.LightBlue; // Zvýraznění při tažení


                // Inicializace indikátoru
                _insertIndicator = new Label
                {
                    Text = "-----",
                    AutoSize = false,
                    Size = new Size(320, 5),
                    BackColor = Color.Red,
                    Visible = false
                };

                // Přidání indikátoru do EditorEventPanel
                EditorEventPanel.Controls.Add(_insertIndicator);

                // Dočasné zakázání automatického přeuspořádávání
                EditorEventPanel.SuspendLayout();
            }
        }

        private void DragLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedControl != null)
            {
                Point newLocation = draggedControl.PointToScreen(e.Location);
                newLocation = EditorEventPanel.PointToClient(newLocation);

                // Odečtení počátečního bodu pro plynulý pohyb
                newLocation.X -= dragStartPoint.X;
                newLocation.Y -= dragStartPoint.Y;

                // Omezení pohybu, aby nešel mimo EditorEventPanel
                newLocation.X = Math.Max(0, Math.Min(newLocation.X, EditorEventPanel.Width - draggedControl.Width));
                newLocation.Y = Math.Max(0, Math.Min(newLocation.Y, EditorEventPanel.Height - draggedControl.Height));

                draggedControl.Location = newLocation;

                // Zobrazení indikátoru pro vložení
                ShowInsertIndicator(draggedControl);
            }
        }

        private void DragLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedControl != null)
            {
                isDragging = false;
                draggedControl.BackColor = Color.White; // Vrácení barvy

                // Skrytí indikátoru
                _insertIndicator.Visible = false;

                // Vložení Panelu na pozici indikátoru
                InsertPanelAtIndicator(draggedControl);

                // Obnovení automatického přeuspořádávání
                EditorEventPanel.ResumeLayout();

                // Odstranění indikátoru
                EditorEventPanel.Controls.Remove(_insertIndicator);

                draggedControl = null;
            }
        }

        private void ShowInsertIndicator(Control draggedControl)
        {
            int newIndex = CalculateNewIndex(draggedControl);

            // Kontrola, zda je newIndex platný a EditorEventPanel obsahuje prvky
            if (newIndex >= 0 && newIndex < EditorEventPanel.Controls.Count && EditorEventPanel.Controls[newIndex] != null)
            {
                // Nastavení pozice indikátoru
                _insertIndicator.Location = new Point(0, EditorEventPanel.Controls[newIndex].Location.Y - 5);
                _insertIndicator.Visible = true;
            }
            else if (newIndex == EditorEventPanel.Controls.Count)
            {
                // Pokud je newIndex za posledním panelem, zobrazte indikátor na konci
                _insertIndicator.Location = new Point(0, EditorEventPanel.Controls[EditorEventPanel.Controls.Count - 1].Location.Y + 35);
                _insertIndicator.Visible = true;
            }
            else
            {
                _insertIndicator.Visible = false; // Skrytí indikátoru, pokud je newIndex neplatný
            }
        }

        private void InsertPanelAtIndicator(Control draggedControl)
        {
            int newIndex = CalculateNewIndex(draggedControl);
            newIndex--; // Odečtení 1, protože se Panel vkládá před indikátorem

            if (newIndex != draggedIndex && newIndex >= 0 && newIndex <= EditorEventPanel.Controls.Count)
            {
                // Odstranění Panelu z původní pozice
                EditorEventPanel.Controls.Remove(draggedControl);

                // Vložení Panelu na novou pozici
                EditorEventPanel.Controls.Add(draggedControl);
                EditorEventPanel.Controls.SetChildIndex(draggedControl, newIndex);

                // Aktualizace pozic všech panelů
                UpdatePanelLocations();
            }
        }

        private void UpdatePanelLocations()
        {
            int yOffset = 0; // Počáteční pozice Y

            foreach (Control control in EditorEventPanel.Controls)
            {
                if (control is Panel panel && !ReferenceEquals(panel, _insertIndicator)) // Přeskočení indikátoru
                {
                    panel.Location = new Point(0, yOffset); // Zarovnání doleva
                    yOffset += panel.Height + 5; // Posunutí pozice Y pro další panel (výška panelu + mezera)
                }
            }
        }

        private int CalculateNewIndex(Control draggedControl)
        {
            int midPoint = draggedControl.Location.Y + (draggedControl.Height / 2);

            for (int i = 0; i < EditorEventPanel.Controls.Count; i++)
            {
                if (EditorEventPanel.Controls[i] == draggedControl) continue; // Přeskočení aktuálně taženého Panelu

                if (midPoint < EditorEventPanel.Controls[i].Location.Y + (EditorEventPanel.Controls[i].Height / 2))
                {
                    return i; // Vrátí index, kam má být panel vložen
                }
            }

            return EditorEventPanel.Controls.Count; // Vrátí index za posledním prvkem
        } 

        private string GetEventValue(IInputEvent inputEvent)
        {
            switch (inputEvent)
            {
                case DelayEvent delayEvent:
                    return delayEvent.Duration.ToString();
                case MouseDownEvent mouseDownEvent:
                    return $"X: {mouseDownEvent.X}, Y: {mouseDownEvent.Y}, Button: {mouseDownEvent.Button}";
                case MouseUpEvent mouseUpEvent:
                    return $"X: {mouseUpEvent.X}, Y: {mouseUpEvent.Y}, Button: {mouseUpEvent.Button}";
                case KeyDownEvent keyDownEvent:
                    return keyDownEvent.Key;
                case KeyUpEvent keyUpEvent:
                    return keyUpEvent.Key;
                default:
                    return string.Empty;
            }
        }

    }
}
