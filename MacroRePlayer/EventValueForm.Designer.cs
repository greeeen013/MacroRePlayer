namespace MacroRePlayer.EventValueForms
{
    partial class EventValueForm
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
            EventValueButtonComboBox = new ComboBox();
            EventValueMouseKeyLabel = new Label();
            EventValueMouseFirstLabel = new Label();
            EventValueMouseSecondLabel = new Label();
            EventValueFirstTextBox = new TextBox();
            EventValueSecondsTextBox = new TextBox();
            EventValueMouseOkButton = new Button();
            EventValueMouseCancelButton = new Button();
            EventValueMouseHelpButton = new Button();
            EventValueMouseTypeOfEventLabel = new Label();
            EventValueTypeOfEventComboBox = new ComboBox();
            EventValueRecordButtonButton = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // EventValueButtonComboBox
            // 
            EventValueButtonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            EventValueButtonComboBox.FormattingEnabled = true;
            EventValueButtonComboBox.Items.AddRange(new object[] { "Left", "Right", "Middle" });
            EventValueButtonComboBox.Location = new Point(160, 134);
            EventValueButtonComboBox.Margin = new Padding(4, 3, 4, 3);
            EventValueButtonComboBox.Name = "EventValueButtonComboBox";
            EventValueButtonComboBox.Size = new Size(135, 23);
            EventValueButtonComboBox.TabIndex = 22;
            // 
            // EventValueMouseKeyLabel
            // 
            EventValueMouseKeyLabel.AutoSize = true;
            EventValueMouseKeyLabel.Location = new Point(161, 112);
            EventValueMouseKeyLabel.Margin = new Padding(4, 0, 4, 0);
            EventValueMouseKeyLabel.Name = "EventValueMouseKeyLabel";
            EventValueMouseKeyLabel.Size = new Size(46, 15);
            EventValueMouseKeyLabel.TabIndex = 23;
            EventValueMouseKeyLabel.Text = "Button:";
            // 
            // EventValueMouseFirstLabel
            // 
            EventValueMouseFirstLabel.AutoSize = true;
            EventValueMouseFirstLabel.Location = new Point(14, 162);
            EventValueMouseFirstLabel.Margin = new Padding(4, 0, 4, 0);
            EventValueMouseFirstLabel.Name = "EventValueMouseFirstLabel";
            EventValueMouseFirstLabel.Size = new Size(17, 15);
            EventValueMouseFirstLabel.TabIndex = 24;
            EventValueMouseFirstLabel.Text = "X:";
            // 
            // EventValueMouseSecondLabel
            // 
            EventValueMouseSecondLabel.AutoSize = true;
            EventValueMouseSecondLabel.Location = new Point(14, 207);
            EventValueMouseSecondLabel.Margin = new Padding(4, 0, 4, 0);
            EventValueMouseSecondLabel.Name = "EventValueMouseSecondLabel";
            EventValueMouseSecondLabel.Size = new Size(17, 15);
            EventValueMouseSecondLabel.TabIndex = 25;
            EventValueMouseSecondLabel.Text = "Y:";
            // 
            // EventValueFirstTextBox
            // 
            EventValueFirstTextBox.Location = new Point(18, 180);
            EventValueFirstTextBox.Margin = new Padding(4, 3, 4, 3);
            EventValueFirstTextBox.Name = "EventValueFirstTextBox";
            EventValueFirstTextBox.Size = new Size(116, 23);
            EventValueFirstTextBox.TabIndex = 26;
            // 
            // EventValueSecondsTextBox
            // 
            EventValueSecondsTextBox.Location = new Point(18, 225);
            EventValueSecondsTextBox.Margin = new Padding(4, 3, 4, 3);
            EventValueSecondsTextBox.Name = "EventValueSecondsTextBox";
            EventValueSecondsTextBox.Size = new Size(116, 23);
            EventValueSecondsTextBox.TabIndex = 27;
            // 
            // EventValueMouseOkButton
            // 
            EventValueMouseOkButton.Location = new Point(62, 267);
            EventValueMouseOkButton.Margin = new Padding(4, 3, 4, 3);
            EventValueMouseOkButton.Name = "EventValueMouseOkButton";
            EventValueMouseOkButton.Size = new Size(88, 27);
            EventValueMouseOkButton.TabIndex = 28;
            EventValueMouseOkButton.Text = "OK";
            EventValueMouseOkButton.UseVisualStyleBackColor = true;
            EventValueMouseOkButton.Click += EventValueMouseOkButton_Click;
            // 
            // EventValueMouseCancelButton
            // 
            EventValueMouseCancelButton.Location = new Point(156, 267);
            EventValueMouseCancelButton.Margin = new Padding(4, 3, 4, 3);
            EventValueMouseCancelButton.Name = "EventValueMouseCancelButton";
            EventValueMouseCancelButton.Size = new Size(88, 27);
            EventValueMouseCancelButton.TabIndex = 29;
            EventValueMouseCancelButton.Text = "Cancel";
            EventValueMouseCancelButton.UseVisualStyleBackColor = true;
            // 
            // EventValueMouseHelpButton
            // 
            EventValueMouseHelpButton.Location = new Point(251, 267);
            EventValueMouseHelpButton.Margin = new Padding(4, 3, 4, 3);
            EventValueMouseHelpButton.Name = "EventValueMouseHelpButton";
            EventValueMouseHelpButton.Size = new Size(88, 27);
            EventValueMouseHelpButton.TabIndex = 30;
            EventValueMouseHelpButton.Text = "Help";
            EventValueMouseHelpButton.UseVisualStyleBackColor = true;
            // 
            // EventValueMouseTypeOfEventLabel
            // 
            EventValueMouseTypeOfEventLabel.AutoSize = true;
            EventValueMouseTypeOfEventLabel.Location = new Point(14, 112);
            EventValueMouseTypeOfEventLabel.Margin = new Padding(4, 0, 4, 0);
            EventValueMouseTypeOfEventLabel.Name = "EventValueMouseTypeOfEventLabel";
            EventValueMouseTypeOfEventLabel.Size = new Size(80, 15);
            EventValueMouseTypeOfEventLabel.TabIndex = 31;
            EventValueMouseTypeOfEventLabel.Text = "Type of event:";
            // 
            // EventValueTypeOfEventComboBox
            // 
            EventValueTypeOfEventComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            EventValueTypeOfEventComboBox.FormattingEnabled = true;
            EventValueTypeOfEventComboBox.Location = new Point(18, 134);
            EventValueTypeOfEventComboBox.Margin = new Padding(4, 3, 4, 3);
            EventValueTypeOfEventComboBox.Name = "EventValueTypeOfEventComboBox";
            EventValueTypeOfEventComboBox.Size = new Size(135, 23);
            EventValueTypeOfEventComboBox.TabIndex = 32;
            EventValueTypeOfEventComboBox.SelectedIndexChanged += EventValueTypeOfEventComboBox_SelectedIndexChanged;
            // 
            // EventValueRecordButtonButton
            // 
            EventValueRecordButtonButton.Location = new Point(41, 180);
            EventValueRecordButtonButton.Margin = new Padding(4, 3, 4, 3);
            EventValueRecordButtonButton.Name = "EventValueRecordButtonButton";
            EventValueRecordButtonButton.Size = new Size(70, 46);
            EventValueRecordButtonButton.TabIndex = 33;
            EventValueRecordButtonButton.Text = "Record button";
            EventValueRecordButtonButton.UseVisualStyleBackColor = true;
            EventValueRecordButtonButton.Click += EventValueRecordButtonButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            richTextBox1.Location = new Point(48, 14);
            richTextBox1.Margin = new Padding(4, 3, 4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(86, 71);
            richTextBox1.TabIndex = 34;
            richTextBox1.Text = "TEST";
            // 
            // EventValueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 306);
            Controls.Add(richTextBox1);
            Controls.Add(EventValueRecordButtonButton);
            Controls.Add(EventValueTypeOfEventComboBox);
            Controls.Add(EventValueMouseTypeOfEventLabel);
            Controls.Add(EventValueMouseHelpButton);
            Controls.Add(EventValueMouseCancelButton);
            Controls.Add(EventValueMouseOkButton);
            Controls.Add(EventValueSecondsTextBox);
            Controls.Add(EventValueFirstTextBox);
            Controls.Add(EventValueMouseSecondLabel);
            Controls.Add(EventValueMouseFirstLabel);
            Controls.Add(EventValueMouseKeyLabel);
            Controls.Add(EventValueButtonComboBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "EventValueForm";
            Text = "EventValueForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EventValueButtonComboBox;
        private System.Windows.Forms.Label EventValueMouseKeyLabel;
        private System.Windows.Forms.Label EventValueMouseFirstLabel;
        private System.Windows.Forms.Label EventValueMouseSecondLabel;
        private System.Windows.Forms.TextBox EventValueFirstTextBox;
        private System.Windows.Forms.TextBox EventValueSecondsTextBox;
        private System.Windows.Forms.Button EventValueMouseOkButton;
        private System.Windows.Forms.Button EventValueMouseCancelButton;
        private System.Windows.Forms.Button EventValueMouseHelpButton;
        private System.Windows.Forms.Label EventValueMouseTypeOfEventLabel;
        private System.Windows.Forms.ComboBox EventValueTypeOfEventComboBox;
        private System.Windows.Forms.Button EventValueRecordButtonButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}