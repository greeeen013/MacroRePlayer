namespace MacroRePlayer
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ExecutionPlayerMakroLabel = new Label();
            SettingsPlayerKeyboardLanguageLabel = new Label();
            SettingsPlayerKeyboardLanguageComboBox = new ComboBox();
            SettingsSaveButton = new Button();
            SettingsAutoSaveCheckBox = new CheckBox();
            SettingsExecutionLanguageComboBox = new ComboBox();
            SettingsFormThemeLabel = new Label();
            SettingsFormThemeComboBox = new ComboBox();
            SettingsStartUpDelayLabel = new Label();
            SettingsDefaultPlaybackMethodLabel = new Label();
            SettingsPlaybackMethodComboBox = new ComboBox();
            SettingsDefaultPlaybackSpeedLabel = new Label();
            SettingsPlaybackSpeedComboBox = new ComboBox();
            SettingsKeyDelayBeforeRepeationLabel = new Label();
            SettingsKeyRepeatingCheckBox = new CheckBox();
            SettingsKeyDelayBeforeRepetetionTrackBar = new TrackBar();
            SettingsKeyRepetetionRateTrackBar = new TrackBar();
            SettingsKeyRepetitionRateLabel = new Label();
            SettingsPlayerDelayOffsetLabel = new Label();
            SettingsKeyDelayBeforeRepeationWValueLabel = new Label();
            SettingsKeyRepetitionRateWValueLabel = new Label();
            SettingsDelayEventOffsetTrackBar = new TrackBar();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            SettingsAutodelteLastClickCheckBox = new CheckBox();
            SettingsStartUpDelayNumericUpDown = new NumericUpDown();
            SettingsHowManyTimesNumericUpDown = new NumericUpDown();
            SettingsHowManyTimesLabel = new Label();
            SettingsPlayerKeyBind = new Label();
            SettingsPlayerKeybindButton = new Button();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)SettingsKeyDelayBeforeRepetetionTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsKeyRepetetionRateTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsDelayEventOffsetTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsStartUpDelayNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsHowManyTimesNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // ExecutionPlayerMakroLabel
            // 
            ExecutionPlayerMakroLabel.AutoSize = true;
            ExecutionPlayerMakroLabel.Location = new Point(6, 8);
            ExecutionPlayerMakroLabel.Margin = new Padding(4, 0, 4, 0);
            ExecutionPlayerMakroLabel.Name = "ExecutionPlayerMakroLabel";
            ExecutionPlayerMakroLabel.Size = new Size(131, 15);
            ExecutionPlayerMakroLabel.TabIndex = 2;
            ExecutionPlayerMakroLabel.Text = "Execution player makro";
            // 
            // SettingsPlayerKeyboardLanguageLabel
            // 
            SettingsPlayerKeyboardLanguageLabel.AutoSize = true;
            SettingsPlayerKeyboardLanguageLabel.Location = new Point(6, 68);
            SettingsPlayerKeyboardLanguageLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsPlayerKeyboardLanguageLabel.Name = "SettingsPlayerKeyboardLanguageLabel";
            SettingsPlayerKeyboardLanguageLabel.Size = new Size(205, 15);
            SettingsPlayerKeyboardLanguageLabel.TabIndex = 3;
            SettingsPlayerKeyboardLanguageLabel.Text = "Player Keyboard Language (not soon)";
            // 
            // SettingsPlayerKeyboardLanguageComboBox
            // 
            SettingsPlayerKeyboardLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingsPlayerKeyboardLanguageComboBox.FormattingEnabled = true;
            SettingsPlayerKeyboardLanguageComboBox.Items.AddRange(new object[] { "Us/En", "Czech" });
            SettingsPlayerKeyboardLanguageComboBox.Location = new Point(9, 87);
            SettingsPlayerKeyboardLanguageComboBox.Margin = new Padding(4, 3, 4, 3);
            SettingsPlayerKeyboardLanguageComboBox.Name = "SettingsPlayerKeyboardLanguageComboBox";
            SettingsPlayerKeyboardLanguageComboBox.Size = new Size(140, 23);
            SettingsPlayerKeyboardLanguageComboBox.TabIndex = 4;
            // 
            // SettingsSaveButton
            // 
            SettingsSaveButton.Location = new Point(149, 487);
            SettingsSaveButton.Margin = new Padding(4, 3, 4, 3);
            SettingsSaveButton.Name = "SettingsSaveButton";
            SettingsSaveButton.Size = new Size(88, 27);
            SettingsSaveButton.TabIndex = 5;
            SettingsSaveButton.Text = "Save";
            SettingsSaveButton.UseVisualStyleBackColor = true;
            SettingsSaveButton.Click += SettingsSaveButton_Click;
            // 
            // SettingsAutoSaveCheckBox
            // 
            SettingsAutoSaveCheckBox.AutoSize = true;
            SettingsAutoSaveCheckBox.Checked = true;
            SettingsAutoSaveCheckBox.CheckState = CheckState.Checked;
            SettingsAutoSaveCheckBox.Location = new Point(6, 414);
            SettingsAutoSaveCheckBox.Margin = new Padding(4, 3, 4, 3);
            SettingsAutoSaveCheckBox.Name = "SettingsAutoSaveCheckBox";
            SettingsAutoSaveCheckBox.Size = new Size(189, 19);
            SettingsAutoSaveCheckBox.TabIndex = 7;
            SettingsAutoSaveCheckBox.Text = "AutoSave (maybe not soon lol)";
            SettingsAutoSaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsExecutionLanguageComboBox
            // 
            SettingsExecutionLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingsExecutionLanguageComboBox.FormattingEnabled = true;
            SettingsExecutionLanguageComboBox.Items.AddRange(new object[] { "C#" });
            SettingsExecutionLanguageComboBox.Location = new Point(9, 27);
            SettingsExecutionLanguageComboBox.Margin = new Padding(4, 3, 4, 3);
            SettingsExecutionLanguageComboBox.Name = "SettingsExecutionLanguageComboBox";
            SettingsExecutionLanguageComboBox.Size = new Size(140, 23);
            SettingsExecutionLanguageComboBox.TabIndex = 8;
            // 
            // SettingsFormThemeLabel
            // 
            SettingsFormThemeLabel.AutoSize = true;
            SettingsFormThemeLabel.Location = new Point(219, 8);
            SettingsFormThemeLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsFormThemeLabel.Name = "SettingsFormThemeLabel";
            SettingsFormThemeLabel.Size = new Size(72, 15);
            SettingsFormThemeLabel.TabIndex = 9;
            SettingsFormThemeLabel.Text = "Form theme";
            // 
            // SettingsFormThemeComboBox
            // 
            SettingsFormThemeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingsFormThemeComboBox.FormattingEnabled = true;
            SettingsFormThemeComboBox.Items.AddRange(new object[] { "White" });
            SettingsFormThemeComboBox.Location = new Point(223, 27);
            SettingsFormThemeComboBox.Margin = new Padding(4, 3, 4, 3);
            SettingsFormThemeComboBox.Name = "SettingsFormThemeComboBox";
            SettingsFormThemeComboBox.Size = new Size(140, 23);
            SettingsFormThemeComboBox.TabIndex = 10;
            // 
            // SettingsStartUpDelayLabel
            // 
            SettingsStartUpDelayLabel.AutoSize = true;
            SettingsStartUpDelayLabel.Location = new Point(219, 68);
            SettingsStartUpDelayLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsStartUpDelayLabel.Name = "SettingsStartUpDelayLabel";
            SettingsStartUpDelayLabel.Size = new Size(113, 15);
            SettingsStartUpDelayLabel.TabIndex = 11;
            SettingsStartUpDelayLabel.Text = "Player start up delay";
            // 
            // SettingsDefaultPlaybackMethodLabel
            // 
            SettingsDefaultPlaybackMethodLabel.AutoSize = true;
            SettingsDefaultPlaybackMethodLabel.Location = new Point(6, 128);
            SettingsDefaultPlaybackMethodLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsDefaultPlaybackMethodLabel.Name = "SettingsDefaultPlaybackMethodLabel";
            SettingsDefaultPlaybackMethodLabel.Size = new Size(140, 15);
            SettingsDefaultPlaybackMethodLabel.TabIndex = 18;
            SettingsDefaultPlaybackMethodLabel.Text = "Default playback method";
            // 
            // SettingsPlaybackMethodComboBox
            // 
            SettingsPlaybackMethodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingsPlaybackMethodComboBox.FormattingEnabled = true;
            SettingsPlaybackMethodComboBox.Items.AddRange(new object[] { "One time play", "Play X times", "Repeat until stopped" });
            SettingsPlaybackMethodComboBox.Location = new Point(9, 147);
            SettingsPlaybackMethodComboBox.Margin = new Padding(4, 3, 4, 3);
            SettingsPlaybackMethodComboBox.Name = "SettingsPlaybackMethodComboBox";
            SettingsPlaybackMethodComboBox.Size = new Size(140, 23);
            SettingsPlaybackMethodComboBox.TabIndex = 19;
            SettingsPlaybackMethodComboBox.SelectedIndexChanged += SettingsPlaybackMethodComboBox_SelectedIndexChanged;
            // 
            // SettingsDefaultPlaybackSpeedLabel
            // 
            SettingsDefaultPlaybackSpeedLabel.AutoSize = true;
            SettingsDefaultPlaybackSpeedLabel.Location = new Point(219, 128);
            SettingsDefaultPlaybackSpeedLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsDefaultPlaybackSpeedLabel.Name = "SettingsDefaultPlaybackSpeedLabel";
            SettingsDefaultPlaybackSpeedLabel.Size = new Size(129, 15);
            SettingsDefaultPlaybackSpeedLabel.TabIndex = 20;
            SettingsDefaultPlaybackSpeedLabel.Text = "Default playback speed";
            // 
            // SettingsPlaybackSpeedComboBox
            // 
            SettingsPlaybackSpeedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingsPlaybackSpeedComboBox.FormattingEnabled = true;
            SettingsPlaybackSpeedComboBox.Items.AddRange(new object[] { "0,25x", "0,5x", "0,75x", "1x", "2x", "3x", "4x", "5x", "10x" });
            SettingsPlaybackSpeedComboBox.Location = new Point(223, 147);
            SettingsPlaybackSpeedComboBox.Margin = new Padding(4, 3, 4, 3);
            SettingsPlaybackSpeedComboBox.Name = "SettingsPlaybackSpeedComboBox";
            SettingsPlaybackSpeedComboBox.Size = new Size(135, 23);
            SettingsPlaybackSpeedComboBox.TabIndex = 21;
            // 
            // SettingsKeyDelayBeforeRepeationLabel
            // 
            SettingsKeyDelayBeforeRepeationLabel.AutoSize = true;
            SettingsKeyDelayBeforeRepeationLabel.Location = new Point(6, 258);
            SettingsKeyDelayBeforeRepeationLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsKeyDelayBeforeRepeationLabel.Name = "SettingsKeyDelayBeforeRepeationLabel";
            SettingsKeyDelayBeforeRepeationLabel.Size = new Size(147, 15);
            SettingsKeyDelayBeforeRepeationLabel.TabIndex = 22;
            SettingsKeyDelayBeforeRepeationLabel.Text = "key delay before repetition";
            // 
            // SettingsKeyRepeatingCheckBox
            // 
            SettingsKeyRepeatingCheckBox.AutoSize = true;
            SettingsKeyRepeatingCheckBox.Location = new Point(9, 235);
            SettingsKeyRepeatingCheckBox.Margin = new Padding(4, 3, 4, 3);
            SettingsKeyRepeatingCheckBox.Name = "SettingsKeyRepeatingCheckBox";
            SettingsKeyRepeatingCheckBox.Size = new Size(138, 19);
            SettingsKeyRepeatingCheckBox.TabIndex = 23;
            SettingsKeyRepeatingCheckBox.Text = "Key Repeating (soon)";
            SettingsKeyRepeatingCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsKeyDelayBeforeRepetetionTrackBar
            // 
            SettingsKeyDelayBeforeRepetetionTrackBar.Location = new Point(9, 276);
            SettingsKeyDelayBeforeRepetetionTrackBar.Margin = new Padding(4, 3, 4, 3);
            SettingsKeyDelayBeforeRepetetionTrackBar.Maximum = 1000;
            SettingsKeyDelayBeforeRepetetionTrackBar.Minimum = 200;
            SettingsKeyDelayBeforeRepetetionTrackBar.Name = "SettingsKeyDelayBeforeRepetetionTrackBar";
            SettingsKeyDelayBeforeRepetetionTrackBar.Size = new Size(121, 45);
            SettingsKeyDelayBeforeRepetetionTrackBar.TabIndex = 24;
            SettingsKeyDelayBeforeRepetetionTrackBar.TickFrequency = 100;
            SettingsKeyDelayBeforeRepetetionTrackBar.Value = 200;
            SettingsKeyDelayBeforeRepetetionTrackBar.Scroll += SettingsKeyDelayBeforeRepetetionTrackBar_Scroll;
            // 
            // SettingsKeyRepetetionRateTrackBar
            // 
            SettingsKeyRepetetionRateTrackBar.Location = new Point(9, 359);
            SettingsKeyRepetetionRateTrackBar.Margin = new Padding(4, 3, 4, 3);
            SettingsKeyRepetetionRateTrackBar.Maximum = 500;
            SettingsKeyRepetetionRateTrackBar.Minimum = 5;
            SettingsKeyRepetetionRateTrackBar.Name = "SettingsKeyRepetetionRateTrackBar";
            SettingsKeyRepetetionRateTrackBar.Size = new Size(121, 45);
            SettingsKeyRepetetionRateTrackBar.TabIndex = 25;
            SettingsKeyRepetetionRateTrackBar.TickFrequency = 30;
            SettingsKeyRepetetionRateTrackBar.Value = 6;
            SettingsKeyRepetetionRateTrackBar.Scroll += SettingsKeyRepetetionRateTrackBar_Scroll;
            // 
            // SettingsKeyRepetitionRateLabel
            // 
            SettingsKeyRepetitionRateLabel.AutoSize = true;
            SettingsKeyRepetitionRateLabel.Location = new Point(6, 341);
            SettingsKeyRepetitionRateLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsKeyRepetitionRateLabel.Name = "SettingsKeyRepetitionRateLabel";
            SettingsKeyRepetitionRateLabel.Size = new Size(103, 15);
            SettingsKeyRepetitionRateLabel.TabIndex = 26;
            SettingsKeyRepetitionRateLabel.Text = "Key repetition rate";
            // 
            // SettingsPlayerDelayOffsetLabel
            // 
            SettingsPlayerDelayOffsetLabel.AutoSize = true;
            SettingsPlayerDelayOffsetLabel.Location = new Point(223, 190);
            SettingsPlayerDelayOffsetLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsPlayerDelayOffsetLabel.Name = "SettingsPlayerDelayOffsetLabel";
            SettingsPlayerDelayOffsetLabel.Size = new Size(133, 15);
            SettingsPlayerDelayOffsetLabel.TabIndex = 27;
            SettingsPlayerDelayOffsetLabel.Text = "Player DelayEvent offset";
            // 
            // SettingsKeyDelayBeforeRepeationWValueLabel
            // 
            SettingsKeyDelayBeforeRepeationWValueLabel.AutoSize = true;
            SettingsKeyDelayBeforeRepeationWValueLabel.Location = new Point(6, 313);
            SettingsKeyDelayBeforeRepeationWValueLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsKeyDelayBeforeRepeationWValueLabel.Name = "SettingsKeyDelayBeforeRepeationWValueLabel";
            SettingsKeyDelayBeforeRepeationWValueLabel.Size = new Size(169, 15);
            SettingsKeyDelayBeforeRepeationWValueLabel.TabIndex = 29;
            SettingsKeyDelayBeforeRepeationWValueLabel.Text = "Label na kterym bude hodnota";
            // 
            // SettingsKeyRepetitionRateWValueLabel
            // 
            SettingsKeyRepetitionRateWValueLabel.AutoSize = true;
            SettingsKeyRepetitionRateWValueLabel.Location = new Point(6, 396);
            SettingsKeyRepetitionRateWValueLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsKeyRepetitionRateWValueLabel.Name = "SettingsKeyRepetitionRateWValueLabel";
            SettingsKeyRepetitionRateWValueLabel.Size = new Size(169, 15);
            SettingsKeyRepetitionRateWValueLabel.TabIndex = 30;
            SettingsKeyRepetitionRateWValueLabel.Text = "Label na kterym bude hodnota";
            // 
            // SettingsDelayEventOffsetTrackBar
            // 
            SettingsDelayEventOffsetTrackBar.Location = new Point(227, 209);
            SettingsDelayEventOffsetTrackBar.Margin = new Padding(4, 3, 4, 3);
            SettingsDelayEventOffsetTrackBar.Maximum = 100;
            SettingsDelayEventOffsetTrackBar.Name = "SettingsDelayEventOffsetTrackBar";
            SettingsDelayEventOffsetTrackBar.Size = new Size(121, 45);
            SettingsDelayEventOffsetTrackBar.TabIndex = 31;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(244, 336);
            checkBox1.Margin = new Padding(4, 3, 4, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(164, 19);
            checkBox1.TabIndex = 32;
            checkBox1.Text = "Interrupt by Mouse (soon)";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(244, 363);
            checkBox2.Margin = new Padding(4, 3, 4, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(178, 19);
            checkBox2.TabIndex = 33;
            checkBox2.Text = "Interrupt by Keyboard (soon)";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // SettingsAutodelteLastClickCheckBox
            // 
            SettingsAutodelteLastClickCheckBox.AutoSize = true;
            SettingsAutodelteLastClickCheckBox.Location = new Point(244, 385);
            SettingsAutodelteLastClickCheckBox.Margin = new Padding(4, 3, 4, 3);
            SettingsAutodelteLastClickCheckBox.Name = "SettingsAutodelteLastClickCheckBox";
            SettingsAutodelteLastClickCheckBox.Size = new Size(137, 19);
            SettingsAutodelteLastClickCheckBox.TabIndex = 34;
            SettingsAutodelteLastClickCheckBox.Text = "Autodelete last click?";
            SettingsAutodelteLastClickCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsStartUpDelayNumericUpDown
            // 
            SettingsStartUpDelayNumericUpDown.Location = new Point(223, 87);
            SettingsStartUpDelayNumericUpDown.Name = "SettingsStartUpDelayNumericUpDown";
            SettingsStartUpDelayNumericUpDown.Size = new Size(120, 23);
            SettingsStartUpDelayNumericUpDown.TabIndex = 35;
            // 
            // SettingsHowManyTimesNumericUpDown
            // 
            SettingsHowManyTimesNumericUpDown.Location = new Point(9, 191);
            SettingsHowManyTimesNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            SettingsHowManyTimesNumericUpDown.Name = "SettingsHowManyTimesNumericUpDown";
            SettingsHowManyTimesNumericUpDown.Size = new Size(120, 23);
            SettingsHowManyTimesNumericUpDown.TabIndex = 36;
            SettingsHowManyTimesNumericUpDown.Visible = false;
            // 
            // SettingsHowManyTimesLabel
            // 
            SettingsHowManyTimesLabel.AutoSize = true;
            SettingsHowManyTimesLabel.Location = new Point(9, 173);
            SettingsHowManyTimesLabel.Margin = new Padding(4, 0, 4, 0);
            SettingsHowManyTimesLabel.Name = "SettingsHowManyTimesLabel";
            SettingsHowManyTimesLabel.Size = new Size(97, 15);
            SettingsHowManyTimesLabel.TabIndex = 37;
            SettingsHowManyTimesLabel.Text = "How many times";
            SettingsHowManyTimesLabel.Visible = false;
            // 
            // SettingsPlayerKeyBind
            // 
            SettingsPlayerKeyBind.AutoSize = true;
            SettingsPlayerKeyBind.Location = new Point(401, 9);
            SettingsPlayerKeyBind.Margin = new Padding(4, 0, 4, 0);
            SettingsPlayerKeyBind.Name = "SettingsPlayerKeyBind";
            SettingsPlayerKeyBind.Size = new Size(84, 15);
            SettingsPlayerKeyBind.TabIndex = 38;
            SettingsPlayerKeyBind.Text = "Player keybind";
            // 
            // SettingsPlayerKeybindButton
            // 
            SettingsPlayerKeybindButton.Location = new Point(401, 27);
            SettingsPlayerKeybindButton.Name = "SettingsPlayerKeybindButton";
            SettingsPlayerKeybindButton.Size = new Size(75, 38);
            SettingsPlayerKeybindButton.TabIndex = 39;
            SettingsPlayerKeybindButton.Text = "click to record";
            SettingsPlayerKeybindButton.UseVisualStyleBackColor = true;
            SettingsPlayerKeybindButton.Click += SettingsPlayerKeybindButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(482, 27);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(68, 38);
            richTextBox1.TabIndex = 40;
            richTextBox1.Text = "";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 526);
            Controls.Add(richTextBox1);
            Controls.Add(SettingsPlayerKeybindButton);
            Controls.Add(SettingsPlayerKeyBind);
            Controls.Add(SettingsHowManyTimesLabel);
            Controls.Add(SettingsHowManyTimesNumericUpDown);
            Controls.Add(SettingsStartUpDelayNumericUpDown);
            Controls.Add(SettingsAutodelteLastClickCheckBox);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(SettingsDelayEventOffsetTrackBar);
            Controls.Add(SettingsKeyRepetitionRateWValueLabel);
            Controls.Add(SettingsKeyDelayBeforeRepeationWValueLabel);
            Controls.Add(SettingsPlayerDelayOffsetLabel);
            Controls.Add(SettingsKeyRepetitionRateLabel);
            Controls.Add(SettingsKeyRepetetionRateTrackBar);
            Controls.Add(SettingsKeyDelayBeforeRepetetionTrackBar);
            Controls.Add(SettingsKeyRepeatingCheckBox);
            Controls.Add(SettingsKeyDelayBeforeRepeationLabel);
            Controls.Add(SettingsPlaybackSpeedComboBox);
            Controls.Add(SettingsDefaultPlaybackSpeedLabel);
            Controls.Add(SettingsPlaybackMethodComboBox);
            Controls.Add(SettingsDefaultPlaybackMethodLabel);
            Controls.Add(SettingsStartUpDelayLabel);
            Controls.Add(SettingsFormThemeComboBox);
            Controls.Add(SettingsFormThemeLabel);
            Controls.Add(SettingsExecutionLanguageComboBox);
            Controls.Add(SettingsAutoSaveCheckBox);
            Controls.Add(SettingsSaveButton);
            Controls.Add(SettingsPlayerKeyboardLanguageComboBox);
            Controls.Add(SettingsPlayerKeyboardLanguageLabel);
            Controls.Add(ExecutionPlayerMakroLabel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)SettingsKeyDelayBeforeRepetetionTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsKeyRepetetionRateTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsDelayEventOffsetTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsStartUpDelayNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsHowManyTimesNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ExecutionPlayerMakroLabel;
        private System.Windows.Forms.Label SettingsPlayerKeyboardLanguageLabel;
        private System.Windows.Forms.ComboBox SettingsPlayerKeyboardLanguageComboBox;
        private System.Windows.Forms.Button SettingsSaveButton;
        private System.Windows.Forms.CheckBox SettingsAutoSaveCheckBox;
        private System.Windows.Forms.ComboBox SettingsExecutionLanguageComboBox;
        private System.Windows.Forms.Label SettingsFormThemeLabel;
        private System.Windows.Forms.ComboBox SettingsFormThemeComboBox;
        private System.Windows.Forms.Label SettingsStartUpDelayLabel;
        private System.Windows.Forms.Label SettingsDefaultPlaybackMethodLabel;
        private System.Windows.Forms.ComboBox SettingsPlaybackMethodComboBox;
        private System.Windows.Forms.Label SettingsDefaultPlaybackSpeedLabel;
        private System.Windows.Forms.ComboBox SettingsPlaybackSpeedComboBox;
        private System.Windows.Forms.Label SettingsKeyDelayBeforeRepeationLabel;
        private System.Windows.Forms.CheckBox SettingsKeyRepeatingCheckBox;
        private System.Windows.Forms.TrackBar SettingsKeyDelayBeforeRepetetionTrackBar;
        private System.Windows.Forms.TrackBar SettingsKeyRepetetionRateTrackBar;
        private System.Windows.Forms.Label SettingsKeyRepetitionRateLabel;
        private System.Windows.Forms.Label SettingsPlayerDelayOffsetLabel;
        private System.Windows.Forms.Label SettingsKeyDelayBeforeRepeationWValueLabel;
        private System.Windows.Forms.Label SettingsKeyRepetitionRateWValueLabel;
        private System.Windows.Forms.TrackBar SettingsDelayEventOffsetTrackBar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private CheckBox SettingsAutodelteLastClickCheckBox;
        private NumericUpDown SettingsStartUpDelayNumericUpDown;
        private NumericUpDown SettingsHowManyTimesNumericUpDown;
        private Label SettingsHowManyTimesLabel;
        private Label SettingsPlayerKeyBind;
        private Button SettingsPlayerKeybindButton;
        private RichTextBox richTextBox1;
    }
}