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

        private readonly List<IInputEvent> loadedEvents = [];
        private string selectedFile = "";

        private int dragRow = -1;
        private Label? dragLabel = null;
        private Point mouseDownLocation;
        private bool isDragging = false;

        private void EditorForm_Load(object sender, EventArgs e)
        {

        }

        private void JsonFileSelectorComboBox_DropDown(object sender, EventArgs e)
        {
            // Naplnění seznamu dostupných JSON souborů
            JsonFileSelectorComboBox.Items.Clear();

            // Přidání prázdné položky na začátek
            JsonFileSelectorComboBox.Items.Add("");

            if (Directory.Exists(directoryPath)) // zkontroluje jestli existuje adresář
            {
                JsonFileSelectorComboBox.Items.AddRange( // přidá všechny soubory do comboboxu
                [.. Directory.GetFiles(directoryPath, "*.json") // získá všechny json soubory
                .Select(filePath => Path.GetFileName(filePath) ?? string.Empty)] // převede na pole
                );
            }
        } //event kterej se spustí když se otevře combobox a naplní ho dostupnejma jsonama

        private void JsonFileSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Načtení vybraného souboru a jeho zobrazení  
            selectedFile = Path.Combine( // sestavení cesty k souboru
            directoryPath, // adresář
            JsonFileSelectorComboBox.SelectedItem?.ToString() ?? string.Empty // název souboru převedený na string
            );
            if (File.Exists(selectedFile))
            {
                // Pridaní InputEventConverter aby se správně parsovala InputEvent interface  
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new InputEventConverter());

                List<IInputEvent>? loadedEvents = JsonConvert.DeserializeObject<List<IInputEvent>>(File.ReadAllText(selectedFile), settings) ?? []; ;
                //MessageBox.Show($"{loadedEvents}");  

                EditorEventsDataGridView.Rows.Clear();
                foreach (var inputEvent in loadedEvents)
                {
                    string eventName = inputEvent.Type;
                    string eventValue = "";
                    string? secretValue = null; // Default to null if not provided

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
                            secretValue = keyDownEvent.Code;
                            break;
                        case KeyUpEvent keyUpEvent:
                            eventValue = $"Key: {keyUpEvent.Key}";
                            secretValue = keyUpEvent.Code;
                            break;
                    }

                    EditorEventsDataGridView.Rows.Add(null, eventName, eventValue, secretValue, null);
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
                var eventsToSave = new List<object>();

                foreach (DataGridViewRow row in EditorEventsDataGridView.Rows)
                {
                    if (row.Cells[1].Value == null || row.Cells[2].Value == null)
                        continue;

                    string? eventType = row.Cells[1].Value.ToString(); // to ošetření s otazníkem by v budoucnu mělo být zbytečný TODO
                    string? eventValue = row.Cells[2].Value.ToString();
                    string? secretValue = row.Cells[3]?.Value?.ToString();

                    switch (eventType) // všechny otazníky by mohly pryč v budoucnu TODO
                    {
                        case "DelayEvent":
                            if (int.TryParse((eventValue ?? "").Replace("Duration: ", "").Replace(" ms", ""), out int duration))
                            {
                                eventsToSave.Add(new { Type = "DelayEvent", Duration = duration });
                            }
                            break;
                        case "MouseDown":
                        case "MouseUp":
                            var mouseParts = (eventValue ?? "").Split([", "], StringSplitOptions.None);
                            if (mouseParts.Length == 3 &&
                                int.TryParse(mouseParts[0].Replace("X: ", ""), out int x) &&
                                int.TryParse(mouseParts[1].Replace("Y: ", ""), out int y))
                            {
                                string button = mouseParts[2].Replace("Button: ", "");
                                eventsToSave.Add(new { Type = eventType, X = x, Y = y, Button = button });
                            }
                            break;
                        case "KeyDown":
                        case "KeyUp":
                            if (!string.IsNullOrEmpty(secretValue))
                            {
                                string key = (eventValue ?? "").Replace("Key: ", "");
                                eventsToSave.Add(new { Type = eventType, Key = key, Code = secretValue });
                            }
                            break;
                        default: break;
                    }
                }

                var json = JsonConvert.SerializeObject(eventsToSave, Formatting.Indented);
                File.WriteAllText(selectedFile, json);
                MessageBox.Show("File saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No file selected to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                var form = new EventValueForm(eventType ?? "", eventValue ?? "");

                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Aktualizuj hodnoty v DataGridView
                    selectedRow.Cells[1].Value = form.SelectedEventType;
                    selectedRow.Cells[2].Value = form.UpdatedEventValue;
                    selectedRow.Cells[3].Value = form.UpdateSecretValue; // Nastavení hodnoty na null pro další použití
                }
            }
        }

        private void EditorEventsDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = EditorEventsDataGridView.HitTest(e.X, e.Y);
            if (hit.RowIndex < 0 || hit.ColumnIndex < 0) return;

            mouseDownLocation = e.Location;
            dragRow = hit.RowIndex;
            isDragging = false; // ještě nezačalo tažení

            dragLabel ??= new Label();
            dragLabel.Text = EditorEventsDataGridView[hit.ColumnIndex, hit.RowIndex].Value?.ToString();
            dragLabel.Parent = EditorEventsDataGridView;
            dragLabel.Location = e.Location;
            dragLabel.Visible = false; // schováme, zobrazíme až při skutečném tažení
        }

        private void EditorEventsDataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragLabel != null)
            {
                int dx = Math.Abs(e.X - mouseDownLocation.X);
                int dy = Math.Abs(e.Y - mouseDownLocation.Y);

                if (!isDragging && (dx > 5 || dy > 5)) // spustíme tažení
                {
                    isDragging = true;
                    dragLabel.Visible = true;
                    EditorEventsDataGridView.ClearSelection(); // nevybíráme během drag
                }

                if (isDragging)
                {
                    dragLabel.Location = e.Location;
                }
            }
        }

        private void EditorEventsDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var hit = EditorEventsDataGridView.HitTest(e.X, e.Y);
                int dropRow;
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
                else
                {
                    EditorEventsDataGridView.Rows[dragRow].Selected = true;
                }
            }

            // Resetujeme stav
            if (dragLabel != null)
            {
                dragLabel.Dispose();
                dragLabel = null;
            }

            isDragging = false;
        }

        private void EditorEventsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (isDragging)
            {
                EditorEventsDataGridView.ClearSelection();
            }
        }




        //TODO: opravit scrollovani v DataGridView když držím prvek

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