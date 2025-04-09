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
            components = new System.ComponentModel.Container();
            StartRecording = new Button();
            title = new Label();
            StopRecording = new Button();
            JsonFileSelectorForm = new TextBox();
            JsonFileSelectorLabel = new Label();
            JsonFileSelectorLabelJson = new Label();
            FolderOpenerButton = new Button();
            RecorderLabel = new Label();
            PlayerLabel = new Label();
            RecorderGroupBox = new GroupBox();
            FolderDeleteButton = new Button();
            OpenEditorButton = new Button();
            PlayerGroupBox = new GroupBox();
            TestButton = new Button();
            PlayerStartStopPlayingKeybindTextBox = new TextBox();
            PlayerStartStopKeybindSetButton = new Button();
            EditorPlaybackSpeedLabel = new Label();
            PlayerPlaybackSpeedComboBox = new ComboBox();
            EditorPlaybackMethodLabel = new Label();
            PlayerPlaybackMethodComboBox = new ComboBox();
            PlayerStopPlayingMacroButton = new Button();
            PlayerStartPlayingMacroButton = new Button();
            PlayerComboBox = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            SettingsButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            RecorderGroupBox.SuspendLayout();
            PlayerGroupBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // StartRecording
            // 
            StartRecording.BackColor = Color.White;
            StartRecording.ForeColor = SystemColors.ControlText;
            StartRecording.Location = new Point(20, 126);
            StartRecording.Margin = new Padding(4, 3, 4, 3);
            StartRecording.Name = "StartRecording";
            StartRecording.Size = new Size(211, 52);
            StartRecording.TabIndex = 0;
            StartRecording.Text = "Start Recording";
            StartRecording.UseVisualStyleBackColor = false;
            StartRecording.Click += StartRecording_Click;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 238);
            title.Location = new Point(12, 8);
            title.Margin = new Padding(4, 0, 4, 0);
            title.Name = "title";
            title.Size = new Size(146, 25);
            title.TabIndex = 2;
            title.Text = "MacroRePlayer";
            // 
            // StopRecording
            // 
            StopRecording.BackColor = Color.White;
            StopRecording.Enabled = false;
            StopRecording.ForeColor = SystemColors.ControlText;
            StopRecording.Location = new Point(20, 185);
            StopRecording.Margin = new Padding(4, 3, 4, 3);
            StopRecording.Name = "StopRecording";
            StopRecording.Size = new Size(211, 52);
            StopRecording.TabIndex = 3;
            StopRecording.Text = "StopRecording";
            StopRecording.UseVisualStyleBackColor = false;
            StopRecording.Click += StopRecording_Click;
            // 
            // JsonFileSelectorForm
            // 
            JsonFileSelectorForm.Location = new Point(20, 95);
            JsonFileSelectorForm.Margin = new Padding(4, 3, 4, 3);
            JsonFileSelectorForm.Name = "JsonFileSelectorForm";
            JsonFileSelectorForm.Size = new Size(192, 23);
            JsonFileSelectorForm.TabIndex = 4;
            // 
            // JsonFileSelectorLabel
            // 
            JsonFileSelectorLabel.AutoSize = true;
            JsonFileSelectorLabel.Location = new Point(15, 76);
            JsonFileSelectorLabel.Margin = new Padding(4, 0, 4, 0);
            JsonFileSelectorLabel.Name = "JsonFileSelectorLabel";
            JsonFileSelectorLabel.Size = new Size(89, 15);
            JsonFileSelectorLabel.TabIndex = 5;
            JsonFileSelectorLabel.Text = "Název záznamu";
            // 
            // JsonFileSelectorLabelJson
            // 
            JsonFileSelectorLabelJson.AutoSize = true;
            JsonFileSelectorLabelJson.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            JsonFileSelectorLabelJson.Location = new Point(211, 96);
            JsonFileSelectorLabelJson.Margin = new Padding(4, 0, 4, 0);
            JsonFileSelectorLabelJson.Name = "JsonFileSelectorLabelJson";
            JsonFileSelectorLabelJson.Size = new Size(33, 15);
            JsonFileSelectorLabelJson.TabIndex = 6;
            JsonFileSelectorLabelJson.Text = ".json";
            // 
            // FolderOpenerButton
            // 
            FolderOpenerButton.BackColor = Color.White;
            FolderOpenerButton.ForeColor = SystemColors.ControlText;
            FolderOpenerButton.Location = new Point(20, 243);
            FolderOpenerButton.Margin = new Padding(4, 3, 4, 3);
            FolderOpenerButton.Name = "FolderOpenerButton";
            FolderOpenerButton.Size = new Size(93, 59);
            FolderOpenerButton.TabIndex = 7;
            FolderOpenerButton.Text = "Folder";
            FolderOpenerButton.UseVisualStyleBackColor = false;
            FolderOpenerButton.Click += FolderOpenerButton_Click;
            // 
            // RecorderLabel
            // 
            RecorderLabel.AutoSize = true;
            RecorderLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            RecorderLabel.Location = new Point(77, 18);
            RecorderLabel.Margin = new Padding(2, 0, 2, 0);
            RecorderLabel.Name = "RecorderLabel";
            RecorderLabel.Size = new Size(75, 20);
            RecorderLabel.TabIndex = 8;
            RecorderLabel.Text = "Recorder";
            // 
            // PlayerLabel
            // 
            PlayerLabel.AutoSize = true;
            PlayerLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            PlayerLabel.Location = new Point(173, 18);
            PlayerLabel.Margin = new Padding(2, 0, 2, 0);
            PlayerLabel.Name = "PlayerLabel";
            PlayerLabel.Size = new Size(52, 20);
            PlayerLabel.TabIndex = 9;
            PlayerLabel.Text = "Player";
            // 
            // RecorderGroupBox
            // 
            RecorderGroupBox.Controls.Add(FolderDeleteButton);
            RecorderGroupBox.Controls.Add(OpenEditorButton);
            RecorderGroupBox.Controls.Add(RecorderLabel);
            RecorderGroupBox.Controls.Add(StartRecording);
            RecorderGroupBox.Controls.Add(StopRecording);
            RecorderGroupBox.Controls.Add(JsonFileSelectorForm);
            RecorderGroupBox.Controls.Add(FolderOpenerButton);
            RecorderGroupBox.Controls.Add(JsonFileSelectorLabel);
            RecorderGroupBox.Controls.Add(JsonFileSelectorLabelJson);
            RecorderGroupBox.Location = new Point(4, 3);
            RecorderGroupBox.Margin = new Padding(4, 3, 4, 3);
            RecorderGroupBox.Name = "RecorderGroupBox";
            RecorderGroupBox.Padding = new Padding(4, 3, 4, 3);
            RecorderGroupBox.Size = new Size(257, 464);
            RecorderGroupBox.TabIndex = 11;
            RecorderGroupBox.TabStop = false;
            // 
            // FolderDeleteButton
            // 
            FolderDeleteButton.BackColor = Color.White;
            FolderDeleteButton.ForeColor = SystemColors.ControlText;
            FolderDeleteButton.Location = new Point(120, 243);
            FolderDeleteButton.Margin = new Padding(4, 3, 4, 3);
            FolderDeleteButton.Name = "FolderDeleteButton";
            FolderDeleteButton.Size = new Size(111, 59);
            FolderDeleteButton.TabIndex = 16;
            FolderDeleteButton.Text = "Delete Folder ?";
            FolderDeleteButton.UseVisualStyleBackColor = false;
            FolderDeleteButton.Click += FolderDeleteButton_Click;
            // 
            // OpenEditorButton
            // 
            OpenEditorButton.Location = new Point(61, 309);
            OpenEditorButton.Margin = new Padding(4, 3, 4, 3);
            OpenEditorButton.Name = "OpenEditorButton";
            OpenEditorButton.Size = new Size(88, 27);
            OpenEditorButton.TabIndex = 15;
            OpenEditorButton.Text = "Open Editor";
            OpenEditorButton.UseVisualStyleBackColor = true;
            OpenEditorButton.Click += OpenEditor_Click;
            // 
            // PlayerGroupBox
            // 
            PlayerGroupBox.Controls.Add(TestButton);
            PlayerGroupBox.Controls.Add(PlayerStartStopPlayingKeybindTextBox);
            PlayerGroupBox.Controls.Add(PlayerStartStopKeybindSetButton);
            PlayerGroupBox.Controls.Add(EditorPlaybackSpeedLabel);
            PlayerGroupBox.Controls.Add(PlayerPlaybackSpeedComboBox);
            PlayerGroupBox.Controls.Add(EditorPlaybackMethodLabel);
            PlayerGroupBox.Controls.Add(PlayerPlaybackMethodComboBox);
            PlayerGroupBox.Controls.Add(PlayerStopPlayingMacroButton);
            PlayerGroupBox.Controls.Add(PlayerStartPlayingMacroButton);
            PlayerGroupBox.Controls.Add(PlayerComboBox);
            PlayerGroupBox.Controls.Add(PlayerLabel);
            PlayerGroupBox.Location = new Point(269, 3);
            PlayerGroupBox.Margin = new Padding(4, 3, 4, 3);
            PlayerGroupBox.Name = "PlayerGroupBox";
            PlayerGroupBox.Padding = new Padding(4, 3, 4, 3);
            PlayerGroupBox.Size = new Size(422, 464);
            PlayerGroupBox.TabIndex = 13;
            PlayerGroupBox.TabStop = false;
            // 
            // TestButton
            // 
            TestButton.BackColor = Color.White;
            TestButton.ForeColor = SystemColors.ControlText;
            TestButton.Location = new Point(328, 212);
            TestButton.Margin = new Padding(4, 3, 4, 3);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(59, 52);
            TestButton.TabIndex = 24;
            TestButton.Text = "TestButton";
            TestButton.UseVisualStyleBackColor = false;
            TestButton.Click += TestButton_ClickAsync;
            // 
            // PlayerStartStopPlayingKeybindTextBox
            // 
            PlayerStartStopPlayingKeybindTextBox.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayerStartStopPlayingKeybindTextBox.Location = new Point(202, 213);
            PlayerStartStopPlayingKeybindTextBox.Margin = new Padding(4, 3, 4, 3);
            PlayerStartStopPlayingKeybindTextBox.Name = "PlayerStartStopPlayingKeybindTextBox";
            PlayerStartStopPlayingKeybindTextBox.ReadOnly = true;
            PlayerStartStopPlayingKeybindTextBox.Size = new Size(58, 35);
            PlayerStartStopPlayingKeybindTextBox.TabIndex = 23;
            PlayerStartStopPlayingKeybindTextBox.Text = "None";
            PlayerStartStopPlayingKeybindTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // PlayerStartStopKeybindSetButton
            // 
            PlayerStartStopKeybindSetButton.BackColor = Color.White;
            PlayerStartStopKeybindSetButton.ForeColor = SystemColors.ControlText;
            PlayerStartStopKeybindSetButton.Location = new Point(96, 212);
            PlayerStartStopKeybindSetButton.Margin = new Padding(4, 3, 4, 3);
            PlayerStartStopKeybindSetButton.Name = "PlayerStartStopKeybindSetButton";
            PlayerStartStopKeybindSetButton.Size = new Size(99, 52);
            PlayerStartStopKeybindSetButton.TabIndex = 21;
            PlayerStartStopKeybindSetButton.Text = "Start/Stop keybind";
            PlayerStartStopKeybindSetButton.UseVisualStyleBackColor = false;
            PlayerStartStopKeybindSetButton.Click += PlayerStartStopKeybindSetButton_Click;
            // 
            // EditorPlaybackSpeedLabel
            // 
            EditorPlaybackSpeedLabel.AutoSize = true;
            EditorPlaybackSpeedLabel.Location = new Point(96, 343);
            EditorPlaybackSpeedLabel.Margin = new Padding(4, 0, 4, 0);
            EditorPlaybackSpeedLabel.Name = "EditorPlaybackSpeedLabel";
            EditorPlaybackSpeedLabel.Size = new Size(88, 15);
            EditorPlaybackSpeedLabel.TabIndex = 19;
            EditorPlaybackSpeedLabel.Text = "playback speed";
            // 
            // PlayerPlaybackSpeedComboBox
            // 
            PlayerPlaybackSpeedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PlayerPlaybackSpeedComboBox.FormattingEnabled = true;
            PlayerPlaybackSpeedComboBox.Items.AddRange(new object[] { "0,25x", "0,5x", "0,75x", "1x", "2x", "3x", "4x", "5x", "10x" });
            PlayerPlaybackSpeedComboBox.Location = new Point(99, 361);
            PlayerPlaybackSpeedComboBox.Margin = new Padding(4, 3, 4, 3);
            PlayerPlaybackSpeedComboBox.Name = "PlayerPlaybackSpeedComboBox";
            PlayerPlaybackSpeedComboBox.Size = new Size(92, 23);
            PlayerPlaybackSpeedComboBox.TabIndex = 20;
            // 
            // EditorPlaybackMethodLabel
            // 
            EditorPlaybackMethodLabel.AutoSize = true;
            EditorPlaybackMethodLabel.Location = new Point(96, 291);
            EditorPlaybackMethodLabel.Margin = new Padding(4, 0, 4, 0);
            EditorPlaybackMethodLabel.Name = "EditorPlaybackMethodLabel";
            EditorPlaybackMethodLabel.Size = new Size(99, 15);
            EditorPlaybackMethodLabel.TabIndex = 17;
            EditorPlaybackMethodLabel.Text = "playback method";
            // 
            // PlayerPlaybackMethodComboBox
            // 
            PlayerPlaybackMethodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PlayerPlaybackMethodComboBox.FormattingEnabled = true;
            PlayerPlaybackMethodComboBox.Items.AddRange(new object[] { "One time play", "Play X times", "Repeat until stopped" });
            PlayerPlaybackMethodComboBox.Location = new Point(96, 309);
            PlayerPlaybackMethodComboBox.Margin = new Padding(4, 3, 4, 3);
            PlayerPlaybackMethodComboBox.Name = "PlayerPlaybackMethodComboBox";
            PlayerPlaybackMethodComboBox.Size = new Size(140, 23);
            PlayerPlaybackMethodComboBox.TabIndex = 18;
            // 
            // PlayerStopPlayingMacroButton
            // 
            PlayerStopPlayingMacroButton.BackColor = Color.White;
            PlayerStopPlayingMacroButton.Enabled = false;
            PlayerStopPlayingMacroButton.ForeColor = SystemColors.ControlText;
            PlayerStopPlayingMacroButton.Location = new Point(96, 153);
            PlayerStopPlayingMacroButton.Margin = new Padding(4, 3, 4, 3);
            PlayerStopPlayingMacroButton.Name = "PlayerStopPlayingMacroButton";
            PlayerStopPlayingMacroButton.Size = new Size(210, 52);
            PlayerStopPlayingMacroButton.TabIndex = 17;
            PlayerStopPlayingMacroButton.Text = "Stop Playing Macro";
            PlayerStopPlayingMacroButton.UseVisualStyleBackColor = false;
            PlayerStopPlayingMacroButton.Click += PlayerStopPlayingMacroButton_Click;
            // 
            // PlayerStartPlayingMacroButton
            // 
            PlayerStartPlayingMacroButton.BackColor = Color.White;
            PlayerStartPlayingMacroButton.Enabled = false;
            PlayerStartPlayingMacroButton.ForeColor = SystemColors.ControlText;
            PlayerStartPlayingMacroButton.Location = new Point(96, 95);
            PlayerStartPlayingMacroButton.Margin = new Padding(4, 3, 4, 3);
            PlayerStartPlayingMacroButton.Name = "PlayerStartPlayingMacroButton";
            PlayerStartPlayingMacroButton.Size = new Size(210, 52);
            PlayerStartPlayingMacroButton.TabIndex = 17;
            PlayerStartPlayingMacroButton.Text = "Start Playing Macro";
            PlayerStartPlayingMacroButton.UseVisualStyleBackColor = false;
            PlayerStartPlayingMacroButton.Click += PlayerStartPlayingMacroButton_Click;
            // 
            // PlayerComboBox
            // 
            PlayerComboBox.FormattingEnabled = true;
            PlayerComboBox.Location = new Point(131, 55);
            PlayerComboBox.Margin = new Padding(4, 3, 4, 3);
            PlayerComboBox.Name = "PlayerComboBox";
            PlayerComboBox.Size = new Size(140, 23);
            PlayerComboBox.TabIndex = 10;
            PlayerComboBox.DropDown += PlayerComboBox_DropDown;
            PlayerComboBox.SelectedIndexChanged += PlayerComboBox_SelectedIndexChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(RecorderGroupBox, 0, 0);
            tableLayoutPanel1.Controls.Add(PlayerGroupBox, 1, 0);
            tableLayoutPanel1.Location = new Point(14, 83);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(705, 481);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // SettingsButton
            // 
            SettingsButton.BackColor = Color.White;
            SettingsButton.ForeColor = SystemColors.ControlText;
            SettingsButton.Location = new Point(660, 8);
            SettingsButton.Margin = new Padding(4, 3, 4, 3);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(65, 54);
            SettingsButton.TabIndex = 25;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = false;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // RePlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(740, 575);
            Controls.Add(SettingsButton);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RePlayerForm";
            ShowIcon = false;
            Load += Form1_Load;
            RecorderGroupBox.ResumeLayout(false);
            RecorderGroupBox.PerformLayout();
            PlayerGroupBox.ResumeLayout(false);
            PlayerGroupBox.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.Timer timer1;
    }
}

