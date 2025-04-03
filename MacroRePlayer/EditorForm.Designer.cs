namespace MacroRePlayer
{
    partial class EditorForm
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
            this.EventNamesOnlyList = new System.Windows.Forms.ListBox();
            this.JsonFileSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // EventNamesOnlyList
            // 
            this.EventNamesOnlyList.FormattingEnabled = true;
            this.EventNamesOnlyList.Location = new System.Drawing.Point(232, 246);
            this.EventNamesOnlyList.Name = "EventNamesOnlyList";
            this.EventNamesOnlyList.Size = new System.Drawing.Size(120, 95);
            this.EventNamesOnlyList.TabIndex = 0;
            this.EventNamesOnlyList.SelectedIndexChanged += new System.EventHandler(this.EventNamesOnlyList_SelectionChanged);
            // 
            // JsonFileSelectorComboBox
            // 
            this.JsonFileSelectorComboBox.FormattingEnabled = true;
            this.JsonFileSelectorComboBox.Location = new System.Drawing.Point(231, 219);
            this.JsonFileSelectorComboBox.Name = "JsonFileSelectorComboBox";
            this.JsonFileSelectorComboBox.Size = new System.Drawing.Size(121, 21);
            this.JsonFileSelectorComboBox.TabIndex = 12;
            this.JsonFileSelectorComboBox.DropDown += new System.EventHandler(this.JsonFileSelectorComboBox_DropDown);
            this.JsonFileSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.JsonFileSelectorComboBox_SelectedIndexChanged);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.JsonFileSelectorComboBox);
            this.Controls.Add(this.EventNamesOnlyList);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox EventNamesOnlyList;
        private System.Windows.Forms.ComboBox JsonFileSelectorComboBox;
    }
}