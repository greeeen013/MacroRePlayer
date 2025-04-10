using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MacroRePlayer.EventValueForms
{
    public partial class EventValueForm : Form
    {
        //kvuli zavolání funkce pro ziskání konkrétní hardware klávesy
        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        const uint MAPVK_VK_TO_VSC = 0;

        private IKeyboardMouseEvents globalHook; // Globální hook pro sledování vstupů

        public string SelectedEventType { get; private set; }
        public string UpdatedEventValue { get; private set; }
        public string UpdateSecretValue { get; private set; }

        public string HexKey { get; private set; } // Přidáno pro zpřístupnění HexKey mim
        public EventValueForm(string eventType, string eventValue)
        {
            InitializeComponent();

            

            EventValueTypeOfEventComboBox.Items.AddRange(new string[] {
                "MouseDown", "MouseUp", "KeyDown", "KeyUp", "DelayEvent"});

            

            EventValueTypeOfEventComboBox.SelectedIndexChanged += EventValueTypeOfEventComboBox_SelectedIndexChanged;

            // Nastavení typu události + inicializace UI
            EventValueTypeOfEventComboBox.SelectedItem = eventType;
            UpdateVisibilityBasedOnEventType(eventType);

            // Parsování hodnoty eventu
            if (!string.IsNullOrEmpty(eventValue))
            {
                var parts = eventValue.Split(',');

                foreach (var part in parts)
                {
                    if (part.Contains("X:"))
                        EventValueFirstTextBox.Text = part.Replace("X:", "").Trim();
                    else if (part.Contains("Y:"))
                        EventValueSecondsTextBox.Text = part.Replace("Y:", "").Trim();
                    else if (part.Contains("Button:"))
                        EventValueButtonComboBox.SelectedItem = part.Replace("Button:", "").Trim();
                    else if (part.Contains("Key:"))
                        EventValueFirstTextBox.Text = part.Replace("Key:", "").Trim();
                    else if (part.Contains("Duration:"))
                        EventValueFirstTextBox.Text = part.Replace("Duration:", "").Replace("ms", "").Trim();
                }
            }
        }

        private void EventValueTypeOfEventComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = EventValueTypeOfEventComboBox.SelectedItem.ToString();

            // Vymaže všechny hodnoty
            EventValueFirstTextBox.Text = "";
            EventValueSecondsTextBox.Text = "";
            EventValueButtonComboBox.SelectedIndex = -1;

            UpdateVisibilityBasedOnEventType(selectedType);
        }

        private void UpdateVisibilityBasedOnEventType(string eventType)
        {
            // Skrývá vše
            EventValueMouseFirstLabel.Visible = false;
            EventValueFirstTextBox.Visible = false;

            EventValueMouseSecondLabel.Visible = false;
            EventValueSecondsTextBox.Visible = false;

            EventValueMouseKeyLabel.Visible = false;
            EventValueButtonComboBox.Visible = false;

            EventValueMouseKeyLabel.Visible = false;

            richTextBox1.Visible = false;
            EventValueRecordButtonButton.Visible = false;

            if (eventType == "MouseDown" || eventType == "MouseUp")
            {
                EventValueMouseFirstLabel.Text = "X:";
                EventValueMouseFirstLabel.Visible = true;
                EventValueFirstTextBox.Visible = true;

                EventValueMouseSecondLabel.Text = "Y:";
                EventValueMouseSecondLabel.Visible = true;
                EventValueSecondsTextBox.Visible = true;

                EventValueMouseKeyLabel.Visible = true;
                EventValueButtonComboBox.Visible = true;
            }
            else if (eventType == "KeyDown" || eventType == "KeyUp")
            {
                EventValueRecordButtonButton.Visible = true;
                richTextBox1.Visible = true;
            }
            else if (eventType == "DelayEvent")
            {
                EventValueMouseFirstLabel.Text = "Delay:";
                EventValueMouseFirstLabel.Visible = true;
                EventValueFirstTextBox.Visible = true;
            }
        }

        private void EventValueMouseOkButton_Click(object sender, EventArgs e)
        {
            SelectedEventType = EventValueTypeOfEventComboBox.SelectedItem.ToString();
            UpdatedEventValue = "";

            switch (SelectedEventType)
            {
                case "MouseDown":
                case "MouseUp":
                    string x = EventValueFirstTextBox.Text.Trim();
                    string y = EventValueSecondsTextBox.Text.Trim();
                    string button = EventValueButtonComboBox.SelectedItem?.ToString() ?? "";

                    UpdatedEventValue = $"X: {x}, Y: {y}, Button: {button}";
                    break;

                case "KeyDown":
                case "KeyUp":
                    string key = richTextBox1.Text.Trim();
                    UpdateSecretValue = HexKey;
                    UpdatedEventValue = $"Key: {key}";
                    break;

                case "DelayEvent":
                    string delay = EventValueFirstTextBox.Text.Trim();
                    UpdatedEventValue = $"Duration: {delay} ms";
                    break;

                default:
                    // Pokud je vybrán neznámý typ události, nic se neděje
                    break;
            }

            // Zavřít formulář a vrátit výsledek
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EventValueRecordButtonButton_Click(object sender, EventArgs e)
        {
            if (globalHook != null)
            {
                globalHook.KeyDown -= HookManager_KeyDown; // odhlásí se od hooku
                globalHook = null; // uvolní hook
            }
            else
            {
                globalHook = Hook.GlobalEvents(); // vytvoří nový hook
                globalHook.KeyDown += HookManager_KeyDown; // přidá událost pro KeyDown
            }
        }

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            uint scancode = MapVirtualKey((uint)e.KeyCode, MAPVK_VK_TO_VSC);
            var Key = e.KeyCode.ToString();
            HexKey = $"0x{scancode:X}";


            richTextBox1.Text=Key;


            if (globalHook != null) // odhlásí se od hooku
            {
                globalHook.KeyDown -= HookManager_KeyDown;
                globalHook = null;
            }
        }
    }


}
