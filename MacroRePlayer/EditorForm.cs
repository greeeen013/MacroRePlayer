using MacroRePlayer.EventValueForms;
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
        }

        private readonly string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer"); // Cesta k adresáři pro ukládání souborů

        private List<IInputEvent> loadedEvents = new List<IInputEvent>();
        private string selectedFile = "";

        DateTime pressStartTime; // taky kvuli drzeni tlacitka nahoru a dolu

        int dragRow = -1;
        Label dragLabel = null;

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
            if (File.Exists(selectedFile))
            {
                // Pridaní InputEventConverter aby se správně parsovala InputEvent interface  
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new InputEventConverter());

                loadedEvents = JsonConvert.DeserializeObject<List<IInputEvent>>(File.ReadAllText(selectedFile), settings);
                //MessageBox.Show($"{loadedEvents}");  

                // Display the loaded events  
                EditorEventsDataGridView.Rows.Clear(); // Corrected from Items.Clear() to Rows.Clear()  
                foreach (var inputEvent in loadedEvents)
                {
                    string eventName = inputEvent.Type;
                    string eventValue = "";

                    // Determine the value to display based on the event type  
                    switch (inputEvent)
                    {
                        case DelayEvent delayEvent:
                            eventValue = $"Duration: {delayEvent.Duration} ms";
                            break;
                        case MouseDownEvent mouseDownEvent:
                            eventValue = $"X: {mouseDownEvent.X}, Y: {mouseDownEvent.Y}, Button: {mouseDownEvent.Button}";
                            break;
                        case MouseUpEvent mouseUpEvent:
                            eventValue = $"X: {mouseUpEvent.X}, Y: {mouseUpEvent.Y}, Button: {mouseUpEvent.Button}";
                            break;
                        case KeyDownEvent keyDownEvent:
                            eventValue = $"Key: {keyDownEvent.Key}";
                            break;
                        case KeyUpEvent keyUpEvent:
                            eventValue = $"Key: {keyUpEvent.Key}";
                            break;
                    }

                    // Add a new row to the DataGridView  
                    EditorEventsDataGridView.Rows.Add(null, eventName, eventValue, null);
                }
            }
            else if (JsonFileSelectorComboBox.SelectedItem == null || JsonFileSelectorComboBox.SelectedItem.ToString() == "")
            {
                EditorEventsDataGridView.Rows.Clear(); // Vyčistí panel když není vybrán žádný soubor
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFile))
            {
                
            }
        } //tenhle event se spusti kdyz se zmackne save a uloží data do jsonu

        private void EditorEventsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Získání indexu sloupce
            int columnIndex = e.ColumnIndex;

            // Předpokládáme, že EditorEventColumn je na indexu 1 a EditorValueColumn na indexu 2
            if (columnIndex == 1 || columnIndex == 2)
            {
                // Získání dat z řádku
                var selectedRow = EditorEventsDataGridView.Rows[e.RowIndex];
                var eventType = selectedRow.Cells[1].Value?.ToString(); // Typ události
                var eventValue = selectedRow.Cells[2].Value?.ToString(); // Hodnota události

                // Otevření nové formy s předanými hodnotami
                var form = new EventValueForm(eventType, eventValue);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Aktualizuj hodnoty v DataGridView
                    selectedRow.Cells[1].Value = form.SelectedEventType;
                    selectedRow.Cells[2].Value = form.UpdatedEventValue;
                }
            }
        }

        private void EditorEventsDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = EditorEventsDataGridView.HitTest(e.X, e.Y);
            if (hit.RowIndex < 0 || hit.ColumnIndex < 0) return;
            dragRow = hit.RowIndex;
            if (dragLabel == null) dragLabel = new Label();
            dragLabel.Text = EditorEventsDataGridView[hit.ColumnIndex, hit.RowIndex].Value?.ToString();
            dragLabel.Parent = EditorEventsDataGridView;
            dragLabel.Location = e.Location;
        }

        private void EditorEventsDataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragLabel != null)
            {
                dragLabel.Location = e.Location;
                EditorEventsDataGridView.ClearSelection();
            }
        }

        private void EditorEventsDataGridView_DragOver(object sender, DragEventArgs e)
        {
            // Allow move effect during drag-and-drop
            e.Effect = DragDropEffects.Move;
        }

        private void EditorEventsDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void EditorEventsDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            var hit = EditorEventsDataGridView.HitTest(e.X, e.Y);
            int dropRow = -1;
            if (hit.Type != DataGridViewHitTestType.None)
            {
                dropRow = hit.RowIndex;
                if (dragRow >= 0)
                {
                    int tgtRow = dropRow + (dragRow > dropRow ? 1 : 0);
                    if (tgtRow != dragRow)
                    {
                        DataGridViewRow row = EditorEventsDataGridView.Rows[dragRow];
                        EditorEventsDataGridView.Rows.Remove(row);
                        EditorEventsDataGridView.Rows.Insert(tgtRow, row);

                        EditorEventsDataGridView.ClearSelection();
                        row.Selected = true;
                    }
                }
            }
            else { EditorEventsDataGridView.Rows[dragRow].Selected = true; }

            if (dragLabel != null)
            {
                dragLabel.Dispose();
                dragLabel = null;
            }
        }






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