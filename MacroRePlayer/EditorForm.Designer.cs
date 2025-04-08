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
            this.JsonFileSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.EditorFormButtonSave = new System.Windows.Forms.Button();
            this.EditorFormContextMenuEvents = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.EditorFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.HoldTimer = new System.Windows.Forms.Timer(this.components);
            this.EditorEventsDataGridView = new System.Windows.Forms.DataGridView();
            this.EditorIconColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditorEventColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditorValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditorCommentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditorFormContextMenuEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditorEventsDataGridView)).BeginInit();
            this.SuspendLayout();
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
            // EditorFormButtonSave
            // 
            this.EditorFormButtonSave.Enabled = false;
            this.EditorFormButtonSave.Location = new System.Drawing.Point(249, 379);
            this.EditorFormButtonSave.Name = "EditorFormButtonSave";
            this.EditorFormButtonSave.Size = new System.Drawing.Size(75, 23);
            this.EditorFormButtonSave.TabIndex = 13;
            this.EditorFormButtonSave.Text = "Save";
            this.EditorFormButtonSave.UseVisualStyleBackColor = true;
            this.EditorFormButtonSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // EditorFormContextMenuEvents
            // 
            this.EditorFormContextMenuEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.EditorFormContextMenuEvents.Name = "contextMenuStrip1";
            this.EditorFormContextMenuEvents.Size = new System.Drawing.Size(181, 70);
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
            this.EditorFormToolTip.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // HoldTimer
            // 
            this.HoldTimer.Interval = 200;
            // 
            // EditorEventsDataGridView
            // 
            this.EditorEventsDataGridView.AllowUserToResizeRows = false;
            this.EditorEventsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.EditorEventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EditorEventsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditorIconColumn,
            this.EditorEventColumn,
            this.EditorValueColumn,
            this.EditorCommentColumn});
            this.EditorEventsDataGridView.Location = new System.Drawing.Point(26, 42);
            this.EditorEventsDataGridView.Name = "EditorEventsDataGridView";
            this.EditorEventsDataGridView.RowHeadersVisible = false;
            this.EditorEventsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EditorEventsDataGridView.Size = new System.Drawing.Size(650, 159);
            this.EditorEventsDataGridView.TabIndex = 23;
            this.EditorEventsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditorEventsDataGridView_CellDoubleClick);
            this.EditorEventsDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.EditorEventsDataGridView_DragDrop);
            this.EditorEventsDataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.EditorEventsDataGridView_DragOver);
            this.EditorEventsDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditorEventsDataGridView_MouseDown);
            this.EditorEventsDataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditorEventsDataGridView_MouseMove);
            this.EditorEventsDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EditorEventsDataGridView_MouseUp);
            // 
            // EditorIconColumn
            // 
            this.EditorIconColumn.HeaderText = "Icon";
            this.EditorIconColumn.Name = "EditorIconColumn";
            this.EditorIconColumn.ReadOnly = true;
            // 
            // EditorEventColumn
            // 
            this.EditorEventColumn.HeaderText = "Event";
            this.EditorEventColumn.Name = "EditorEventColumn";
            this.EditorEventColumn.ReadOnly = true;
            // 
            // EditorValueColumn
            // 
            this.EditorValueColumn.HeaderText = "Value";
            this.EditorValueColumn.Name = "EditorValueColumn";
            this.EditorValueColumn.ReadOnly = true;
            this.EditorValueColumn.Width = 200;
            // 
            // EditorCommentColumn
            // 
            this.EditorCommentColumn.HeaderText = "Comment";
            this.EditorCommentColumn.Name = "EditorCommentColumn";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EditorEventsDataGridView);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EditorFormButtonSave);
            this.Controls.Add(this.JsonFileSelectorComboBox);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.EditorFormContextMenuEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditorEventsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox JsonFileSelectorComboBox;
        private System.Windows.Forms.Button EditorFormButtonSave;
        private System.Windows.Forms.ContextMenuStrip EditorFormContextMenuEvents;
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
        private System.Windows.Forms.ToolTip EditorFormToolTip;
        private System.Windows.Forms.Timer HoldTimer;
        private System.Windows.Forms.DataGridView EditorEventsDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn EditorIconColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditorEventColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditorValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditorCommentColumn;
    }
}