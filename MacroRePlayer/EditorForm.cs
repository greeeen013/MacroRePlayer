using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            newComboBoxForButton = new ComboBox { Location = new Point(50, 70), Width = 200, Visible = false, DropDownStyle = ComboBoxStyle.DropDownList };
            newComboBoxForButton.Items.AddRange(new string[] { "Left", "Right", "Middle" });

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
            this.Controls.Add(newComboBoxForButton);
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
        private ComboBox newComboBoxForButton = null; // ComboBox pro výběr tlačítka
        private Label newLabelX = null; // Label pro X
        private Label newLabelY = null; // Label pro Y
        private Label newLabelCombo = null; // Label pro combobox/Button

        private TextBox newDelayTextBox = null;
        private Label newDelayLabel = null;

        private TextBox newKeyTextBox = null;
        private Label newKeyLabel = null;

        private List<IInputEvent> loadedEvents = new List<IInputEvent>();
        private string selectedFile = "";

        bool isHolding = false; // kvuli drzeni tlacitka nahoru a dolu
        DateTime pressStartTime; // taky kvuli drzeni tlacitka nahoru a dolu

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
        } //event kterej se spustí když se otevře combobox a naplní ho dostupnejma jsonama

        private void JsonFileSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Načtení vybraného souboru a jeho zobrazení
            selectedFile = Path.Combine(directoryPath, JsonFileSelectorComboBox.SelectedItem.ToString());
            EventNamesOnlyList.Items.Clear(); // Vyčistí panel před přidáním nových událostí (bez toho to nefunguje)
            if (File.Exists(selectedFile))
            {
                // Pridaní InputEventConverter aby se správně parsovala InputEvent interface
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new InputEventConverter());

                loadedEvents = JsonConvert.DeserializeObject<List<IInputEvent>>(File.ReadAllText(selectedFile), settings);
                //MessageBox.Show($"{loadedEvents}");

                // Display the loaded events
                EventNamesOnlyList.Controls.Clear(); // Vyčistí panel před přidáním nových událostí
                foreach (var inputEvent in loadedEvents)
                {
                    EventNamesOnlyList.Items.Add(inputEvent.Type);
                }
                EditorFormActivateControlButtons(); // Aktivace tlačítek pro editaci listu
            }
            else if (JsonFileSelectorComboBox.SelectedItem == null || JsonFileSelectorComboBox.SelectedItem.ToString() == "")
            {
                EventNamesOnlyList.Items.Clear(); // Vyčistí panel pokud bylo vybrano prazdno
                EditorFormDeactivateControlButtons(); // Deaktivace tlačítek pro editaci listu

            }
        } //event kterej se spustí pokud se změní vybranej soubor v comboboxu a vypíše eventy do listu

        private void EditorFormActivateControlButtons()
        {
            // Aktivace tlačítek pro přidání události
            EditorFormButtonAdd.Enabled = true;
            EditorFormButtonDelete.Enabled = true;
            EditorFormButtonCopy.Enabled = true;
            EditorFormButtonExtract.Enabled = true;
            EditorFormButtonPaste.Enabled = true;
            EditorFormButtonUp.Enabled = true;
            EditorFormButtonDown.Enabled = true;
            EditorFormButtonSave.Enabled = true;
        } //aktivace tlačítek pro editaci listu

        private void EditorFormDeactivateControlButtons()
        {
            // Deaktivace tlačítek pro editaci listu
            EditorFormButtonAdd.Enabled = false;
            EditorFormButtonDelete.Enabled = false;
            EditorFormButtonCopy.Enabled = false;
            EditorFormButtonExtract.Enabled = false;
            EditorFormButtonPaste.Enabled = false;
            EditorFormButtonUp.Enabled = false;
            EditorFormButtonDown.Enabled = false;
            EditorFormButtonSave.Enabled = false;
        } //deaktivace tlačítek pro editaci listu

        private void EventNamesOnlyList_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;

            if (selectedIndex != -1)
            {
                string selectedItem = EventNamesOnlyList.SelectedItem.ToString();
                HideEveryEventControls(); // Skryjeme prvky související s MouseDown/MouseUp
                switch (selectedItem)
                {
                    case "DelayEvent":
                        ShowDelayEventControls(); // Zobrazíme ovládací prvky pouze pro DelayEvent
                        var delayEvent = loadedEvents[selectedIndex] as DelayEvent;
                        if (delayEvent != null)
                        {
                            // Nastavení textu TextBoxu podle hodnoty z DelayEvent
                            newDelayTextBox.TextChanged -= DelayTextBox_TextChanged;
                            newDelayTextBox.Text = $"{delayEvent.Duration}";
                            newDelayTextBox.TextChanged += DelayTextBox_TextChanged;
                        }
                        break;
                    case "MouseDown":
                        ShowMouseEventControls();
                        var mouseEvent = loadedEvents[selectedIndex] as MouseDownEvent;
                        if (mouseEvent != null)
                        {
                            newTextBoxX.TextChanged -= MouseDownTextBox_TextChanged;
                            newTextBoxY.TextChanged -= MouseDownTextBox_TextChanged;
                            newComboBoxForButton.SelectedIndexChanged -= MouseDownTextBox_TextChanged;

                            newTextBoxX.Text = $"{mouseEvent.X}";
                            newTextBoxY.Text = $"{mouseEvent.Y}";
                            newComboBoxForButton.SelectedItem = mouseEvent.Button;

                            newTextBoxX.TextChanged += MouseDownTextBox_TextChanged;
                            newTextBoxY.TextChanged += MouseDownTextBox_TextChanged;
                            newComboBoxForButton.SelectedIndexChanged += MouseDownTextBox_TextChanged;
                        }
                        break;
                    case "MouseUp":
                        // Zobrazíme ovládací prvky
                        ShowMouseEventControls();

                        // Získáme data z JSON souboru
                        var mouseEventt = loadedEvents[selectedIndex] as MouseUpEvent;
                        if (mouseEventt != null)
                        {
                            newTextBoxX.TextChanged -= MouseUpTextBox_TextChanged;
                            newTextBoxY.TextChanged -= MouseUpTextBox_TextChanged;
                            newComboBoxForButton.SelectedIndexChanged -= MouseUpTextBox_TextChanged;

                            newTextBoxX.Text = $"{mouseEventt.X}";
                            newTextBoxY.Text = $"{mouseEventt.Y}";
                            newComboBoxForButton.SelectedItem = mouseEventt.Button;

                            newTextBoxX.TextChanged += MouseUpTextBox_TextChanged;
                            newTextBoxY.TextChanged += MouseUpTextBox_TextChanged;
                            newComboBoxForButton.SelectedIndexChanged += MouseUpTextBox_TextChanged;
                        }
                        break;
                    case "KeyDown":
                        ShowKeyEventControls();
                        var keyDownEvent = loadedEvents[selectedIndex] as KeyDownEvent;
                        if (keyDownEvent != null)
                        {
                            // Nastavení textu TextBoxu podle hodnoty z DelayEvent
                            newKeyTextBox.TextChanged -= KeyDownTextBox_TextChanged;
                            newKeyTextBox.Text = $"{keyDownEvent.Key}";
                            newKeyTextBox.TextChanged += KeyDownTextBox_TextChanged;
                        }
                        break;
                    case "KeyUp":
                        ShowKeyEventControls();
                        var keyUpEvent = loadedEvents[selectedIndex] as KeyUpEvent;
                        if (keyUpEvent != null)
                        {
                            // Nastavení textu TextBoxu podle hodnoty z DelayEvent
                            newKeyTextBox.TextChanged -= KeyUpTextBox_TextChanged;
                            newKeyTextBox.Text = $"{keyUpEvent.Key}";
                            newKeyTextBox.TextChanged += KeyUpTextBox_TextChanged;
                        }
                        break;

                    default:
                        // Skryjeme prvky související s MouseDown/MouseUp
                        HideEveryEventControls();
                        break;
                }
            }
        } //event kterej se spusti kdyz se změní selectnutej index v listu a podle toho se nastaví ovládací prvky(textboxy, comboboxy atd.) a jejich hodnoty

        private void DelayTextBox_TextChanged(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex != -1)
            {
                var delayEvent = loadedEvents[selectedIndex] as DelayEvent;
                if (delayEvent != null)
                {
                    if (string.IsNullOrEmpty(newDelayTextBox.Text))
                    {
                        delayEvent.Duration = 0;
                    }
                    else
                    {
                        delayEvent.Duration = int.Parse(newDelayTextBox.Text);
                    }
                }
            }
        } //tenhle event se volá v EventNamesOnlyList_SelectionChanged spusti kdyz se změní text v delay textboxu a nastaví hodnotu do delayEventu

        private void MouseDownTextBox_TextChanged(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex != -1)
            {
                var mouseEvent = loadedEvents[selectedIndex] as MouseDownEvent;
                if (mouseEvent != null)
                {
                    if (string.IsNullOrEmpty(newTextBoxX.Text))
                    {
                        mouseEvent.X = 0;
                    }
                    else
                    {
                        mouseEvent.X = int.Parse(newTextBoxX.Text);
                    }

                    if (string.IsNullOrEmpty(newTextBoxY.Text))
                    {
                        mouseEvent.Y = 0;
                    }
                    else
                    {
                        mouseEvent.Y = int.Parse(newTextBoxY.Text);
                    }

                    mouseEvent.Button = newComboBoxForButton.SelectedItem?.ToString();
                }
            }
        } //tenhle event se volá v EventNamesOnlyList_SelectionChanged se spusti kdyz se změní text v textboxu a nastaví hodnotu do MouseDownEventu

        private void MouseUpTextBox_TextChanged(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex != -1)
            {
                var mouseEvent = loadedEvents[selectedIndex] as MouseUpEvent;
                if (mouseEvent != null)
                {
                    if (string.IsNullOrEmpty(newTextBoxX.Text))
                    {
                        mouseEvent.X = 0;
                    }
                    else
                    {
                        mouseEvent.X = int.Parse(newTextBoxX.Text);
                    }

                    if (string.IsNullOrEmpty(newTextBoxY.Text))
                    {
                        mouseEvent.Y = 0;
                    }
                    else
                    {
                        mouseEvent.Y = int.Parse(newTextBoxY.Text);
                    }

                    mouseEvent.Button = newComboBoxForButton.SelectedItem?.ToString();
                }
            }
        } //tenhle event se volá v EventNamesOnlyList_SelectionChanged se spusti kdyz se změní text v textboxu a nastaví hodnotu do MouseUpEventu

        private void KeyDownTextBox_TextChanged(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex != -1)
            {
                var keyEvent = loadedEvents[selectedIndex] as KeyDownEvent;
                if (keyEvent != null)
                {
                    keyEvent.Key = string.IsNullOrEmpty(newKeyTextBox.Text) ? null : newKeyTextBox.Text;
                }
            }
        } //tenhle event se volá v EventNamesOnlyList_SelectionChanged se spusti kdyz se změní text v textboxu a nastaví hodnotu do KeyDownEventu

        private void KeyUpTextBox_TextChanged(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex != -1)
            {
                var keyEvent = loadedEvents[selectedIndex] as KeyUpEvent;
                if (keyEvent != null)
                {
                    keyEvent.Key = string.IsNullOrEmpty(newKeyTextBox.Text) ? null : newKeyTextBox.Text;
                }
            }
        } //tenhle event se volá v EventNamesOnlyList_SelectionChanged se spusti kdyz se změní text v textboxu a nastaví hodnotu do KeyUpEventu

        private void ShowMouseEventControls()
        {
            newTextBoxX.Visible = true;
            newTextBoxY.Visible = true;
            newComboBoxForButton.Visible = true;
            newLabelX.Visible = true;
            newLabelY.Visible = true;
            newLabelCombo.Visible = true;
        } //zobrazí ovládací prvky pro myš (X, Y, ComboBox pro mouse button, Label)

        private void ShowDelayEventControls()
        {
            newDelayTextBox.Visible = true;
            newDelayLabel.Visible = true;
        } //zobrazí ovládací prvky pro delay (TextBox, Label)

        private void ShowKeyEventControls()
        {
            newKeyTextBox.Visible = true;
            newKeyLabel.Visible = true;
        } //zobrazí ovládací prvky pro klávesnici (TextBox, Label)

        private void HideEveryEventControls()
        {
            //k myši
            newTextBoxX.Visible = false;
            newTextBoxY.Visible = false;
            newComboBoxForButton.Visible = false;
            newLabelX.Visible = false;
            newLabelY.Visible = false;
            newLabelCombo.Visible = false;

            //k delay
            newDelayTextBox.Visible = false;
            newDelayLabel.Visible = false;

            //ke key
            newKeyTextBox.Visible = false;
            newKeyLabel.Visible = false;
        } //skryje všechny ovládací prvky (k myši, k delay, k key) aby se nezobrazovali když je nevybranej event

        private void Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFile))
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new InputEventConverter());

                // Update the loadedEvents with the current values from the UI


                // Sort the events by their order in the list
                var sortedEvents = EventNamesOnlyList.Items.Cast<string>()
                    .Select((item, index) => new { item, index })
                    .Select(x => loadedEvents[x.index])
                    .ToList();

                string json = JsonConvert.SerializeObject(sortedEvents, Formatting.Indented);
                File.WriteAllText(selectedFile, json);
                MessageBox.Show("Data byla úspěšně uložena!");
            }
        } //tenhle event se spusti kdyz se zmackne save a uloží data do jsonu

        private void MoveSelectedIndexUp()
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex > 0)
            {
                var selectedItem = EventNamesOnlyList.SelectedItem;
                EventNamesOnlyList.Items.RemoveAt(selectedIndex);
                EventNamesOnlyList.Items.Insert(selectedIndex - 1, selectedItem);
                EventNamesOnlyList.SelectedIndex = selectedIndex - 1;

                var selectedEvent = loadedEvents[selectedIndex];
                loadedEvents.RemoveAt(selectedIndex);
                loadedEvents.Insert(selectedIndex - 1, selectedEvent);
                EventNamesOnlyList_SelectionChanged(null, EventArgs.Empty);
            }
        } // posune selectnutej prvek o 1 místo nahoru

        private void MoveSelectedIndexToTop()
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex > 0)
            {
                var selectedItem = EventNamesOnlyList.SelectedItem;
                EventNamesOnlyList.Items.RemoveAt(selectedIndex);
                EventNamesOnlyList.Items.Insert(0, selectedItem);
                EventNamesOnlyList.SelectedIndex = 0;

                var selectedEvent = loadedEvents[selectedIndex];
                loadedEvents.RemoveAt(selectedIndex);
                loadedEvents.Insert(0, selectedEvent);
                EventNamesOnlyList_SelectionChanged(null, EventArgs.Empty);
            }
        } //posune selectnutej prvek uplne nahoru

        private void EditorFormButtonUp_MouseDown(object sender, MouseEventArgs e)
        {
            pressStartTime = DateTime.Now;
            isHolding = true;
            HoldTimer.Start();
        } //tenhle event se spusti kdyz se zmackne tlačítko nahoru myšítkem a jestli je držený

        private void EditorFormButtonUp_MouseUp(object sender, MouseEventArgs e)
        {
            isHolding = false;
            HoldTimer.Stop();

            if ((DateTime.Now - pressStartTime) < TimeSpan.FromMilliseconds(HoldTimer.Interval)) //pokud je to rychleji nez interval tak to posune nahoru
            {
                MoveSelectedIndexUp();
            }
            else
            {
                MoveSelectedIndexToTop();
            }
        } //tenhle event se spusti kdyz se odzmackne tlačítko nahoru myšítkem

        private void MoveSelectedIndexToBottom()
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex < EventNamesOnlyList.Items.Count - 1)
            {
                var selectedItem = EventNamesOnlyList.SelectedItem;
                EventNamesOnlyList.Items.RemoveAt(selectedIndex);
                EventNamesOnlyList.Items.Insert(EventNamesOnlyList.Items.Count, selectedItem);
                EventNamesOnlyList.SelectedIndex = EventNamesOnlyList.Items.Count - 1;
                var selectedEvent = loadedEvents[selectedIndex];
                loadedEvents.RemoveAt(selectedIndex);
                loadedEvents.Insert(loadedEvents.Count, selectedEvent);
                EventNamesOnlyList_SelectionChanged(null, EventArgs.Empty);
            }
        } //posune selectnutej prvek o 1 místo dolu

        private void MoveSelectedIndexDown()
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex < EventNamesOnlyList.Items.Count - 1)
            {
                var selectedItem = EventNamesOnlyList.SelectedItem;
                EventNamesOnlyList.Items.RemoveAt(selectedIndex);
                EventNamesOnlyList.Items.Insert(selectedIndex + 1, selectedItem);
                EventNamesOnlyList.SelectedIndex = selectedIndex + 1;

                var selectedEvent = loadedEvents[selectedIndex];
                loadedEvents.RemoveAt(selectedIndex);
                loadedEvents.Insert(selectedIndex + 1, selectedEvent);
                EventNamesOnlyList_SelectionChanged(null, EventArgs.Empty); // idk jestli to tu je needed, ale kdyz to tam neni a swapnu mezi stejnymi eventy se spatne prohodi cisla (pouze pri zobrazeni funcknost fungovala spravne)
            }
        } //posune selectnutej prvek uplně na konec listu

        private void EditorFormButtonDown_MouseDown(object sender, MouseEventArgs e)
        {
            pressStartTime = DateTime.Now;
            isHolding = true;
            HoldTimer.Start();
        } //tenhle event se spusti kdyz se zmackne tlačítko dolu myšítkem a jestli je držený

        private void EditorFormButtonDown_MouseUp(object sender, MouseEventArgs e)
        {
            isHolding = false;
            HoldTimer.Stop();

            if ((DateTime.Now - pressStartTime) < TimeSpan.FromMilliseconds(HoldTimer.Interval)) //pokud je to rychleji nez interval tak to posune nahoru
            {
                MoveSelectedIndexDown();
            }
            else
            {
                MoveSelectedIndexToBottom();
            }
        } //tenhle event se spusti kdyz se odzmackne tlačítko dolu myšítkem

        private void EditorFormButtonDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex != -1)
            {
                EventNamesOnlyList.Items.RemoveAt(selectedIndex);
                loadedEvents.RemoveAt(selectedIndex);
                EventNamesOnlyList_SelectionChanged(null, EventArgs.Empty);
            }
        } //tenhle event se spusti kdyz se zmackne delete a smaže selectnutej index

        private void EditorFormButtonCopy_Click(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex != -1)
            {
                var selectedEvent = loadedEvents[selectedIndex];
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                string json = JsonConvert.SerializeObject(selectedEvent, settings);
                Clipboard.SetText(json);
            }
        } //tenhle event se spusti kdyz se zmackne copy a zkopíruje selectnutej index do clipboardu

        private void EditorFormButtonExtract_Click(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            if (selectedIndex != -1)
            {
                var selectedEvent = loadedEvents[selectedIndex];
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                string json = JsonConvert.SerializeObject(selectedEvent, settings);
                Clipboard.SetText(json);

                EventNamesOnlyList.Items.RemoveAt(selectedIndex);
                loadedEvents.RemoveAt(selectedIndex);
                EventNamesOnlyList_SelectionChanged(null, EventArgs.Empty);
            }
        } //tenhle event se spusti kdyz se zmackne extract a zkopíruje selectnutej index do clipboardu a smaže ho z listu (prakticky výjmout)

        private void EditorFormButtonPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string json = Clipboard.GetText();
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new InputEventConverter());

                try
                {
                    var pastedEvent = JsonConvert.DeserializeObject<IInputEvent>(json, settings);
                    if (pastedEvent != null)
                    {
                        int selectedIndex = EventNamesOnlyList.SelectedIndex;
                        if (selectedIndex != -1)
                        {
                            loadedEvents.Insert(selectedIndex + 1, pastedEvent);
                            EventNamesOnlyList.Items.Insert(selectedIndex + 1, pastedEvent.Type);
                            EventNamesOnlyList.SelectedIndex = selectedIndex + 1;
                        }
                        else
                        {
                            loadedEvents.Add(pastedEvent);
                            EventNamesOnlyList.Items.Add(pastedEvent.Type);
                            EventNamesOnlyList.SelectedIndex = EventNamesOnlyList.Items.Count - 1;
                        }

                        // Update the UI controls based on the pasted event
                        EventNamesOnlyList_SelectionChanged(null, EventArgs.Empty);
                    }
                }
                catch (JsonException ex)
                {
                    MessageBox.Show("Invalid event data in clipboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        } //tenhle event se spusti kdyz se zmackne paste a vloží event z clipboardu do listu pod selectnutej index

        private void EditorFormButtonAdd_Click(object sender, EventArgs e)
        {
            EditorFormContextMenuEvents.Show(EditorFormButtonAdd, 70, 0);
        } //tenhle event se spusti kdyz se zmackne add a otevře se context menu s eventama

        private void delayEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            var newDelayEvent = new DelayEvent { Duration = 0 };

            if (selectedIndex != -1)
            {
                loadedEvents.Insert(selectedIndex + 1, newDelayEvent);
                EventNamesOnlyList.Items.Insert(selectedIndex + 1, newDelayEvent.Type);
                EventNamesOnlyList.SelectedIndex = selectedIndex + 1;
            }
            else
            {
                loadedEvents.Add(newDelayEvent);
                EventNamesOnlyList.Items.Add(newDelayEvent.Type);
                EventNamesOnlyList.SelectedIndex = EventNamesOnlyList.Items.Count - 1;
            }

            ShowDelayEventControls();
            newDelayTextBox.Text = string.Empty;
            newDelayTextBox.Focus();
        } //tenhle event se spusti kdyz se vybere DelayEvent z context menu strip a prida DelayEvent do listu

        private void mouseDownEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            var newMouseDownEvent = new MouseDownEvent { X = 0, Y = 0, Button = "Left" };

            if (selectedIndex != -1)
            {
                loadedEvents.Insert(selectedIndex + 1, newMouseDownEvent);
                EventNamesOnlyList.Items.Insert(selectedIndex + 1, newMouseDownEvent.Type);
                EventNamesOnlyList.SelectedIndex = selectedIndex + 1;
            }
            else
            {
                loadedEvents.Add(newMouseDownEvent);
                EventNamesOnlyList.Items.Add(newMouseDownEvent.Type);
                EventNamesOnlyList.SelectedIndex = EventNamesOnlyList.Items.Count - 1;
            }

            ShowMouseEventControls();
            newTextBoxX.Text = string.Empty;
            newTextBoxY.Text = string.Empty;
            newComboBoxForButton.SelectedItem = "Left";
            newTextBoxX.Focus();
        } //tenhle event se spusti kdyz se vybere MouseUpEvent z context menu strip a prida MouseDownEvent do listu

        private void mouseUpEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            var newMouseUpEvent = new MouseUpEvent { X = 0, Y = 0, Button = "Left" };

            if (selectedIndex != -1)
            {
                loadedEvents.Insert(selectedIndex + 1, newMouseUpEvent);
                EventNamesOnlyList.Items.Insert(selectedIndex + 1, newMouseUpEvent.Type);
                EventNamesOnlyList.SelectedIndex = selectedIndex + 1;
            }
            else
            {
                loadedEvents.Add(newMouseUpEvent);
                EventNamesOnlyList.Items.Add(newMouseUpEvent.Type);
                EventNamesOnlyList.SelectedIndex = EventNamesOnlyList.Items.Count - 1;
            }

            ShowMouseEventControls();
            newTextBoxX.Text = string.Empty;
            newTextBoxY.Text = string.Empty;
            newComboBoxForButton.SelectedItem = "Left";
            newTextBoxX.Focus();
        } //tenhle event se spusti kdyz se vybere MouseUpEvent z context menu strip a prida MouseUpEvent do listu

        private void keyDownEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            var newKeyDownEvent = new KeyDownEvent { Key = string.Empty };

            if (selectedIndex != -1)
            {
                loadedEvents.Insert(selectedIndex + 1, newKeyDownEvent);
                EventNamesOnlyList.Items.Insert(selectedIndex + 1, newKeyDownEvent.Type);
                EventNamesOnlyList.SelectedIndex = selectedIndex + 1;
            }
            else
            {
                loadedEvents.Add(newKeyDownEvent);
                EventNamesOnlyList.Items.Add(newKeyDownEvent.Type);
                EventNamesOnlyList.SelectedIndex = EventNamesOnlyList.Items.Count - 1;
            }

            ShowKeyEventControls();
            newKeyTextBox.Text = string.Empty;
            newKeyTextBox.Focus();
        } //tenhle event se spusti kdyz se vybere KeyDownEvent z context menu strip a prida KeyDownEvent do listu

        private void keyUpEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = EventNamesOnlyList.SelectedIndex;
            var newKeyUpEvent = new KeyUpEvent { Key = string.Empty };

            if (selectedIndex != -1)
            {
                loadedEvents.Insert(selectedIndex + 1, newKeyUpEvent);
                EventNamesOnlyList.Items.Insert(selectedIndex + 1, newKeyUpEvent.Type);
                EventNamesOnlyList.SelectedIndex = selectedIndex + 1;
            }
            else
            {
                loadedEvents.Add(newKeyUpEvent);
                EventNamesOnlyList.Items.Add(newKeyUpEvent.Type);
                EventNamesOnlyList.SelectedIndex = EventNamesOnlyList.Items.Count - 1;
            }

            ShowKeyEventControls();
            newKeyTextBox.Text = string.Empty;
            newKeyTextBox.Focus();

        } //tenhle event se spusti kdyz se vybere KeyUpEvent z context menu strip a prida KeyUpEvent do listu

        //TODO: pridat start cyklus (s počtem) tlacitko (a asi i s ID)
        //TODO: pridat konec cyklu tlacitko (s ID)

        //done: funkčnost copy
        //done: funkčnost paste
        //done: pridat funkčnost extract
        //TODO: pridat ošetření aby v textboxu bylo pouze číslo pokud se jedna o souřadnice (a aby to nehodilo error když tam bude něco jinýho)
        //done: pridat delete tlačítko
        //done: pridat posun na konec tlacitko a uplne nahoru (mozna bych to dal kdyz podrzim tu default sipku nahoru a dolu tak se to posune uplne nahoru nebo dolu)
        //done: fixnout kdyz posouvam se stejnym eventem nejako se dojebavaj hodnoty
        //done: fixnout kdyz odmazu pismeno (mozna i cislici) tka to hodi error !!! WORKING ON IT
        //done: fixnout json file selector kdyz zmenim ten file na jinaci file tak se nezmeni ta tabulka

        //TODO: dodelat player
        //TODO: udelat to cely nejako hezky
    }
}