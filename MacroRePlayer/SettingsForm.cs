using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRePlayer
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private readonly string settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer", "settings.cfg"); // cesta k souboru s nastavením

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(settingsPath)) // pokud soubor existuje
            {
                var settings = File.ReadAllLines(settingsPath);
                foreach (var line in settings) // pro každý řádek v souboru
                {
                    if (line.StartsWith("ExecutionPlayer="))
                    {
                        var value = line.Split('=')[1].Trim('"');
                        SettingsExecutionLanguageComboBox.SelectedItem = value;
                    }
                    else if (line.StartsWith("FormTheme="))
                    {
                        var value = line.Split('=')[1].Trim('"');
                        SettingsFormThemeComboBox.SelectedItem = value;
                    }
                    else if (line.StartsWith("PlayerStartUpDelay="))
                    {
                        var value = int.Parse(line.Split('=')[1]);
                        SettingsStartUpDelayNumericUpDown.Value = value;
                    }
                    else if (line.StartsWith("DefaultPlaybackMethod="))
                    {
                        var value = line.Split('=')[1].Trim('"');
                        SettingsPlaybackMethodComboBox.SelectedItem = value;
                    }
                    else if (line.StartsWith("DefaultPlaybackHowManyTimesRepeat="))
                    {
                        var value = int.Parse(line.Split('=')[1]);
                        SettingsHowManyTimesNumericUpDown.Value = value;
                    }
                    else if (line.StartsWith("DefaultPlaybackSpeed="))
                    {
                        var value = line.Split('=')[1].Trim('"');
                        SettingsPlaybackSpeedComboBox.SelectedItem = value;
                    }
                    else if (line.StartsWith("KeyRepeating="))
                    {
                        var value = bool.Parse(line.Split('=')[1]);
                        SettingsKeyRepeatingCheckBox.Checked = value;
                    }
                    else if (line.StartsWith("KeyDelayBeforeRepetetion="))
                    {
                        var value = int.Parse(line.Split('=')[1]);
                        SettingsKeyDelayBeforeRepetetionTrackBar.Value = value;
                    }
                    else if (line.StartsWith("PlayerDelayEventOffset="))
                    {
                        var value = int.Parse(line.Split('=')[1]);
                        SettingsDelayEventOffsetTrackBar.Value = value;
                    }
                    else if (line.StartsWith("KeyRepetetionRate="))
                    {
                        var value = int.Parse(line.Split('=')[1]);
                        SettingsKeyRepetetionRateTrackBar.Value = value;
                    }
                    else if (line.StartsWith("AutoDeleteLastClick="))
                    {
                        var value = bool.Parse(line.Split('=')[1]);
                        SettingsAutodelteLastClickCheckBox.Checked = value;
                    }
                    else if (line.StartsWith("StartStopPlayingMacroKey="))
                    {
                        var value = line.Split('=')[1].Trim('"');
                        SettingsRecordedKeybindRichTextBox.Text = value;
                    }
                    else if (line.StartsWith("StartStopPlayingMacroHexKey="))
                    {
                        var value = line.Split('=')[1];
                        HexKey = value;
                    }
                }
            }
            else
            {
                // vychozí hodnoty pokud soubor neexistuje
                this.SettingsExecutionLanguageComboBox.SelectedIndex = 0;
                this.SettingsFormThemeComboBox.SelectedIndex = 0;
                this.SettingsPlaybackMethodComboBox.SelectedIndex = 0;
                SettingsPlaybackSpeedComboBox.SelectedIndex = 3;
            }
            SettingsKeyDelayBeforeRepeationWValueLabel.Text = $"Current Value: {SettingsKeyDelayBeforeRepetetionTrackBar.Value} in ms";
            SettingsKeyRepetitionRateWValueLabel.Text = $"Current Value: {SettingsKeyRepetetionRateTrackBar.Value} characters";
            SettingsPlayerDelayEventOffsetLabel.Text = $"Current Value: {SettingsDelayEventOffsetTrackBar.Value} in ms";

            // Nastavte zarovnání na střed
            CenterAlignRichTextBoxContent(SettingsRecordedKeybindRichTextBox);

        } // nastavení výchozích hodnot

        private void SettingsKeyDelayBeforeRepetetionTrackBar_Scroll(object sender, EventArgs e)
        {
            SettingsKeyDelayBeforeRepeationWValueLabel.Text = $"Current Value: {SettingsKeyDelayBeforeRepetetionTrackBar.Value} in ms"; // aktualizace labelu s hodnotou
        } // aktualizace labelu s hodnotou

        private void SettingsKeyRepetetionRateTrackBar_Scroll(object sender, EventArgs e)
        {
            SettingsKeyRepetitionRateWValueLabel.Text = $"Current Value: {SettingsKeyRepetetionRateTrackBar.Value} characters"; // aktualizace labelu s hodnotou
        } // aktualizace labelu s hodnotou

        private void SettingsDelayEventOffsetTrackBar_Scroll(object sender, EventArgs e)
        {
            SettingsPlayerDelayEventOffsetLabel.Text = $"Current Value: {SettingsDelayEventOffsetTrackBar.Value} in ms"; // aktualizace labelu s hodnotou
        }

        private void SettingsSaveButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(settingsPath))
            {
                var settings = WriteOutSettings();
                File.WriteAllText(settingsPath, settings.ToString());
            }
            else
            {
                var directory = Path.GetDirectoryName(settingsPath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var settings = WriteOutSettings();
                File.WriteAllText(settingsPath, settings.ToString());
            }
            this.Close(); // zavře okno nastavení
        } // uložení nastavení a zavření okna

        private StringBuilder WriteOutSettings()
        {
            var settings = new StringBuilder();
            settings.AppendLine("[settings]");
            settings.AppendLine($"ExecutionPlayer=\"{SettingsExecutionLanguageComboBox.SelectedItem}\"");
            settings.AppendLine($"FormTheme=\"{SettingsFormThemeComboBox.SelectedItem}\"");
            settings.AppendLine($"PlayerStartUpDelay={(int)SettingsStartUpDelayNumericUpDown.Value}");

            settings.AppendLine($"DefaultPlaybackMethod=\"{SettingsPlaybackMethodComboBox.SelectedItem}\"");
            if (SettingsPlaybackMethodComboBox.SelectedIndex == 1)
            {
                settings.AppendLine($"DefaultPlaybackHowManyTimesRepeat={(int)SettingsHowManyTimesNumericUpDown.Value}");
            }
            else
            {
                settings.AppendLine($"DefaultPlaybackHowManyTimesRepeat={0}");
            }

            settings.AppendLine($"DefaultPlaybackSpeed=\"{SettingsPlaybackSpeedComboBox.SelectedItem}\"");
            settings.AppendLine($"KeyRepeating={(bool)SettingsKeyRepeatingCheckBox.Checked}");
            settings.AppendLine($"KeyDelayBeforeRepetetion={(int)SettingsKeyDelayBeforeRepetetionTrackBar.Value}");
            settings.AppendLine($"PlayerDelayEventOffset={(int)SettingsDelayEventOffsetTrackBar.Value}");
            settings.AppendLine($"KeyRepetetionRate={(int)SettingsKeyRepetetionRateTrackBar.Value}");
            settings.AppendLine($"AutoDeleteLastClick={(bool)SettingsAutodelteLastClickCheckBox.Checked}");
            settings.AppendLine($"StartStopPlayingMacroKey=\"{SettingsRecordedKeybindRichTextBox.Text}\"");
            settings.AppendLine($"StartStopPlayingMacroHexKey={HexKey}");


            return settings;
        } // zapis nastavení do souboru

        private void SettingsPlaybackMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SettingsPlaybackMethodComboBox.SelectedIndex == 1)
            {
                SettingsHowManyTimesLabel.Visible = true;
                SettingsHowManyTimesNumericUpDown.Visible = true;
            }
            else
            {
                SettingsHowManyTimesNumericUpDown.Visible = false;
                SettingsHowManyTimesLabel.Visible = false;
            }
        } // zobrazení labelu a numericUpDownu pro počet opakování

        private void SettingsPlayerKeybindButton_Click(object sender, EventArgs e)
        {
            if (globalHook != null)
            {
                globalHook.KeyDown -= HookManager_KeyDown; // odhlásí se od hooku  
                globalHook = null; // uvolní hook  
                SettingsRecordedKeybindRichTextBox.Text = "None"; // nastaví na "None"
                SettingsRecordedKeybindRichTextBox.Font = new Font(SettingsRecordedKeybindRichTextBox.Font.FontFamily, 10); // nastaví velikost písma na 10px aby se tam vešel text
                CenterAlignRichTextBoxContent(SettingsRecordedKeybindRichTextBox);
                HexKey = null; // nastaví HexKey na null  
            }
            else
            {
                globalHook = Hook.GlobalEvents(); // vytvoří nový hook  
                globalHook.KeyDown += HookManager_KeyDown; // přidá událost pro KeyDown  
            }
        } // záznam klávesy pro spouštění makra nebo reset  

        // věci pro záznam klávesy
        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);
        const uint MAPVK_VK_TO_VSC = 0;
        public string HexKey { get; private set; } // Přidáno pro zpřístupnění HexKey mim
        private IKeyboardMouseEvents globalHook; // Globální hook pro sledování vstupů

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            uint scancode = MapVirtualKey((uint)e.KeyCode, MAPVK_VK_TO_VSC);
            var Key = e.KeyCode.ToString();
            HexKey = $"0x{scancode:X}";


            SettingsRecordedKeybindRichTextBox.Text = Key;
            SettingsRecordedKeybindRichTextBox.Font = new Font(SettingsRecordedKeybindRichTextBox.Font.FontFamily, 18);
            // Nastavte zarovnání na střed
            CenterAlignRichTextBoxContent(SettingsRecordedKeybindRichTextBox);


            if (globalHook != null) // odhlásí se od hooku
            {
                globalHook.KeyDown -= HookManager_KeyDown;
                globalHook = null;
            }
        } // záznam klávesy pro keybind start/stop makra

        private void CenterAlignRichTextBoxContent(RichTextBox richTextBox)
        {
            richTextBox.SelectAll();
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox.DeselectAll();
        }

        
    }
}
