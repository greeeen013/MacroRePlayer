using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRePlayer
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();


            // Inicializace ovládacích prvků k delay
            newDelayTextBox = new TextBox { Location = new Point(50, 40), Width = 200, Visible = false };
            newDelayLabel = new Label { Text = "Delay:", Location = new Point(10, 40), Visible = false };

            // Inicializace ovládacích prvků k myši
            newTextBoxX = new TextBox { Location = new Point(50, 10), Width = 200, Visible = false };
            newTextBoxY = new TextBox { Location = new Point(50, 40), Width = 200, Visible = false };
            newComboButtonBox = new ComboBox { Location = new Point(50, 70), Width = 200, Visible = false };
            newComboButtonBox.Items.AddRange(new string[] { "Left", "Right", "Middle" });

            newLabelX = new Label { Text = "X:", Location = new Point(10, 10), Visible = false };
            newLabelY = new Label { Text = "Y:", Location = new Point(10, 40), Visible = false };
            newLabelCombo = new Label { Text = "Button:", Location = new Point(10, 70), Visible = false };

            // Inicializace ovládacích prvků k klávesnici
            newKeyTextBox = new TextBox { Location = new Point(50, 40), Width = 20, MaxLength = 1, Visible = false };
            newKeyLabel = new Label { Text = "Key:", Location = new Point(10, 40), Visible = false };



            // Přidání prvků do formuláře delay
            this.Controls.Add(newDelayTextBox);
            this.Controls.Add(newDelayLabel);

            // Přidání prvků do formuláře myš
            this.Controls.Add(newTextBoxX);
            this.Controls.Add(newTextBoxY);
            this.Controls.Add(newComboButtonBox);
            this.Controls.Add(newLabelX);
            this.Controls.Add(newLabelY);
            this.Controls.Add(newLabelCombo);

            // Přidání prvků do formuláře klávesnice
            this.Controls.Add(newKeyTextBox);
            this.Controls.Add(newKeyLabel);


        }

        private readonly string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer"); // Cesta k adresáři pro ukládání souborů

        private TextBox newTextBoxX = null; // TextBox pro X
        private TextBox newTextBoxY = null; // TextBox pro Y
        private ComboBox newComboButtonBox = null; // ComboBox pro výběr tlačítka
        private Label newLabelX = null; // Label pro X
        private Label newLabelY = null; // Label pro Y
        private Label newLabelCombo = null; // Label pro combobox/Button

        private TextBox newDelayTextBox = null;
        private Label newDelayLabel = null;

        private TextBox newKeyTextBox = null;
        private Label newKeyLabel = null;

        private void EditorForm_Load(object sender, EventArgs e)
        {

        }

        private void JsonFileSelectorComboBox_DropDown(object sender, EventArgs e)
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
                EventNamesOnlyList.Controls.Clear(); // Vyčistí panel před přidáním nových událostí
                foreach (var inputEvent in loadedEvents)
                {
                    EventNamesOnlyList.Items.Add(inputEvent.Type);
                }
            }
            else if (JsonFileSelectorComboBox.SelectedItem == null || JsonFileSelectorComboBox.SelectedItem.ToString() == "")
            {
                // vycisti to Table pokud je vybrano prazdne políčko
                EventNamesOnlyList.Controls.Clear();
            }
        }

        private void EventNamesOnlyList_SelectionChanged(object sender, EventArgs e)
        { // tohle se stane pokazdy co se vybere jina vec z toho policka
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new InputEventConverter());
            string selectedFile = Path.Combine(directoryPath, JsonFileSelectorComboBox.SelectedItem.ToString());
            List<IInputEvent> loadedEvents = JsonConvert.DeserializeObject<List<IInputEvent>>(File.ReadAllText(selectedFile), settings);

            if (selectedIndex != -1)
            {
                string selectedItem = EventNamesOnlyList.SelectedItem.ToString();
                HideEveryEventControls(); // Skryjeme prvky související s MouseDown/MouseUp
                switch (selectedItem)
                {
                    case "DelayEvent":
                        ShowDelayEventControls();
                        var delayEvent = loadedEvents[selectedIndex] as DelayEvent;
                        if (delayEvent != null)
                        {
                            // Nastavení textu TextBoxu podle hodnoty z DelayEvent
                            newDelayTextBox.Text = $"{delayEvent.Duration}";
                        }
                        break;

                    case "MouseDown":
                        ShowMouseEventControls();
                        var mouseEvent = loadedEvents[selectedIndex] as MouseDownEvent;
                        if (mouseEvent != null)
                        {
                            newTextBoxX.Text = $"{mouseEvent.X}";
                            newTextBoxY.Text = $"{mouseEvent.Y}";
                            newComboButtonBox.SelectedItem = mouseEvent.Button;
                        }
                        break;
                    case "MouseUp":
                        // Zobrazíme ovládací prvky
                        ShowMouseEventControls();

                        // Získáme data z JSON souboru
                        var mouseEventt = loadedEvents[selectedIndex] as MouseUpEvent;
                        if (mouseEventt != null)
                        {
                            newTextBoxX.Text = $"{mouseEventt.X}";
                            newTextBoxY.Text = $"{mouseEventt.Y}";
                            newComboButtonBox.SelectedItem = mouseEventt.Button;
                        }
                        break;
                    case "KeyDown":
                        ShowKeyEventControls();
                        var keyDownEvent = loadedEvents[selectedIndex] as KeyDownEvent;
                        if (keyDownEvent != null)
                        {
                            // Nastavení textu TextBoxu podle hodnoty z DelayEvent
                            newKeyTextBox.Text = $"{keyDownEvent.Key}";
                        }
                        break;
                    case "KeyUp":
                        ShowKeyEventControls();
                        var keyDownEventt = loadedEvents[selectedIndex] as KeyUpEvent;
                        if (keyDownEventt != null)
                        {
                            // Nastavení textu TextBoxu podle hodnoty z DelayEvent
                            newKeyTextBox.Text = $"{keyDownEventt.Key}";
                        }
                        break;

                    default:
                        // Skryjeme prvky související s MouseDown/MouseUp
                        HideEveryEventControls();
                        break;
                }
            }
        }

        private void ShowMouseEventControls()
        {
            newTextBoxX.Visible = true;
            newTextBoxY.Visible = true;
            newComboButtonBox.Visible = true;
            newLabelX.Visible = true;
            newLabelY.Visible = true;
            newLabelCombo.Visible = true;
        }

        private void ShowDelayEventControls()
        {
            newDelayTextBox.Visible = true;
            newDelayLabel.Visible = true;
        }

        private void ShowKeyEventControls()
        {
            newKeyTextBox.Visible= true;
            newKeyLabel.Visible= true;
        }

        private void HideEveryEventControls()
        {
            //k myši
            newTextBoxX.Visible = false;
            newTextBoxY.Visible = false;
            newComboButtonBox.Visible = false;
            newLabelX.Visible = false;
            newLabelY.Visible = false;
            newLabelCombo.Visible = false;

            //k delay
            newDelayTextBox.Visible = false;
            newDelayLabel.Visible = false;

            //ke key
            newKeyTextBox.Visible = false;
            newKeyLabel.Visible = false;
        }
    }
}
