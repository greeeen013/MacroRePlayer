namespace MacroRePlayer
{
    partial class RePlayerForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartRecording = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.StopRecording = new System.Windows.Forms.Button();
            this.JsonFileSelectorForm = new System.Windows.Forms.TextBox();
            this.JsonFileSelectorLabel = new System.Windows.Forms.Label();
            this.JsonFileSelectorLabelJson = new System.Windows.Forms.Label();
            this.FolderOpenerButton = new System.Windows.Forms.Button();
            this.RecorderLabel = new System.Windows.Forms.Label();
            this.PlayerLabel = new System.Windows.Forms.Label();
            this.RecorderGroupBox = new System.Windows.Forms.GroupBox();
            this.FolderDeleteButton = new System.Windows.Forms.Button();
            this.OpenEditorButton = new System.Windows.Forms.Button();
            this.PlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.TestButton = new System.Windows.Forms.Button();
            this.PlayerStartStopPlayingKeybindTextBox = new System.Windows.Forms.TextBox();
            this.PlayerStartStopKeybindSetButton = new System.Windows.Forms.Button();
            this.EditorPlaybackSpeedLabel = new System.Windows.Forms.Label();
            this.PlayerPlaybackSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.EditorPlaybackMethodLabel = new System.Windows.Forms.Label();
            this.PlayerPlaybackMethodComboBox = new System.Windows.Forms.ComboBox();
            this.PlayerStopPlayingMacroButton = new System.Windows.Forms.Button();
            this.PlayerStartPlayingMacroButton = new System.Windows.Forms.Button();
            this.PlayerComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.RecorderGroupBox.SuspendLayout();
            this.PlayerGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartRecording
            // 
            this.StartRecording.BackColor = System.Drawing.Color.White;
            this.StartRecording.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartRecording.Location = new System.Drawing.Point(17, 109);
            this.StartRecording.Name = "StartRecording";
            this.StartRecording.Size = new System.Drawing.Size(181, 45);
            this.StartRecording.TabIndex = 0;
            this.StartRecording.Text = "Start Recording";
            this.StartRecording.UseVisualStyleBackColor = false;
            this.StartRecording.Click += new System.EventHandler(this.StartRecording_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title.Location = new System.Drawing.Point(10, 7);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(146, 25);
            this.title.TabIndex = 2;
            this.title.Text = "MacroRePlayer";
            // 
            // StopRecording
            // 
            this.StopRecording.BackColor = System.Drawing.Color.White;
            this.StopRecording.Enabled = false;
            this.StopRecording.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StopRecording.Location = new System.Drawing.Point(17, 160);
            this.StopRecording.Name = "StopRecording";
            this.StopRecording.Size = new System.Drawing.Size(181, 45);
            this.StopRecording.TabIndex = 3;
            this.StopRecording.Text = "StopRecording";
            this.StopRecording.UseVisualStyleBackColor = false;
            this.StopRecording.Click += new System.EventHandler(this.StopRecording_Click);
            // 
            // JsonFileSelectorForm
            // 
            this.JsonFileSelectorForm.Location = new System.Drawing.Point(17, 82);
            this.JsonFileSelectorForm.Name = "JsonFileSelectorForm";
            this.JsonFileSelectorForm.Size = new System.Drawing.Size(165, 20);
            this.JsonFileSelectorForm.TabIndex = 4;
            // 
            // JsonFileSelectorLabel
            // 
            this.JsonFileSelectorLabel.AutoSize = true;
            this.JsonFileSelectorLabel.Location = new System.Drawing.Point(13, 66);
            this.JsonFileSelectorLabel.Name = "JsonFileSelectorLabel";
            this.JsonFileSelectorLabel.Size = new System.Drawing.Size(83, 13);
            this.JsonFileSelectorLabel.TabIndex = 5;
            this.JsonFileSelectorLabel.Text = "Název záznamu";
            // 
            // JsonFileSelectorLabelJson
            // 
            this.JsonFileSelectorLabelJson.AutoSize = true;
            this.JsonFileSelectorLabelJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.JsonFileSelectorLabelJson.Location = new System.Drawing.Point(181, 83);
            this.JsonFileSelectorLabelJson.Name = "JsonFileSelectorLabelJson";
            this.JsonFileSelectorLabelJson.Size = new System.Drawing.Size(33, 15);
            this.JsonFileSelectorLabelJson.TabIndex = 6;
            this.JsonFileSelectorLabelJson.Text = ".json";
            // 
            // FolderOpenerButton
            // 
            this.FolderOpenerButton.BackColor = System.Drawing.Color.White;
            this.FolderOpenerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FolderOpenerButton.Location = new System.Drawing.Point(17, 211);
            this.FolderOpenerButton.Name = "FolderOpenerButton";
            this.FolderOpenerButton.Size = new System.Drawing.Size(80, 51);
            this.FolderOpenerButton.TabIndex = 7;
            this.FolderOpenerButton.Text = "Folder";
            this.FolderOpenerButton.UseVisualStyleBackColor = false;
            this.FolderOpenerButton.Click += new System.EventHandler(this.FolderOpenerButton_Click);
            // 
            // RecorderLabel
            // 
            this.RecorderLabel.AutoSize = true;
            this.RecorderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RecorderLabel.Location = new System.Drawing.Point(66, 16);
            this.RecorderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RecorderLabel.Name = "RecorderLabel";
            this.RecorderLabel.Size = new System.Drawing.Size(75, 20);
            this.RecorderLabel.TabIndex = 8;
            this.RecorderLabel.Text = "Recorder";
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlayerLabel.Location = new System.Drawing.Point(148, 16);
            this.PlayerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(52, 20);
            this.PlayerLabel.TabIndex = 9;
            this.PlayerLabel.Text = "Player";
            // 
            // RecorderGroupBox
            // 
            this.RecorderGroupBox.Controls.Add(this.FolderDeleteButton);
            this.RecorderGroupBox.Controls.Add(this.OpenEditorButton);
            this.RecorderGroupBox.Controls.Add(this.RecorderLabel);
            this.RecorderGroupBox.Controls.Add(this.StartRecording);
            this.RecorderGroupBox.Controls.Add(this.StopRecording);
            this.RecorderGroupBox.Controls.Add(this.JsonFileSelectorForm);
            this.RecorderGroupBox.Controls.Add(this.FolderOpenerButton);
            this.RecorderGroupBox.Controls.Add(this.JsonFileSelectorLabel);
            this.RecorderGroupBox.Controls.Add(this.JsonFileSelectorLabelJson);
            this.RecorderGroupBox.Location = new System.Drawing.Point(3, 3);
            this.RecorderGroupBox.Name = "RecorderGroupBox";
            this.RecorderGroupBox.Size = new System.Drawing.Size(220, 402);
            this.RecorderGroupBox.TabIndex = 11;
            this.RecorderGroupBox.TabStop = false;
            // 
            // FolderDeleteButton
            // 
            this.FolderDeleteButton.BackColor = System.Drawing.Color.White;
            this.FolderDeleteButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FolderDeleteButton.Location = new System.Drawing.Point(103, 211);
            this.FolderDeleteButton.Name = "FolderDeleteButton";
            this.FolderDeleteButton.Size = new System.Drawing.Size(95, 51);
            this.FolderDeleteButton.TabIndex = 16;
            this.FolderDeleteButton.Text = "Delete Folder ?";
            this.FolderDeleteButton.UseVisualStyleBackColor = false;
            this.FolderDeleteButton.Click += new System.EventHandler(this.FolderDeleteButton_Click);
            // 
            // OpenEditorButton
            // 
            this.OpenEditorButton.Location = new System.Drawing.Point(52, 268);
            this.OpenEditorButton.Name = "OpenEditorButton";
            this.OpenEditorButton.Size = new System.Drawing.Size(75, 23);
            this.OpenEditorButton.TabIndex = 15;
            this.OpenEditorButton.Text = "Open Editor";
            this.OpenEditorButton.UseVisualStyleBackColor = true;
            this.OpenEditorButton.Click += new System.EventHandler(this.OpenEditor_Click);
            // 
            // PlayerGroupBox
            // 
            this.PlayerGroupBox.Controls.Add(this.TestButton);
            this.PlayerGroupBox.Controls.Add(this.PlayerStartStopPlayingKeybindTextBox);
            this.PlayerGroupBox.Controls.Add(this.PlayerStartStopKeybindSetButton);
            this.PlayerGroupBox.Controls.Add(this.EditorPlaybackSpeedLabel);
            this.PlayerGroupBox.Controls.Add(this.PlayerPlaybackSpeedComboBox);
            this.PlayerGroupBox.Controls.Add(this.EditorPlaybackMethodLabel);
            this.PlayerGroupBox.Controls.Add(this.PlayerPlaybackMethodComboBox);
            this.PlayerGroupBox.Controls.Add(this.PlayerStopPlayingMacroButton);
            this.PlayerGroupBox.Controls.Add(this.PlayerStartPlayingMacroButton);
            this.PlayerGroupBox.Controls.Add(this.PlayerComboBox);
            this.PlayerGroupBox.Controls.Add(this.PlayerLabel);
            this.PlayerGroupBox.Location = new System.Drawing.Point(229, 3);
            this.PlayerGroupBox.Name = "PlayerGroupBox";
            this.PlayerGroupBox.Size = new System.Drawing.Size(362, 402);
            this.PlayerGroupBox.TabIndex = 13;
            this.PlayerGroupBox.TabStop = false;
            // 
            // TestButton
            // 
            this.TestButton.BackColor = System.Drawing.Color.White;
            this.TestButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TestButton.Location = new System.Drawing.Point(281, 184);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(51, 45);
            this.TestButton.TabIndex = 24;
            this.TestButton.Text = "TestButton";
            this.TestButton.UseVisualStyleBackColor = false;
            this.TestButton.Click += new System.EventHandler(this.TestButton_ClickAsync);
            // 
            // PlayerStartStopPlayingKeybindTextBox
            // 
            this.PlayerStartStopPlayingKeybindTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerStartStopPlayingKeybindTextBox.Location = new System.Drawing.Point(173, 185);
            this.PlayerStartStopPlayingKeybindTextBox.Name = "PlayerStartStopPlayingKeybindTextBox";
            this.PlayerStartStopPlayingKeybindTextBox.ReadOnly = true;
            this.PlayerStartStopPlayingKeybindTextBox.Size = new System.Drawing.Size(50, 35);
            this.PlayerStartStopPlayingKeybindTextBox.TabIndex = 23;
            this.PlayerStartStopPlayingKeybindTextBox.Text = "None";
            this.PlayerStartStopPlayingKeybindTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PlayerStartStopKeybindSetButton
            // 
            this.PlayerStartStopKeybindSetButton.BackColor = System.Drawing.Color.White;
            this.PlayerStartStopKeybindSetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PlayerStartStopKeybindSetButton.Location = new System.Drawing.Point(82, 184);
            this.PlayerStartStopKeybindSetButton.Name = "PlayerStartStopKeybindSetButton";
            this.PlayerStartStopKeybindSetButton.Size = new System.Drawing.Size(85, 45);
            this.PlayerStartStopKeybindSetButton.TabIndex = 21;
            this.PlayerStartStopKeybindSetButton.Text = "Start/Stop keybind";
            this.PlayerStartStopKeybindSetButton.UseVisualStyleBackColor = false;
            this.PlayerStartStopKeybindSetButton.Click += new System.EventHandler(this.PlayerStartStopKeybindSetButton_Click);
            // 
            // EditorPlaybackSpeedLabel
            // 
            this.EditorPlaybackSpeedLabel.AutoSize = true;
            this.EditorPlaybackSpeedLabel.Location = new System.Drawing.Point(82, 297);
            this.EditorPlaybackSpeedLabel.Name = "EditorPlaybackSpeedLabel";
            this.EditorPlaybackSpeedLabel.Size = new System.Drawing.Size(82, 13);
            this.EditorPlaybackSpeedLabel.TabIndex = 19;
            this.EditorPlaybackSpeedLabel.Text = "playback speed";
            // 
            // PlayerPlaybackSpeedComboBox
            // 
            this.PlayerPlaybackSpeedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayerPlaybackSpeedComboBox.FormattingEnabled = true;
            this.PlayerPlaybackSpeedComboBox.Items.AddRange(new object[] {
            "0,25x",
            "0,5x",
            "0,75x",
            "1x",
            "2x",
            "3x",
            "4x",
            "5x",
            "10x"});
            this.PlayerPlaybackSpeedComboBox.Location = new System.Drawing.Point(85, 313);
            this.PlayerPlaybackSpeedComboBox.Name = "PlayerPlaybackSpeedComboBox";
            this.PlayerPlaybackSpeedComboBox.Size = new System.Drawing.Size(79, 21);
            this.PlayerPlaybackSpeedComboBox.TabIndex = 20;
            // 
            // EditorPlaybackMethodLabel
            // 
            this.EditorPlaybackMethodLabel.AutoSize = true;
            this.EditorPlaybackMethodLabel.Location = new System.Drawing.Point(82, 252);
            this.EditorPlaybackMethodLabel.Name = "EditorPlaybackMethodLabel";
            this.EditorPlaybackMethodLabel.Size = new System.Drawing.Size(88, 13);
            this.EditorPlaybackMethodLabel.TabIndex = 17;
            this.EditorPlaybackMethodLabel.Text = "playback method";
            // 
            // PlayerPlaybackMethodComboBox
            // 
            this.PlayerPlaybackMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayerPlaybackMethodComboBox.FormattingEnabled = true;
            this.PlayerPlaybackMethodComboBox.Items.AddRange(new object[] {
            "One time play",
            "Play X times",
            "Repeat until stopped"});
            this.PlayerPlaybackMethodComboBox.Location = new System.Drawing.Point(82, 268);
            this.PlayerPlaybackMethodComboBox.Name = "PlayerPlaybackMethodComboBox";
            this.PlayerPlaybackMethodComboBox.Size = new System.Drawing.Size(121, 21);
            this.PlayerPlaybackMethodComboBox.TabIndex = 18;
            // 
            // PlayerStopPlayingMacroButton
            // 
            this.PlayerStopPlayingMacroButton.BackColor = System.Drawing.Color.White;
            this.PlayerStopPlayingMacroButton.Enabled = false;
            this.PlayerStopPlayingMacroButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PlayerStopPlayingMacroButton.Location = new System.Drawing.Point(82, 133);
            this.PlayerStopPlayingMacroButton.Name = "PlayerStopPlayingMacroButton";
            this.PlayerStopPlayingMacroButton.Size = new System.Drawing.Size(180, 45);
            this.PlayerStopPlayingMacroButton.TabIndex = 17;
            this.PlayerStopPlayingMacroButton.Text = "Stop Playing Macro";
            this.PlayerStopPlayingMacroButton.UseVisualStyleBackColor = false;
            this.PlayerStopPlayingMacroButton.Click += new System.EventHandler(this.PlayerStopPlayingMacroButton_Click);
            // 
            // PlayerStartPlayingMacroButton
            // 
            this.PlayerStartPlayingMacroButton.BackColor = System.Drawing.Color.White;
            this.PlayerStartPlayingMacroButton.Enabled = false;
            this.PlayerStartPlayingMacroButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PlayerStartPlayingMacroButton.Location = new System.Drawing.Point(82, 82);
            this.PlayerStartPlayingMacroButton.Name = "PlayerStartPlayingMacroButton";
            this.PlayerStartPlayingMacroButton.Size = new System.Drawing.Size(180, 45);
            this.PlayerStartPlayingMacroButton.TabIndex = 17;
            this.PlayerStartPlayingMacroButton.Text = "Start Playing Macro";
            this.PlayerStartPlayingMacroButton.UseVisualStyleBackColor = false;
            this.PlayerStartPlayingMacroButton.Click += new System.EventHandler(this.PlayerStartPlayingMacroButton_Click);
            // 
            // PlayerComboBox
            // 
            this.PlayerComboBox.FormattingEnabled = true;
            this.PlayerComboBox.Location = new System.Drawing.Point(112, 48);
            this.PlayerComboBox.Name = "PlayerComboBox";
            this.PlayerComboBox.Size = new System.Drawing.Size(121, 21);
            this.PlayerComboBox.TabIndex = 10;
            this.PlayerComboBox.DropDown += new System.EventHandler(this.PlayerComboBox_DropDown);
            this.PlayerComboBox.SelectedIndexChanged += new System.EventHandler(this.PlayerComboBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.RecorderGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayerGroupBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 72);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 417);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.White;
            this.SettingsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SettingsButton.Location = new System.Drawing.Point(566, 7);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(56, 47);
            this.SettingsButton.TabIndex = 25;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // RePlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 498);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RePlayerForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.RecorderGroupBox.ResumeLayout(false);
            this.RecorderGroupBox.PerformLayout();
            this.PlayerGroupBox.ResumeLayout(false);
            this.PlayerGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartRecording;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button StopRecording;
        private System.Windows.Forms.TextBox JsonFileSelectorForm;
        private System.Windows.Forms.Label JsonFileSelectorLabel;
        private System.Windows.Forms.Label JsonFileSelectorLabelJson;
        private System.Windows.Forms.Button FolderOpenerButton;
        private System.Windows.Forms.Label RecorderLabel;
        private System.Windows.Forms.Label PlayerLabel;
        private System.Windows.Forms.GroupBox RecorderGroupBox;
        private System.Windows.Forms.GroupBox PlayerGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button OpenEditorButton;
        private System.Windows.Forms.Button FolderDeleteButton;
        private System.Windows.Forms.ComboBox PlayerComboBox;
        private System.Windows.Forms.ComboBox PlayerPlaybackMethodComboBox;
        private System.Windows.Forms.Button PlayerStopPlayingMacroButton;
        private System.Windows.Forms.Button PlayerStartPlayingMacroButton;
        private System.Windows.Forms.Label EditorPlaybackMethodLabel;
        private System.Windows.Forms.Label EditorPlaybackSpeedLabel;
        private System.Windows.Forms.ComboBox PlayerPlaybackSpeedComboBox;
        private System.Windows.Forms.Button PlayerStartStopKeybindSetButton;
        private System.Windows.Forms.TextBox PlayerStartStopPlayingKeybindTextBox;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button SettingsButton;
    }
}

