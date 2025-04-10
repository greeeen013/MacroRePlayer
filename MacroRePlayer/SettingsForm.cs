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

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.SettingsPlayerKeyboardLanguageComboBox.SelectedIndex = 0;

            this.SettingsExecutionLanguageComboBox.SelectedIndex = 0;

            this.SettingsFormThemeComboBox.SelectedIndex = 0;

            this.SettingsPlaybackMethodComboBox.SelectedIndex = 0;

            SettingsPlaybackSpeedComboBox.SelectedIndex = 3;
        }

        private void SettingsKeyDelayBeforeRepetetionTrackBar_Scroll(object sender, EventArgs e)
        {
            SettingsKeyDelayBeforeRepeationWValueLabel.Text = $"Current Value: {SettingsKeyDelayBeforeRepetetionTrackBar.Value} in ms";
        }

        private void SettingsKeyRepetetionRateTrackBar_Scroll(object sender, EventArgs e)
        {
            SettingsKeyRepetitionRateWValueLabel.Text = $"Current Value: {SettingsKeyRepetetionRateTrackBar.Value} characters";
        }

        private void SettingsSaveButton_Click(object sender, EventArgs e)
        {
            string settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MacroRePlayer", "settings.cfg");
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
        }

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
                settings.AppendLine($"DefaultPlaybackHowManyTimesRepeat=\"{(int)SettingsHowManyTimesNumericUpDown.Value}\"");
            }
            else
            {
                settings.AppendLine($"DefaultPlaybackHowManyTimesRepeat=0");
            }

            settings.AppendLine($"DefaultPlaybackSpeed=\"{SettingsPlaybackSpeedComboBox.SelectedItem}\"");
            settings.AppendLine($"KeyRepeating={(bool)SettingsKeyRepeatingCheckBox.Checked}");
            settings.AppendLine($"KeyDelayBeforeRepetetion={(int)SettingsKeyDelayBeforeRepetetionTrackBar.Value}");
            settings.AppendLine($"PlayerDelayEventOffset={(int)SettingsDelayEventOffsetTrackBar.Value}");
            settings.AppendLine($"KeyRepetetionRate={(int)SettingsKeyRepetetionRateTrackBar.Value}");
            settings.AppendLine($"AutoDeleteLastClick={(bool)SettingsAutodelteLastClickCheckBox.Checked}");
            settings.AppendLine($"StartStopPlayingMacroKey=\"{richTextBox1.Text}\"");
            settings.AppendLine($"StartStopPlayingMacroHexKey={HexKey}");
            settings.AppendLine($"AutoSave={(bool)SettingsAutoSaveCheckBox.Checked}");


            return settings;
        }

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
        }


        private void SettingsPlayerKeybindButton_Click(object sender, EventArgs e)
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


            richTextBox1.Text = Key;


            if (globalHook != null) // odhlásí se od hooku
            {
                globalHook.KeyDown -= HookManager_KeyDown;
                globalHook = null;
            }
        }
    }
}
