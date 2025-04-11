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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            JsonFileSelectorComboBox = new ComboBox();
            EditorFormButtonSave = new Button();
            EditorFormContextMenuEvents = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            delayEventToolStripMenuItem = new ToolStripMenuItem();
            mouseDownEventToolStripMenuItem = new ToolStripMenuItem();
            mouseUpEventToolStripMenuItem = new ToolStripMenuItem();
            keyDownEventToolStripMenuItem = new ToolStripMenuItem();
            keyUpEventToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            startLoopEventToolStripMenuItem = new ToolStripMenuItem();
            stopLoopEventToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            EditorFormToolTip = new ToolTip(components);
            EditorEventsDataGridView = new DataGridView();
            EditorIconColumn = new DataGridViewImageColumn();
            EditorEventColumn = new DataGridViewTextBoxColumn();
            EditorValueColumn = new DataGridViewTextBoxColumn();
            SecretValue = new DataGridViewTextBoxColumn();
            EditorCommentColumn = new DataGridViewTextBoxColumn();
            EditorChooseAFileLabel = new Label();
            EditorFormContextMenuEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EditorEventsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // JsonFileSelectorComboBox
            // 
            JsonFileSelectorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            JsonFileSelectorComboBox.FormattingEnabled = true;
            JsonFileSelectorComboBox.Location = new Point(13, 28);
            JsonFileSelectorComboBox.Margin = new Padding(4, 3, 4, 3);
            JsonFileSelectorComboBox.Name = "JsonFileSelectorComboBox";
            JsonFileSelectorComboBox.Size = new Size(140, 23);
            JsonFileSelectorComboBox.TabIndex = 12;
            JsonFileSelectorComboBox.DropDown += JsonFileSelectorComboBox_DropDown;
            JsonFileSelectorComboBox.SelectedIndexChanged += JsonFileSelectorComboBox_SelectedIndexChanged;
            // 
            // EditorFormButtonSave
            // 
            EditorFormButtonSave.Location = new Point(13, 420);
            EditorFormButtonSave.Margin = new Padding(4, 3, 4, 3);
            EditorFormButtonSave.Name = "EditorFormButtonSave";
            EditorFormButtonSave.Size = new Size(506, 27);
            EditorFormButtonSave.TabIndex = 13;
            EditorFormButtonSave.Text = "Save";
            EditorFormButtonSave.UseVisualStyleBackColor = true;
            EditorFormButtonSave.Click += Save_Click;
            // 
            // EditorFormContextMenuEvents
            // 
            EditorFormContextMenuEvents.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3 });
            EditorFormContextMenuEvents.Name = "contextMenuStrip1";
            EditorFormContextMenuEvents.Size = new Size(181, 70);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { delayEventToolStripMenuItem, mouseDownEventToolStripMenuItem, mouseUpEventToolStripMenuItem, keyDownEventToolStripMenuItem, keyUpEventToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "BasicEvents";
            // 
            // delayEventToolStripMenuItem
            // 
            delayEventToolStripMenuItem.Name = "delayEventToolStripMenuItem";
            delayEventToolStripMenuItem.Size = new Size(170, 22);
            delayEventToolStripMenuItem.Text = "DelayEvent";
            // 
            // mouseDownEventToolStripMenuItem
            // 
            mouseDownEventToolStripMenuItem.Name = "mouseDownEventToolStripMenuItem";
            mouseDownEventToolStripMenuItem.Size = new Size(170, 22);
            mouseDownEventToolStripMenuItem.Text = "MouseDownEvent";
            // 
            // mouseUpEventToolStripMenuItem
            // 
            mouseUpEventToolStripMenuItem.Name = "mouseUpEventToolStripMenuItem";
            mouseUpEventToolStripMenuItem.Size = new Size(170, 22);
            mouseUpEventToolStripMenuItem.Text = "MouseUpEvent";
            // 
            // keyDownEventToolStripMenuItem
            // 
            keyDownEventToolStripMenuItem.Name = "keyDownEventToolStripMenuItem";
            keyDownEventToolStripMenuItem.Size = new Size(170, 22);
            keyDownEventToolStripMenuItem.Text = "KeyDownEvent";
            // 
            // keyUpEventToolStripMenuItem
            // 
            keyUpEventToolStripMenuItem.Name = "keyUpEventToolStripMenuItem";
            keyUpEventToolStripMenuItem.Size = new Size(170, 22);
            keyUpEventToolStripMenuItem.Text = "KeyUpEvent";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { startLoopEventToolStripMenuItem, stopLoopEventToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(180, 22);
            toolStripMenuItem2.Text = "LoopEvents";
            // 
            // startLoopEventToolStripMenuItem
            // 
            startLoopEventToolStripMenuItem.Name = "startLoopEventToolStripMenuItem";
            startLoopEventToolStripMenuItem.Size = new Size(154, 22);
            startLoopEventToolStripMenuItem.Text = "StartLoopEvent";
            // 
            // stopLoopEventToolStripMenuItem
            // 
            stopLoopEventToolStripMenuItem.Name = "stopLoopEventToolStripMenuItem";
            stopLoopEventToolStripMenuItem.Size = new Size(154, 22);
            stopLoopEventToolStripMenuItem.Text = "StopLoopEvent";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(180, 22);
            toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(496, 28);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(23, 23);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            EditorFormToolTip.SetToolTip(pictureBox1, "you can drag and drop between the events and soon many more feature lol");
            // 
            // EditorEventsDataGridView
            // 
            EditorEventsDataGridView.AllowUserToAddRows = false;
            EditorEventsDataGridView.AllowUserToResizeRows = false;
            EditorEventsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            EditorEventsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EditorEventsDataGridView.Columns.AddRange(new DataGridViewColumn[] { EditorIconColumn, EditorEventColumn, EditorValueColumn, SecretValue, EditorCommentColumn });
            EditorEventsDataGridView.Location = new Point(13, 57);
            EditorEventsDataGridView.Margin = new Padding(4, 3, 4, 3);
            EditorEventsDataGridView.Name = "EditorEventsDataGridView";
            EditorEventsDataGridView.RowHeadersVisible = false;
            EditorEventsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EditorEventsDataGridView.Size = new Size(506, 357);
            EditorEventsDataGridView.TabIndex = 23;
            EditorEventsDataGridView.CellDoubleClick += EditorEventsDataGridView_CellDoubleClick;
            EditorEventsDataGridView.SelectionChanged += EditorEventsDataGridView_SelectionChanged;
            EditorEventsDataGridView.MouseDown += EditorEventsDataGridView_MouseDown;
            EditorEventsDataGridView.MouseMove += EditorEventsDataGridView_MouseMove;
            EditorEventsDataGridView.MouseUp += EditorEventsDataGridView_MouseUp;
            // 
            // EditorIconColumn
            // 
            EditorIconColumn.HeaderText = "Icon";
            EditorIconColumn.Name = "EditorIconColumn";
            EditorIconColumn.ReadOnly = true;
            // 
            // EditorEventColumn
            // 
            EditorEventColumn.HeaderText = "Event";
            EditorEventColumn.Name = "EditorEventColumn";
            EditorEventColumn.ReadOnly = true;
            // 
            // EditorValueColumn
            // 
            EditorValueColumn.HeaderText = "Value";
            EditorValueColumn.Name = "EditorValueColumn";
            EditorValueColumn.ReadOnly = true;
            EditorValueColumn.Width = 200;
            // 
            // SecretValue
            // 
            SecretValue.HeaderText = "SecretValue";
            SecretValue.Name = "SecretValue";
            SecretValue.ReadOnly = true;
            SecretValue.Visible = false;
            // 
            // EditorCommentColumn
            // 
            EditorCommentColumn.HeaderText = "Comment";
            EditorCommentColumn.Name = "EditorCommentColumn";
            // 
            // EditorChooseAFileLabel
            // 
            EditorChooseAFileLabel.AutoSize = true;
            EditorChooseAFileLabel.Location = new Point(13, 10);
            EditorChooseAFileLabel.Name = "EditorChooseAFileLabel";
            EditorChooseAFileLabel.Size = new Size(78, 15);
            EditorChooseAFileLabel.TabIndex = 24;
            EditorChooseAFileLabel.Text = "Choose a file:";
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 458);
            Controls.Add(EditorChooseAFileLabel);
            Controls.Add(EditorEventsDataGridView);
            Controls.Add(pictureBox1);
            Controls.Add(EditorFormButtonSave);
            Controls.Add(JsonFileSelectorComboBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "EditorForm";
            Text = "EditorForm";
            Load += EditorForm_Load;
            EditorFormContextMenuEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EditorEventsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.DataGridView EditorEventsDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn EditorIconColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditorEventColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditorValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecretValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditorCommentColumn;
        private Label EditorChooseAFileLabel;
    }
}