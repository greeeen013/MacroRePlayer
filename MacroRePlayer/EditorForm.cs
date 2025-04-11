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

        private int dragRow = -1; // index řádku, který se táhne
        private Label? dragLabel = null; // label pro drag and drop (když se něco táhne)
        private Point mouseDownLocation; // pozice myši při stisknutí tlačítka
        private bool isDragging = false; // označuje, zda je prvek tažen

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
                var settings = new JsonSerializerSettings(); // nastavení pro JsonSerializer
                settings.Converters.Add(new InputEventConverter()); // přidání konvertoru pro deserializaci událostí

                List<IInputEvent>? loadedEvents = JsonConvert.DeserializeObject<List<IInputEvent>>(File.ReadAllText(selectedFile), settings) ?? []; // načtení souboru a deserializace do seznamu událostí 

                EditorEventsDataGridView.Rows.Clear();
                foreach (var inputEvent in loadedEvents)
                {
                    string eventName = inputEvent.Type; // název události
                    string eventValue = ""; // hodnota události
                    string? secretValue = null; // hodnota pro skrytí když není potřeba tak to zapíše null

                    switch (inputEvent) // podle typu události nastaví hodnotu
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
        } // event kterej se spustí když se vybere soubor a naplní ho do tabulky

        private void Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFile))
            {
                var eventsToSave = new List<object>();

                foreach (DataGridViewRow row in EditorEventsDataGridView.Rows)
                {
                    if (row.Cells[1].Value == null || row.Cells[2].Value == null)
                        continue;

                    string? eventType = row.Cells[1].Value.ToString();
                    string? eventValue = row.Cells[2].Value.ToString();
                    string? secretValue = row.Cells[3]?.Value?.ToString();

                    switch (eventType)
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
        } // uložení souboru

        private void EditorEventsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex; // Získání indexu sloupce  
            int rowIndex = e.RowIndex; // Získání indexu řádku  

            // Ověření, že není kliknuto na hlavičku nebo neplatný řádek  
            if (rowIndex < 0 || columnIndex < 0)
                return;

            if (EditorEventsDataGridView.Columns[columnIndex].Name == "EditorEventColumn" || EditorEventsDataGridView.Columns[columnIndex].Name == "EditorValueColumn") // pokud je kliknuto na sloupec s událostí nebo hodnotou  
            {
                var selectedRow = EditorEventsDataGridView.Rows[rowIndex]; // Získání dat z řádku  
                var eventType = selectedRow.Cells[1].Value?.ToString(); // Typ události  
                var eventValue = selectedRow.Cells[2].Value?.ToString(); // Hodnota události  

                var form = new EventValueForm(eventType ?? "", eventValue ?? ""); // Otevření nové formy s předanými hodnotami  

                this.Enabled = false; // zakáže editor formulář  

                if (form.ShowDialog() == DialogResult.OK) // pokud uživatel potvrdí změny  
                {
                    // Aktualizuj hodnoty v DataGridView  
                    selectedRow.Cells[1].Value = form.SelectedEventType;
                    selectedRow.Cells[2].Value = form.UpdatedEventValue;
                    selectedRow.Cells[3].Value = form.UpdateSecretValue; // Nastavení hodnoty na null pro další použití  
                }
            }
            this.Enabled = true; // povolí editor formulář  
        } // událost dvojitého kliknutí na buňku v DataGridView  

        private void EditorEventsDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = EditorEventsDataGridView.HitTest(e.X, e.Y); // získání informací o tom, co bylo kliknuto
            if (hit.RowIndex < 0 || hit.ColumnIndex < 0) return; // pokud není kliknuto na platnou buňku, nic nedělej

            mouseDownLocation = e.Location; // uložení pozice myši
            dragRow = hit.RowIndex; // uložení indexu řádku, který byl kliknut
            isDragging = false; // ještě nezačalo tažení

            dragLabel ??= new Label(); // vytvoření nového labelu pro drag and drop
            dragLabel.Text = EditorEventsDataGridView[hit.ColumnIndex, hit.RowIndex].Value?.ToString(); // text labelu je hodnota buňky
            dragLabel.Parent = EditorEventsDataGridView; // label je podřízený DataGridView
            dragLabel.Location = e.Location; // nastavení pozice labelu na pozici myši
            dragLabel.Visible = false; // schováme, zobrazíme až při skutečném tažení
        } // událost stisknutí myši na DataGridView

        private void EditorEventsDataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragLabel != null) // pokud je stisknuto levé tlačítko myši a label existuje
            {
                int dx = Math.Abs(e.X - mouseDownLocation.X); // vzdálenost myši od původní pozice
                int dy = Math.Abs(e.Y - mouseDownLocation.Y); // vzdálenost myši od původní pozice

                if (!isDragging && (dx > 5 || dy > 5)) // spustíme tažení
                {
                    isDragging = true; // označíme, že tažení začalo
                    dragLabel.Visible = true; // zobrazíme label
                }

                if (isDragging) // pokud už je tažení spuštěno
                {
                    dragLabel.Location = e.Location; // aktualizujeme pozici labelu
                }
            }
        } // událost pohybu myši na DataGridView

        private void EditorEventsDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging) // pokud je tažení spuštěno
            {
                var hit = EditorEventsDataGridView.HitTest(e.X, e.Y); // získání informací o tom, co bylo kliknuto
                int dropRow; // index řádku, kam se má prvek přesunout
                if (hit.Type != DataGridViewHitTestType.None) // pokud je kliknuto na platnou buňku
                {
                    dropRow = hit.RowIndex; // uložení indexu řádku, kam se má prvek přesunout
                    if (dragRow >= 0) // pokud je platný index řádku
                    {
                        int tgtRow = dropRow + (dragRow > dropRow ? 1 : 0); // určení cílového řádku
                        if (tgtRow != dragRow) // pokud se cílový řádek liší od původního
                        {
                            DataGridViewRow row = EditorEventsDataGridView.Rows[dragRow]; // získání řádku, který se má přesunout
                            EditorEventsDataGridView.Rows.Remove(row); // odstranění původního řádku
                            EditorEventsDataGridView.Rows.Insert(tgtRow, row); // vložit řádek na nové místo

                            EditorEventsDataGridView.ClearSelection(); // vymazání výběru
                            row.Selected = true; // označení přesunutého řádku
                        }
                    }
                }
                else
                {
                    EditorEventsDataGridView.Rows[dragRow].Selected = true; // pokud není platná buňka, vybereme původní řádek
                }
            }

            // Resetujeme stav
            if (dragLabel != null)
            {
                dragLabel.Dispose();
                dragLabel = null;
            }

            isDragging = false; // označíme, že tažení skončilo
        } // událost uvolnění myši na DataGridView

        private void EditorEventsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (isDragging) // pokud je tažení spuštěno
            {
                EditorEventsDataGridView.ClearSelection(); // vymazání výběru (jinak to problikava modře)
            }
        } // událost změny výběru v DataGridView




        //TODO: opravit scrollovani v DataGridView když držím prvek

        //TODO: pridat start cyklus (s počtem) tlacitko (a asi i s ID)
        //TODO: pridat konec cyklu tlacitko (s ID)

        //done: funkčnost copy
        //done: funkčnost paste
        //done: pridat funkčnost extract
        //done: pridat delete tlačítko
        //done: pridat posun na konec tlacitko a uplne nahoru (mozna bych to dal kdyz podrzim tu default sipku nahoru a dolu tak se to posune uplne nahoru nebo dolu)
        //done: fixnout kdyz posouvam se stejnym eventem nejako se dojebavaj hodnoty
        //done: fixnout kdyz odmazu pismeno (mozna i cislici) tka to hodi error !!! WORKING ON IT
        //done: fixnout json file selector kdyz zmenim ten file na jinaci file tak se nezmeni ta tabulka

    }
}