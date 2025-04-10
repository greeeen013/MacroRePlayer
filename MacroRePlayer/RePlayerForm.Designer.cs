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
            PlayerChooseAFileLabel = new Label();
            PlayerHowManyTimesNumericUpDown = new NumericUpDown();
            PlayerHowManyTimesLabel = new Label();
            PlayerPlaybackSpeedLabel = new Label();
            PlayerPlaybackSpeedComboBox = new ComboBox();
            PlayerPlaybackMethodLabel = new Label();
            PlayerPlaybackMethodComboBox = new ComboBox();
            PlayerStopPlayingMacroButton = new Button();
            PlayerStartPlayingMacroButton = new Button();
            PlayerComboBox = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            SettingsButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            RecorderGroupBox.SuspendLayout();
            PlayerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PlayerHowManyTimesNumericUpDown).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // StartRecording
            // 
            StartRecording.BackColor = Color.White;
            StartRecording.ForeColor = SystemColors.ControlText;
            StartRecording.Location = new Point(21, 95);
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
            title.Location = new Point(30, 17);
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
            StopRecording.Location = new Point(21, 154);
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
            JsonFileSelectorForm.Location = new Point(21, 64);
            JsonFileSelectorForm.Margin = new Padding(4, 3, 4, 3);
            JsonFileSelectorForm.Name = "JsonFileSelectorForm";
            JsonFileSelectorForm.Size = new Size(192, 23);
            JsonFileSelectorForm.TabIndex = 4;
            // 
            // JsonFileSelectorLabel
            // 
            JsonFileSelectorLabel.AutoSize = true;
            JsonFileSelectorLabel.Location = new Point(16, 45);
            JsonFileSelectorLabel.Margin = new Padding(4, 0, 4, 0);
            JsonFileSelectorLabel.Name = "JsonFileSelectorLabel";
            JsonFileSelectorLabel.Size = new Size(61, 15);
            JsonFileSelectorLabel.TabIndex = 5;
            JsonFileSelectorLabel.Text = "File name:";
            // 
            // JsonFileSelectorLabelJson
            // 
            JsonFileSelectorLabelJson.AutoSize = true;
            JsonFileSelectorLabelJson.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            JsonFileSelectorLabelJson.Location = new Point(212, 65);
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
            FolderOpenerButton.Location = new Point(21, 212);
            FolderOpenerButton.Margin = new Padding(4, 3, 4, 3);
            FolderOpenerButton.Name = "FolderOpenerButton";
            FolderOpenerButton.Size = new Size(135, 59);
            FolderOpenerButton.TabIndex = 7;
            FolderOpenerButton.Text = "Folder";
            FolderOpenerButton.UseVisualStyleBackColor = false;
            FolderOpenerButton.Click += FolderOpenerButton_Click;
            // 
            // RecorderLabel
            // 
            RecorderLabel.AutoSize = true;
            RecorderLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            RecorderLabel.Location = new Point(90, 19);
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
            PlayerLabel.Location = new Point(96, 19);
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
            RecorderGroupBox.Size = new Size(257, 337);
            RecorderGroupBox.TabIndex = 11;
            RecorderGroupBox.TabStop = false;
            // 
            // FolderDeleteButton
            // 
            FolderDeleteButton.BackColor = Color.White;
            FolderDeleteButton.ForeColor = SystemColors.ControlText;
            FolderDeleteButton.Location = new Point(164, 212);
            FolderDeleteButton.Margin = new Padding(4, 3, 4, 3);
            FolderDeleteButton.Name = "FolderDeleteButton";
            FolderDeleteButton.Size = new Size(68, 59);
            FolderDeleteButton.TabIndex = 16;
            FolderDeleteButton.Text = "Delete Folder ?";
            FolderDeleteButton.UseVisualStyleBackColor = false;
            FolderDeleteButton.Click += FolderDeleteButton_Click;
            // 
            // OpenEditorButton
            // 
            OpenEditorButton.Location = new Point(21, 278);
            OpenEditorButton.Margin = new Padding(4, 3, 4, 3);
            OpenEditorButton.Name = "OpenEditorButton";
            OpenEditorButton.Size = new Size(211, 53);
            OpenEditorButton.TabIndex = 15;
            OpenEditorButton.Text = "Open Editor";
            OpenEditorButton.UseVisualStyleBackColor = true;
            OpenEditorButton.Click += OpenEditor_Click;
            // 
            // PlayerGroupBox
            // 
            PlayerGroupBox.Controls.Add(PlayerChooseAFileLabel);
            PlayerGroupBox.Controls.Add(PlayerHowManyTimesNumericUpDown);
            PlayerGroupBox.Controls.Add(PlayerHowManyTimesLabel);
            PlayerGroupBox.Controls.Add(PlayerPlaybackSpeedLabel);
            PlayerGroupBox.Controls.Add(PlayerPlaybackSpeedComboBox);
            PlayerGroupBox.Controls.Add(PlayerPlaybackMethodLabel);
            PlayerGroupBox.Controls.Add(PlayerPlaybackMethodComboBox);
            PlayerGroupBox.Controls.Add(PlayerStopPlayingMacroButton);
            PlayerGroupBox.Controls.Add(PlayerStartPlayingMacroButton);
            PlayerGroupBox.Controls.Add(PlayerComboBox);
            PlayerGroupBox.Controls.Add(PlayerLabel);
            PlayerGroupBox.Location = new Point(269, 3);
            PlayerGroupBox.Margin = new Padding(4, 3, 4, 3);
            PlayerGroupBox.Name = "PlayerGroupBox";
            PlayerGroupBox.Padding = new Padding(4, 3, 4, 3);
            PlayerGroupBox.Size = new Size(260, 337);
            PlayerGroupBox.TabIndex = 13;
            PlayerGroupBox.TabStop = false;
            // 
            // PlayerChooseAFileLabel
            // 
            PlayerChooseAFileLabel.AutoSize = true;
            PlayerChooseAFileLabel.Location = new Point(8, 50);
            PlayerChooseAFileLabel.Name = "PlayerChooseAFileLabel";
            PlayerChooseAFileLabel.Size = new Size(78, 15);
            PlayerChooseAFileLabel.TabIndex = 27;
            PlayerChooseAFileLabel.Text = "Choose a file:";
            // 
            // PlayerHowManyTimesNumericUpDown
            // 
            PlayerHowManyTimesNumericUpDown.Location = new Point(9, 270);
            PlayerHowManyTimesNumericUpDown.Name = "PlayerHowManyTimesNumericUpDown";
            PlayerHowManyTimesNumericUpDown.Size = new Size(120, 23);
            PlayerHowManyTimesNumericUpDown.TabIndex = 26;
            PlayerHowManyTimesNumericUpDown.Visible = false;
            // 
            // PlayerHowManyTimesLabel
            // 
            PlayerHowManyTimesLabel.AutoSize = true;
            PlayerHowManyTimesLabel.Location = new Point(9, 252);
            PlayerHowManyTimesLabel.Margin = new Padding(4, 0, 4, 0);
            PlayerHowManyTimesLabel.Name = "PlayerHowManyTimesLabel";
            PlayerHowManyTimesLabel.Size = new Size(98, 15);
            PlayerHowManyTimesLabel.TabIndex = 25;
            PlayerHowManyTimesLabel.Text = "How may times ?";
            PlayerHowManyTimesLabel.Visible = false;
            // 
            // PlayerPlaybackSpeedLabel
            // 
            PlayerPlaybackSpeedLabel.AutoSize = true;
            PlayerPlaybackSpeedLabel.Location = new Point(156, 208);
            PlayerPlaybackSpeedLabel.Margin = new Padding(4, 0, 4, 0);
            PlayerPlaybackSpeedLabel.Name = "PlayerPlaybackSpeedLabel";
            PlayerPlaybackSpeedLabel.Size = new Size(88, 15);
            PlayerPlaybackSpeedLabel.TabIndex = 19;
            PlayerPlaybackSpeedLabel.Text = "playback speed";
            // 
            // PlayerPlaybackSpeedComboBox
            // 
            PlayerPlaybackSpeedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PlayerPlaybackSpeedComboBox.FormattingEnabled = true;
            PlayerPlaybackSpeedComboBox.Items.AddRange(new object[] { "0,25x", "0,5x", "0,75x", "1x", "2x", "3x", "4x", "5x", "10x" });
            PlayerPlaybackSpeedComboBox.Location = new Point(156, 226);
            PlayerPlaybackSpeedComboBox.Margin = new Padding(4, 3, 4, 3);
            PlayerPlaybackSpeedComboBox.Name = "PlayerPlaybackSpeedComboBox";
            PlayerPlaybackSpeedComboBox.Size = new Size(92, 23);
            PlayerPlaybackSpeedComboBox.TabIndex = 20;
            // 
            // PlayerPlaybackMethodLabel
            // 
            PlayerPlaybackMethodLabel.AutoSize = true;
            PlayerPlaybackMethodLabel.Location = new Point(8, 208);
            PlayerPlaybackMethodLabel.Margin = new Padding(4, 0, 4, 0);
            PlayerPlaybackMethodLabel.Name = "PlayerPlaybackMethodLabel";
            PlayerPlaybackMethodLabel.Size = new Size(99, 15);
            PlayerPlaybackMethodLabel.TabIndex = 17;
            PlayerPlaybackMethodLabel.Text = "playback method";
            // 
            // PlayerPlaybackMethodComboBox
            // 
            PlayerPlaybackMethodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PlayerPlaybackMethodComboBox.FormattingEnabled = true;
            PlayerPlaybackMethodComboBox.Items.AddRange(new object[] { "One time play", "Play X times", "Repeat until stopped" });
            PlayerPlaybackMethodComboBox.Location = new Point(8, 226);
            PlayerPlaybackMethodComboBox.Margin = new Padding(4, 3, 4, 3);
            PlayerPlaybackMethodComboBox.Name = "PlayerPlaybackMethodComboBox";
            PlayerPlaybackMethodComboBox.Size = new Size(140, 23);
            PlayerPlaybackMethodComboBox.TabIndex = 18;
            PlayerPlaybackMethodComboBox.SelectedIndexChanged += PlayerPlaybackMethodComboBox_SelectedIndexChanged;
            // 
            // PlayerStopPlayingMacroButton
            // 
            PlayerStopPlayingMacroButton.BackColor = Color.White;
            PlayerStopPlayingMacroButton.Enabled = false;
            PlayerStopPlayingMacroButton.ForeColor = SystemColors.ControlText;
            PlayerStopPlayingMacroButton.Location = new Point(8, 153);
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
            PlayerStartPlayingMacroButton.Location = new Point(8, 95);
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
            PlayerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PlayerComboBox.FormattingEnabled = true;
            PlayerComboBox.Location = new Point(8, 68);
            PlayerComboBox.Margin = new Padding(4, 3, 4, 3);
            PlayerComboBox.Name = "PlayerComboBox";
            PlayerComboBox.Size = new Size(210, 23);
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
            tableLayoutPanel1.Location = new Point(16, 65);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(537, 347);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // SettingsButton
            // 
            SettingsButton.BackColor = Color.White;
            SettingsButton.ForeColor = SystemColors.ControlText;
            SettingsButton.Location = new Point(478, 5);
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
            ClientSize = new Size(566, 424);
            Controls.Add(SettingsButton);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "RePlayerForm";
            ShowIcon = false;
            Load += Form1_Load;
            RecorderGroupBox.ResumeLayout(false);
            RecorderGroupBox.PerformLayout();
            PlayerGroupBox.ResumeLayout(false);
            PlayerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PlayerHowManyTimesNumericUpDown).EndInit();
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
        private System.Windows.Forms.Label PlayerPlaybackMethodLabel;
        private System.Windows.Forms.Label PlayerPlaybackSpeedLabel;
        private System.Windows.Forms.ComboBox PlayerPlaybackSpeedComboBox;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Timer timer1;
        private NumericUpDown PlayerHowManyTimesNumericUpDown;
        private Label PlayerHowManyTimesLabel;
        private Label PlayerChooseAFileLabel;
    }
}

