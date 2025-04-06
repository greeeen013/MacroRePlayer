namespace MacroRePlayer
{
    partial class Form1
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
            this.EditorStartStopPlayingKeybindTextBox = new System.Windows.Forms.TextBox();
            this.EditorStartStopKeybindSetButton = new System.Windows.Forms.Button();
            this.EditorPlaybackSpeedLabel = new System.Windows.Forms.Label();
            this.EditorPlaybackSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.EditorPlaybackMethodLabel = new System.Windows.Forms.Label();
            this.EditorPlaybackMethodComboBox = new System.Windows.Forms.ComboBox();
            this.EditorStopPlayingMacroButton = new System.Windows.Forms.Button();
            this.StartPlayingMacroButton = new System.Windows.Forms.Button();
            this.PlayerComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TestButton = new System.Windows.Forms.Button();
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
            this.PlayerGroupBox.Controls.Add(this.EditorStartStopPlayingKeybindTextBox);
            this.PlayerGroupBox.Controls.Add(this.EditorStartStopKeybindSetButton);
            this.PlayerGroupBox.Controls.Add(this.EditorPlaybackSpeedLabel);
            this.PlayerGroupBox.Controls.Add(this.EditorPlaybackSpeedComboBox);
            this.PlayerGroupBox.Controls.Add(this.EditorPlaybackMethodLabel);
            this.PlayerGroupBox.Controls.Add(this.EditorPlaybackMethodComboBox);
            this.PlayerGroupBox.Controls.Add(this.EditorStopPlayingMacroButton);
            this.PlayerGroupBox.Controls.Add(this.StartPlayingMacroButton);
            this.PlayerGroupBox.Controls.Add(this.PlayerComboBox);
            this.PlayerGroupBox.Controls.Add(this.PlayerLabel);
            this.PlayerGroupBox.Location = new System.Drawing.Point(229, 3);
            this.PlayerGroupBox.Name = "PlayerGroupBox";
            this.PlayerGroupBox.Size = new System.Drawing.Size(362, 402);
            this.PlayerGroupBox.TabIndex = 13;
            this.PlayerGroupBox.TabStop = false;
            // 
            // EditorStartStopPlayingKeybindTextBox
            // 
            this.EditorStartStopPlayingKeybindTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorStartStopPlayingKeybindTextBox.Location = new System.Drawing.Point(173, 185);
            this.EditorStartStopPlayingKeybindTextBox.Name = "EditorStartStopPlayingKeybindTextBox";
            this.EditorStartStopPlayingKeybindTextBox.ReadOnly = true;
            this.EditorStartStopPlayingKeybindTextBox.Size = new System.Drawing.Size(50, 35);
            this.EditorStartStopPlayingKeybindTextBox.TabIndex = 23;
            this.EditorStartStopPlayingKeybindTextBox.Text = "None";
            this.EditorStartStopPlayingKeybindTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditorStartStopKeybindSetButton
            // 
            this.EditorStartStopKeybindSetButton.BackColor = System.Drawing.Color.White;
            this.EditorStartStopKeybindSetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EditorStartStopKeybindSetButton.Location = new System.Drawing.Point(82, 184);
            this.EditorStartStopKeybindSetButton.Name = "EditorStartStopKeybindSetButton";
            this.EditorStartStopKeybindSetButton.Size = new System.Drawing.Size(85, 45);
            this.EditorStartStopKeybindSetButton.TabIndex = 21;
            this.EditorStartStopKeybindSetButton.Text = "Start/Stop keybind";
            this.EditorStartStopKeybindSetButton.UseVisualStyleBackColor = false;
            this.EditorStartStopKeybindSetButton.Click += new System.EventHandler(this.EditorStartStopKeybindSetButton_Click);
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
            // EditorPlaybackSpeedComboBox
            // 
            this.EditorPlaybackSpeedComboBox.FormattingEnabled = true;
            this.EditorPlaybackSpeedComboBox.Items.AddRange(new object[] {
            "0,25x",
            "0,5x",
            "0,75x",
            "1x",
            "2x",
            "3x",
            "4x",
            "5x",
            "10x"});
            this.EditorPlaybackSpeedComboBox.Location = new System.Drawing.Point(85, 313);
            this.EditorPlaybackSpeedComboBox.Name = "EditorPlaybackSpeedComboBox";
            this.EditorPlaybackSpeedComboBox.Size = new System.Drawing.Size(79, 21);
            this.EditorPlaybackSpeedComboBox.TabIndex = 20;
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
            // EditorPlaybackMethodComboBox
            // 
            this.EditorPlaybackMethodComboBox.FormattingEnabled = true;
            this.EditorPlaybackMethodComboBox.Items.AddRange(new object[] {
            "One time play",
            "Play X times",
            "Repeat until stopped"});
            this.EditorPlaybackMethodComboBox.Location = new System.Drawing.Point(82, 268);
            this.EditorPlaybackMethodComboBox.Name = "EditorPlaybackMethodComboBox";
            this.EditorPlaybackMethodComboBox.Size = new System.Drawing.Size(121, 21);
            this.EditorPlaybackMethodComboBox.TabIndex = 18;
            // 
            // EditorStopPlayingMacroButton
            // 
            this.EditorStopPlayingMacroButton.BackColor = System.Drawing.Color.White;
            this.EditorStopPlayingMacroButton.Enabled = false;
            this.EditorStopPlayingMacroButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EditorStopPlayingMacroButton.Location = new System.Drawing.Point(82, 133);
            this.EditorStopPlayingMacroButton.Name = "EditorStopPlayingMacroButton";
            this.EditorStopPlayingMacroButton.Size = new System.Drawing.Size(180, 45);
            this.EditorStopPlayingMacroButton.TabIndex = 17;
            this.EditorStopPlayingMacroButton.Text = "Stop Playing Macro";
            this.EditorStopPlayingMacroButton.UseVisualStyleBackColor = false;
            this.EditorStopPlayingMacroButton.Click += new System.EventHandler(this.StopPlayingMacroButton_Click);
            // 
            // StartPlayingMacroButton
            // 
            this.StartPlayingMacroButton.BackColor = System.Drawing.Color.White;
            this.StartPlayingMacroButton.Enabled = false;
            this.StartPlayingMacroButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartPlayingMacroButton.Location = new System.Drawing.Point(82, 82);
            this.StartPlayingMacroButton.Name = "StartPlayingMacroButton";
            this.StartPlayingMacroButton.Size = new System.Drawing.Size(180, 45);
            this.StartPlayingMacroButton.TabIndex = 17;
            this.StartPlayingMacroButton.Text = "Start Playing Macro";
            this.StartPlayingMacroButton.UseVisualStyleBackColor = false;
            this.StartPlayingMacroButton.Click += new System.EventHandler(this.StartPlayingMacroButton_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 498);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
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
        private System.Windows.Forms.ComboBox EditorPlaybackMethodComboBox;
        private System.Windows.Forms.Button EditorStopPlayingMacroButton;
        private System.Windows.Forms.Button StartPlayingMacroButton;
        private System.Windows.Forms.Label EditorPlaybackMethodLabel;
        private System.Windows.Forms.Label EditorPlaybackSpeedLabel;
        private System.Windows.Forms.ComboBox EditorPlaybackSpeedComboBox;
        private System.Windows.Forms.Button EditorStartStopKeybindSetButton;
        private System.Windows.Forms.TextBox EditorStartStopPlayingKeybindTextBox;
        private System.Windows.Forms.Button TestButton;
    }
}

