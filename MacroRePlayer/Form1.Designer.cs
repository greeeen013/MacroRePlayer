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
            this.EditorLabel = new System.Windows.Forms.Label();
            this.RecorderGroupBox = new System.Windows.Forms.GroupBox();
            this.PlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.EditorGroupBox = new System.Windows.Forms.GroupBox();
            this.EditorEventPanel = new System.Windows.Forms.Panel();
            this.JsonFileSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.EditorSaveButton = new System.Windows.Forms.Button();
            this.RecorderGroupBox.SuspendLayout();
            this.PlayerGroupBox.SuspendLayout();
            this.EditorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartRecording
            // 
            this.StartRecording.BackColor = System.Drawing.Color.Black;
            this.StartRecording.ForeColor = System.Drawing.SystemColors.Control;
            this.StartRecording.Location = new System.Drawing.Point(23, 134);
            this.StartRecording.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartRecording.Name = "StartRecording";
            this.StartRecording.Size = new System.Drawing.Size(220, 55);
            this.StartRecording.TabIndex = 0;
            this.StartRecording.Text = "Start Recording";
            this.StartRecording.UseVisualStyleBackColor = false;
            this.StartRecording.Click += new System.EventHandler(this.StartRecording_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title.Location = new System.Drawing.Point(13, 9);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(187, 29);
            this.title.TabIndex = 2;
            this.title.Text = "MacroRePlayer";
            // 
            // StopRecording
            // 
            this.StopRecording.BackColor = System.Drawing.Color.Black;
            this.StopRecording.ForeColor = System.Drawing.SystemColors.Control;
            this.StopRecording.Location = new System.Drawing.Point(23, 197);
            this.StopRecording.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StopRecording.Name = "StopRecording";
            this.StopRecording.Size = new System.Drawing.Size(220, 55);
            this.StopRecording.TabIndex = 3;
            this.StopRecording.Text = "StopRecording";
            this.StopRecording.UseVisualStyleBackColor = false;
            this.StopRecording.Visible = false;
            this.StopRecording.Click += new System.EventHandler(this.StopRecording_Click);
            // 
            // JsonFileSelectorForm
            // 
            this.JsonFileSelectorForm.Location = new System.Drawing.Point(23, 101);
            this.JsonFileSelectorForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.JsonFileSelectorForm.Name = "JsonFileSelectorForm";
            this.JsonFileSelectorForm.Size = new System.Drawing.Size(219, 22);
            this.JsonFileSelectorForm.TabIndex = 4;
            // 
            // JsonFileSelectorLabel
            // 
            this.JsonFileSelectorLabel.AutoSize = true;
            this.JsonFileSelectorLabel.Location = new System.Drawing.Point(17, 81);
            this.JsonFileSelectorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.JsonFileSelectorLabel.Name = "JsonFileSelectorLabel";
            this.JsonFileSelectorLabel.Size = new System.Drawing.Size(102, 16);
            this.JsonFileSelectorLabel.TabIndex = 5;
            this.JsonFileSelectorLabel.Text = "Název záznamu";
            // 
            // JsonFileSelectorLabelJson
            // 
            this.JsonFileSelectorLabelJson.AutoSize = true;
            this.JsonFileSelectorLabelJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.JsonFileSelectorLabelJson.Location = new System.Drawing.Point(241, 102);
            this.JsonFileSelectorLabelJson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.JsonFileSelectorLabelJson.Name = "JsonFileSelectorLabelJson";
            this.JsonFileSelectorLabelJson.Size = new System.Drawing.Size(40, 18);
            this.JsonFileSelectorLabelJson.TabIndex = 6;
            this.JsonFileSelectorLabelJson.Text = ".json";
            // 
            // FolderOpenerButton
            // 
            this.FolderOpenerButton.BackColor = System.Drawing.Color.Black;
            this.FolderOpenerButton.ForeColor = System.Drawing.SystemColors.Control;
            this.FolderOpenerButton.Location = new System.Drawing.Point(79, 260);
            this.FolderOpenerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FolderOpenerButton.Name = "FolderOpenerButton";
            this.FolderOpenerButton.Size = new System.Drawing.Size(91, 63);
            this.FolderOpenerButton.TabIndex = 7;
            this.FolderOpenerButton.Text = "Folder";
            this.FolderOpenerButton.UseVisualStyleBackColor = false;
            this.FolderOpenerButton.Click += new System.EventHandler(this.FolderOpenerButton_Click);
            // 
            // RecorderLabel
            // 
            this.RecorderLabel.AutoSize = true;
            this.RecorderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RecorderLabel.Location = new System.Drawing.Point(88, 20);
            this.RecorderLabel.Name = "RecorderLabel";
            this.RecorderLabel.Size = new System.Drawing.Size(91, 25);
            this.RecorderLabel.TabIndex = 8;
            this.RecorderLabel.Text = "Recorder";
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlayerLabel.Location = new System.Drawing.Point(96, 20);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(67, 25);
            this.PlayerLabel.TabIndex = 9;
            this.PlayerLabel.Text = "Player";
            // 
            // EditorLabel
            // 
            this.EditorLabel.AutoSize = true;
            this.EditorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EditorLabel.Location = new System.Drawing.Point(108, 20);
            this.EditorLabel.Name = "EditorLabel";
            this.EditorLabel.Size = new System.Drawing.Size(62, 25);
            this.EditorLabel.TabIndex = 10;
            this.EditorLabel.Text = "Editor";
            // 
            // RecorderGroupBox
            // 
            this.RecorderGroupBox.Controls.Add(this.RecorderLabel);
            this.RecorderGroupBox.Controls.Add(this.StartRecording);
            this.RecorderGroupBox.Controls.Add(this.StopRecording);
            this.RecorderGroupBox.Controls.Add(this.JsonFileSelectorForm);
            this.RecorderGroupBox.Controls.Add(this.FolderOpenerButton);
            this.RecorderGroupBox.Controls.Add(this.JsonFileSelectorLabel);
            this.RecorderGroupBox.Controls.Add(this.JsonFileSelectorLabelJson);
            this.RecorderGroupBox.Location = new System.Drawing.Point(20, 69);
            this.RecorderGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RecorderGroupBox.Name = "RecorderGroupBox";
            this.RecorderGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RecorderGroupBox.Size = new System.Drawing.Size(293, 370);
            this.RecorderGroupBox.TabIndex = 11;
            this.RecorderGroupBox.TabStop = false;
            // 
            // PlayerGroupBox
            // 
            this.PlayerGroupBox.Controls.Add(this.PlayerLabel);
            this.PlayerGroupBox.Location = new System.Drawing.Point(898, 69);
            this.PlayerGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlayerGroupBox.Name = "PlayerGroupBox";
            this.PlayerGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlayerGroupBox.Size = new System.Drawing.Size(267, 370);
            this.PlayerGroupBox.TabIndex = 12;
            this.PlayerGroupBox.TabStop = false;
            // 
            // EditorGroupBox
            // 
            this.EditorGroupBox.Controls.Add(this.EditorSaveButton);
            this.EditorGroupBox.Controls.Add(this.EditorEventPanel);
            this.EditorGroupBox.Controls.Add(this.JsonFileSelectorComboBox);
            this.EditorGroupBox.Controls.Add(this.EditorLabel);
            this.EditorGroupBox.Location = new System.Drawing.Point(321, 69);
            this.EditorGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditorGroupBox.Name = "EditorGroupBox";
            this.EditorGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditorGroupBox.Size = new System.Drawing.Size(569, 411);
            this.EditorGroupBox.TabIndex = 13;
            this.EditorGroupBox.TabStop = false;
            // 
            // EditorEventPanel
            // 
            this.EditorEventPanel.AutoScroll = true;
            this.EditorEventPanel.Location = new System.Drawing.Point(8, 102);
            this.EditorEventPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditorEventPanel.Name = "EditorEventPanel";
            this.EditorEventPanel.Size = new System.Drawing.Size(553, 258);
            this.EditorEventPanel.TabIndex = 14;
            // 
            // JsonFileSelectorComboBox
            // 
            this.JsonFileSelectorComboBox.FormattingEnabled = true;
            this.JsonFileSelectorComboBox.Location = new System.Drawing.Point(64, 48);
            this.JsonFileSelectorComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.JsonFileSelectorComboBox.Name = "JsonFileSelectorComboBox";
            this.JsonFileSelectorComboBox.Size = new System.Drawing.Size(160, 24);
            this.JsonFileSelectorComboBox.TabIndex = 11;
            this.JsonFileSelectorComboBox.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.JsonFileSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.JsonFileSelectorComboBox_SelectedIndexChanged);
            // 
            // EditorSaveButton
            // 
            this.EditorSaveButton.Location = new System.Drawing.Point(23, 368);
            this.EditorSaveButton.Name = "EditorSaveButton";
            this.EditorSaveButton.Size = new System.Drawing.Size(75, 23);
            this.EditorSaveButton.TabIndex = 15;
            this.EditorSaveButton.Text = "SAVE";
            this.EditorSaveButton.UseVisualStyleBackColor = true;
            this.EditorSaveButton.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1189, 548);
            this.Controls.Add(this.EditorGroupBox);
            this.Controls.Add(this.PlayerGroupBox);
            this.Controls.Add(this.RecorderGroupBox);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.RecorderGroupBox.ResumeLayout(false);
            this.RecorderGroupBox.PerformLayout();
            this.PlayerGroupBox.ResumeLayout(false);
            this.PlayerGroupBox.PerformLayout();
            this.EditorGroupBox.ResumeLayout(false);
            this.EditorGroupBox.PerformLayout();
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
        private System.Windows.Forms.Label EditorLabel;
        private System.Windows.Forms.GroupBox RecorderGroupBox;
        private System.Windows.Forms.GroupBox PlayerGroupBox;
        private System.Windows.Forms.GroupBox EditorGroupBox;
        private System.Windows.Forms.ComboBox JsonFileSelectorComboBox;
        private System.Windows.Forms.Panel EditorEventPanel;
        private System.Windows.Forms.Button EditorSaveButton;
    }
}

