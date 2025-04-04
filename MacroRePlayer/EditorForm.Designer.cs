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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.EventNamesOnlyList = new System.Windows.Forms.ListBox();
            this.JsonFileSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.EditorFormButtonUp = new System.Windows.Forms.Button();
            this.EditorFormButtonDown = new System.Windows.Forms.Button();
            this.EditorFormButtonDelete = new System.Windows.Forms.Button();
            this.EditorFormButtonCopy = new System.Windows.Forms.Button();
            this.EditorFormButtonPaste = new System.Windows.Forms.Button();
            this.EditorFormButtonExtract = new System.Windows.Forms.Button();
            this.EditorFormButtonAdd = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.delayEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseDownEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseUpEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyDownEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyUpEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.startLoopEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopLoopEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(231, 348);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 13;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // EditorFormButtonUp
            // 
            this.EditorFormButtonUp.Location = new System.Drawing.Point(358, 246);
            this.EditorFormButtonUp.Name = "EditorFormButtonUp";
            this.EditorFormButtonUp.Size = new System.Drawing.Size(75, 23);
            this.EditorFormButtonUp.TabIndex = 14;
            this.EditorFormButtonUp.Text = "▲ UP";
            this.EditorFormButtonUp.UseVisualStyleBackColor = true;
            this.EditorFormButtonUp.Click += new System.EventHandler(this.EditorFormButtonMoveUp_Click);
            // 
            // EditorFormButtonDown
            // 
            this.EditorFormButtonDown.Location = new System.Drawing.Point(359, 276);
            this.EditorFormButtonDown.Name = "EditorFormButtonDown";
            this.EditorFormButtonDown.Size = new System.Drawing.Size(75, 23);
            this.EditorFormButtonDown.TabIndex = 15;
            this.EditorFormButtonDown.Text = "▼ DOWN";
            this.EditorFormButtonDown.UseVisualStyleBackColor = true;
            this.EditorFormButtonDown.Click += new System.EventHandler(this.EditorFormButtonMoveDown_Click);
            // 
            // EditorFormButtonDelete
            // 
            this.EditorFormButtonDelete.Location = new System.Drawing.Point(359, 305);
            this.EditorFormButtonDelete.Name = "EditorFormButtonDelete";
            this.EditorFormButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.EditorFormButtonDelete.TabIndex = 16;
            this.EditorFormButtonDelete.Text = "🗑 Delete";
            this.EditorFormButtonDelete.UseVisualStyleBackColor = true;
            this.EditorFormButtonDelete.Click += new System.EventHandler(this.EditorFormButtonDelete_Click);
            // 
            // EditorFormButtonCopy
            // 
            this.EditorFormButtonCopy.Location = new System.Drawing.Point(359, 334);
            this.EditorFormButtonCopy.Name = "EditorFormButtonCopy";
            this.EditorFormButtonCopy.Size = new System.Drawing.Size(75, 23);
            this.EditorFormButtonCopy.TabIndex = 17;
            this.EditorFormButtonCopy.Text = "📋 Copy";
            this.EditorFormButtonCopy.UseVisualStyleBackColor = true;
            this.EditorFormButtonCopy.Click += new System.EventHandler(this.EditorFormButtonCopy_Click);
            // 
            // EditorFormButtonPaste
            // 
            this.EditorFormButtonPaste.Location = new System.Drawing.Point(358, 392);
            this.EditorFormButtonPaste.Name = "EditorFormButtonPaste";
            this.EditorFormButtonPaste.Size = new System.Drawing.Size(75, 23);
            this.EditorFormButtonPaste.TabIndex = 18;
            this.EditorFormButtonPaste.Text = "📋 Paste";
            this.EditorFormButtonPaste.UseVisualStyleBackColor = true;
            this.EditorFormButtonPaste.Click += new System.EventHandler(this.EditorFormButtonPaste_Click);
            // 
            // EditorFormButtonExtract
            // 
            this.EditorFormButtonExtract.Location = new System.Drawing.Point(359, 363);
            this.EditorFormButtonExtract.Name = "EditorFormButtonExtract";
            this.EditorFormButtonExtract.Size = new System.Drawing.Size(75, 23);
            this.EditorFormButtonExtract.TabIndex = 19;
            this.EditorFormButtonExtract.Text = "📋 Extract";
            this.EditorFormButtonExtract.UseVisualStyleBackColor = true;
            this.EditorFormButtonExtract.Click += new System.EventHandler(this.EditorFormButtonExtract_Click);
            // 
            // EditorFormButtonAdd
            // 
            this.EditorFormButtonAdd.Location = new System.Drawing.Point(439, 246);
            this.EditorFormButtonAdd.Name = "EditorFormButtonAdd";
            this.EditorFormButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.EditorFormButtonAdd.TabIndex = 20;
            this.EditorFormButtonAdd.Text = "✔ Add";
            this.EditorFormButtonAdd.UseVisualStyleBackColor = true;
            this.EditorFormButtonAdd.Click += new System.EventHandler(this.EditorFormButtonAdd_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delayEventToolStripMenuItem,
            this.mouseDownEventToolStripMenuItem,
            this.mouseUpEventToolStripMenuItem,
            this.keyDownEventToolStripMenuItem,
            this.keyUpEventToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "BasicEvents";
            // 
            // delayEventToolStripMenuItem
            // 
            this.delayEventToolStripMenuItem.Name = "delayEventToolStripMenuItem";
            this.delayEventToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.delayEventToolStripMenuItem.Text = "DelayEvent";
            // 
            // mouseDownEventToolStripMenuItem
            // 
            this.mouseDownEventToolStripMenuItem.Name = "mouseDownEventToolStripMenuItem";
            this.mouseDownEventToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.mouseDownEventToolStripMenuItem.Text = "MouseDownEvent";
            // 
            // mouseUpEventToolStripMenuItem
            // 
            this.mouseUpEventToolStripMenuItem.Name = "mouseUpEventToolStripMenuItem";
            this.mouseUpEventToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.mouseUpEventToolStripMenuItem.Text = "MouseUpEvent";
            // 
            // keyDownEventToolStripMenuItem
            // 
            this.keyDownEventToolStripMenuItem.Name = "keyDownEventToolStripMenuItem";
            this.keyDownEventToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.keyDownEventToolStripMenuItem.Text = "KeyDownEvent";
            // 
            // keyUpEventToolStripMenuItem
            // 
            this.keyUpEventToolStripMenuItem.Name = "keyUpEventToolStripMenuItem";
            this.keyUpEventToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.keyUpEventToolStripMenuItem.Text = "KeyUpEvent";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startLoopEventToolStripMenuItem,
            this.stopLoopEventToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "LoopEvents";
            // 
            // startLoopEventToolStripMenuItem
            // 
            this.startLoopEventToolStripMenuItem.Name = "startLoopEventToolStripMenuItem";
            this.startLoopEventToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.startLoopEventToolStripMenuItem.Text = "StartLoopEvent";
            // 
            // stopLoopEventToolStripMenuItem
            // 
            this.stopLoopEventToolStripMenuItem.Name = "stopLoopEventToolStripMenuItem";
            this.stopLoopEventToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.stopLoopEventToolStripMenuItem.Text = "StopLoopEvent";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(520, 246);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "LoopEvents must always be \r\nan opening loop and a closing loop! \r\nwithout this it" +
        " will not allow you to save \r\nthe program. :)");
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EditorFormButtonAdd);
            this.Controls.Add(this.EditorFormButtonExtract);
            this.Controls.Add(this.EditorFormButtonPaste);
            this.Controls.Add(this.EditorFormButtonCopy);
            this.Controls.Add(this.EditorFormButtonDelete);
            this.Controls.Add(this.EditorFormButtonDown);
            this.Controls.Add(this.EditorFormButtonUp);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.JsonFileSelectorComboBox);
            this.Controls.Add(this.EventNamesOnlyList);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox EventNamesOnlyList;
        private System.Windows.Forms.ComboBox JsonFileSelectorComboBox;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button EditorFormButtonUp;
        private System.Windows.Forms.Button EditorFormButtonDown;
        private System.Windows.Forms.Button EditorFormButtonDelete;
        private System.Windows.Forms.Button EditorFormButtonCopy;
        private System.Windows.Forms.Button EditorFormButtonPaste;
        private System.Windows.Forms.Button EditorFormButtonExtract;
        private System.Windows.Forms.Button EditorFormButtonAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem delayEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseDownEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseUpEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyDownEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyUpEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startLoopEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopLoopEventToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}