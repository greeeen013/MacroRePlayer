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
            this.OpenEditorButton = new System.Windows.Forms.Button();
            this.PlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.EditorGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RecorderGroupBox.SuspendLayout();
            this.PlayerGroupBox.SuspendLayout();
            this.EditorGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartRecording
            // 
            this.StartRecording.BackColor = System.Drawing.Color.White;
            this.StartRecording.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartRecording.Location = new System.Drawing.Point(17, 109);
            this.StartRecording.Name = "StartRecording";
            this.StartRecording.Size = new System.Drawing.Size(165, 45);
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
            this.StopRecording.Size = new System.Drawing.Size(165, 45);
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
            this.FolderOpenerButton.BackColor = System.Drawing.Color.Black;
            this.FolderOpenerButton.ForeColor = System.Drawing.SystemColors.Control;
            this.FolderOpenerButton.Location = new System.Drawing.Point(17, 211);
            this.FolderOpenerButton.Name = "FolderOpenerButton";
            this.FolderOpenerButton.Size = new System.Drawing.Size(68, 51);
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
            this.PlayerLabel.Location = new System.Drawing.Point(72, 16);
            this.PlayerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(52, 20);
            this.PlayerLabel.TabIndex = 9;
            this.PlayerLabel.Text = "Player";
            // 
            // EditorLabel
            // 
            this.EditorLabel.AutoSize = true;
            this.EditorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EditorLabel.Location = new System.Drawing.Point(81, 16);
            this.EditorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EditorLabel.Name = "EditorLabel";
            this.EditorLabel.Size = new System.Drawing.Size(51, 20);
            this.EditorLabel.TabIndex = 10;
            this.EditorLabel.Text = "Editor";
            // 
            // RecorderGroupBox
            // 
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
            // OpenEditorButton
            // 
            this.OpenEditorButton.Location = new System.Drawing.Point(52, 268);
            this.OpenEditorButton.Name = "OpenEditorButton";
            this.OpenEditorButton.Size = new System.Drawing.Size(75, 23);
            this.OpenEditorButton.TabIndex = 15;
            this.OpenEditorButton.Text = "Open Editor";
            this.OpenEditorButton.UseVisualStyleBackColor = true;
            this.OpenEditorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PlayerGroupBox
            // 
            this.PlayerGroupBox.Controls.Add(this.PlayerLabel);
            this.PlayerGroupBox.Location = new System.Drawing.Point(423, 3);
            this.PlayerGroupBox.Name = "PlayerGroupBox";
            this.PlayerGroupBox.Size = new System.Drawing.Size(265, 402);
            this.PlayerGroupBox.TabIndex = 12;
            this.PlayerGroupBox.TabStop = false;
            // 
            // EditorGroupBox
            // 
            this.EditorGroupBox.Controls.Add(this.EditorLabel);
            this.EditorGroupBox.Location = new System.Drawing.Point(229, 3);
            this.EditorGroupBox.Name = "EditorGroupBox";
            this.EditorGroupBox.Size = new System.Drawing.Size(188, 402);
            this.EditorGroupBox.TabIndex = 13;
            this.EditorGroupBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.RecorderGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayerGroupBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.EditorGroupBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 72);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(967, 417);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1011, 635);
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
            this.EditorGroupBox.ResumeLayout(false);
            this.EditorGroupBox.PerformLayout();
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
        private System.Windows.Forms.Label EditorLabel;
        private System.Windows.Forms.GroupBox RecorderGroupBox;
        private System.Windows.Forms.GroupBox PlayerGroupBox;
        private System.Windows.Forms.GroupBox EditorGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button OpenEditorButton;
    }
}

