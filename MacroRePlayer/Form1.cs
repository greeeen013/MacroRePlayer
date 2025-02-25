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
using Newtonsoft.Json;
using Gma.System.MouseKeyHook;

namespace MacroRePlayer
{

    public partial class Form1 : Form
    {
        private List<InputEvent> events;
        private DateTime lastEventTime;
        private bool isRecording;
        private IKeyboardMouseEvents globalHook;
        private HashSet<string> pressedKeys = new HashSet<string>(); // Sledování stisknutých kláves


        public Form1()
        {
            InitializeComponent();
            events = new List<InputEvent>();
            isRecording = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string currentDateTime = DateTime.Now.ToString("HH-mm_dd.MM.yyyy");
            JsonFileSelectorForm.Text = $"MacroRecord{currentDateTime}";

            
        }

        private void StartRecording_Click(object sender, EventArgs e)
        {
            string directoryPath = @"C:\Users\green013\AppData\Local\MacroRePlayer"; // cesta k ukládání .json souborů

            // Vytvoření složky, pokud neexistuje
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            events.Clear();
            isRecording = true;
            lastEventTime = DateTime.Now;
            StopRecording.Visible = true;
            StartRecording.Visible = false;

            globalHook = Hook.GlobalEvents();
            globalHook.MouseDownExt += GlobalHook_MouseDownExt;
            globalHook.MouseUpExt += GlobalHook_MouseUpExt;
            globalHook.KeyDown += GlobalHook_KeyDown;
            globalHook.KeyUp += GlobalHook_KeyUp;

            //MessageBox.Show("Nahrávání zahájeno.");
        }

        private void StopRecording_Click(object sender, EventArgs e)
        {
            isRecording = false;
            StopRecording.Visible = false;
            StartRecording.Visible = true;

            globalHook.MouseDownExt -= GlobalHook_MouseDownExt;
            globalHook.MouseUpExt -= GlobalHook_MouseUpExt;
            globalHook.KeyDown -= GlobalHook_KeyDown;
            globalHook.KeyUp -= GlobalHook_KeyUp;
            globalHook.Dispose();

            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer");
            string fileName = Path.Combine(directoryPath, JsonFileSelectorForm.Text + ".json");

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string json = JsonConvert.SerializeObject(events, Formatting.Indented);
                writer.Write(json);
            }

            MessageBox.Show($"Soubor {fileName} byl úspěšně vytvořen.");
        }

        private void GlobalHook_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            if (isRecording)
            {
                AddDelayEvent();
                events.Add(new InputEvent
                {
                    EventType = "MouseDown",
                    X = e.X,
                    Y = e.Y,
                    Key = e.Button.ToString()
                });
                lastEventTime = DateTime.Now;
            }
        }

        private void GlobalHook_MouseUpExt(object sender, MouseEventExtArgs e)
        {
            if (isRecording)
            {
                AddDelayEvent();
                events.Add(new InputEvent
                {
                    EventType = "MouseUp",
                    X = e.X,
                    Y = e.Y,
                    Key = e.Button.ToString()
                });
                lastEventTime = DateTime.Now;
            }
        }

        private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (isRecording)
            {
                // Zabránění opakovaným KeyDown událostem
                if (!pressedKeys.Contains(e.KeyCode.ToString()))
                {
                    AddDelayEvent();
                    events.Add(new InputEvent
                    {
                        EventType = "KeyDown",
                        Key = e.KeyCode.ToString()
                    });
                    lastEventTime = DateTime.Now;
                    pressedKeys.Add(e.KeyCode.ToString()); // Přidat klávesu do seznamu stisknutých
                }
            }
        }

        private void GlobalHook_KeyUp(object sender, KeyEventArgs e)
        {
            if (isRecording)
            {
                AddDelayEvent();
                events.Add(new InputEvent
                {
                    EventType = "KeyUp",
                    Key = e.KeyCode.ToString()
                });
                lastEventTime = DateTime.Now;
                pressedKeys.Remove(e.KeyCode.ToString()); // Odebrat klávesu ze seznamu stisknutých
            }
        }

        private void AddDelayEvent()
        {
            var delay = (DateTime.Now - lastEventTime).Milliseconds;
            if (delay > 0)
            {
                events.Add(new InputEvent
                {
                    EventType = "Delay",
                    Duration = delay
                });
            }
        }

        private void FolderOpenerButton_Click(object sender, EventArgs e)
        {
            string userDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer");
            if (Directory.Exists(userDirectoryPath))
            {
                System.Diagnostics.Process.Start("explorer.exe", userDirectoryPath);
            }
            else
            {
                MessageBox.Show("Složka neexistuje.");
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            // Zobrazení všech .json souborů v adresáři
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer");
            if (Directory.Exists(directoryPath))
            {
                var jsonFiles = Directory.GetFiles(directoryPath, "*.json");
                foreach (var file in jsonFiles)
                {
                    JsonFileSelectorComboBox.Items.Add(Path.GetFileName(file));
                }
            }
        }

        private void JsonFileSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer");
            string selectedFile = Path.Combine(directoryPath, JsonFileSelectorComboBox.SelectedItem.ToString());

            if (File.Exists(selectedFile))
            {
                string jsonContent = File.ReadAllText(selectedFile);
                List<InputEvent> loadedEvents = JsonConvert.DeserializeObject<List<InputEvent>>(jsonContent);

                DisplayEvents(loadedEvents);
            }
        }

        private void DisplayEvents(List<InputEvent> events)
        {
            EditorEventPanel.Controls.Clear();
            EditorEventPanel.AutoScroll = true;

            foreach (var inputEvent in events)
            {
                Panel eventPanel = new Panel
                {
                    AutoSize = true,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                Label eventTypeLabel = new Label
                {
                    Text = inputEvent.EventType,
                    AutoSize = true
                };
                eventPanel.Controls.Add(eventTypeLabel);

                if (inputEvent.EventType == "Delay")
                {
                    Label durationLabel = new Label
                    {
                        Text = "Duration:",
                        AutoSize = true
                    };
                    TextBox durationTextBox = new TextBox
                    {
                        Text = inputEvent.Duration.ToString(),
                        Width = 100
                    };
                    eventPanel.Controls.Add(durationLabel);
                    eventPanel.Controls.Add(durationTextBox);
                }
                else if (inputEvent.EventType == "MouseDown" || inputEvent.EventType == "MouseUp")
                {
                    Label xLabel = new Label
                    {
                        Text = "X:",
                        AutoSize = true
                    };
                    TextBox xTextBox = new TextBox
                    {
                        Text = inputEvent.X.ToString(),
                        Width = 100
                    };
                    Label yLabel = new Label
                    {
                        Text = "Y:",
                        AutoSize = true
                    };
                    TextBox yTextBox = new TextBox
                    {
                        Text = inputEvent.Y.ToString(),
                        Width = 100
                    };
                    Label buttonLabel = new Label
                    {
                        Text = "Button:",
                        AutoSize = true
                    };
                    ComboBox buttonComboBox = new ComboBox
                    {
                        Width = 100,
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    buttonComboBox.Items.AddRange(new string[] { "Left", "Right", "Middle" });
                    buttonComboBox.SelectedItem = inputEvent.Key;

                    eventPanel.Controls.Add(xLabel);
                    eventPanel.Controls.Add(xTextBox);
                    eventPanel.Controls.Add(yLabel);
                    eventPanel.Controls.Add(yTextBox);
                    eventPanel.Controls.Add(buttonLabel);
                    eventPanel.Controls.Add(buttonComboBox);
                }
                else if (inputEvent.EventType == "KeyDown" || inputEvent.EventType == "KeyUp")
                {
                    Label keyLabel = new Label
                    {
                        Text = "Key:",
                        AutoSize = true
                    };
                    TextBox keyTextBox = new TextBox
                    {
                        Text = inputEvent.Key,
                        Width = 100
                    };
                    eventPanel.Controls.Add(keyLabel);
                    eventPanel.Controls.Add(keyTextBox);
                }

                EditorEventPanel.Controls.Add(eventPanel);
            }
        }
    }
}
