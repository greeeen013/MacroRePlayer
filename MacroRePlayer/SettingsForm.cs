using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }
    }
}
