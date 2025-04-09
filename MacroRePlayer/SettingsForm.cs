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
            if (int.TryParse(SettingsStartUpDelayTextBox.Text, out int startUpDelay))
            {
                settings.AppendLine($"PlayerStartUpDelay={startUpDelay}");
            }
            else
            {
                // Handle the error appropriately, e.g., set a default value or show a message to the user
                settings.AppendLine("PlayerStartUpDelay=0");
            }
            settings.AppendLine($"DefaultPlaybackMethod=\"{SettingsPlaybackMethodComboBox.SelectedItem}\"");
            settings.AppendLine($"DefaultPlaybackSpeed=\"{SettingsPlaybackSpeedComboBox.SelectedItem}\"");
            settings.AppendLine($"PlayerDelayEventOffset={(int)SettingsDelayEventOffsetTrackBar.Value}");
            settings.AppendLine($"KeyRepeating={(bool)SettingsKeyRepeatingCheckBox.Checked}");
            settings.AppendLine($"KeyDelayBeforeRepetetion={(int)SettingsKeyDelayBeforeRepetetionTrackBar.Value}");
            settings.AppendLine($"KeyRepetetionRate={(int)SettingsKeyRepetetionRateTrackBar.Value}");

            return settings;
        }
    }
}
