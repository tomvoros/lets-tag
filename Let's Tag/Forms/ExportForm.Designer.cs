namespace LetsTag
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.delimiterTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldsListBox = new System.Windows.Forms.ListBox();
            this.fieldsToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.discNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.customStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveUpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mp3tagFormatStringLinkLabel = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.presetsToolStrip = new System.Windows.Forms.ToolStrip();
            this.removePresetToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.presetComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.exportSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.addPresetToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fieldsToolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.presetsToolStrip.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // delimiterTextBox
            // 
            this.delimiterTextBox.Location = new System.Drawing.Point(59, 3);
            this.delimiterTextBox.Name = "delimiterTextBox";
            this.delimiterTextBox.Size = new System.Drawing.Size(58, 20);
            this.delimiterTextBox.TabIndex = 3;
            this.delimiterTextBox.Text = "//";
            this.delimiterTextBox.TextChanged += new System.EventHandler(this.delimiterTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Delimiter:";
            // 
            // fieldsListBox
            // 
            this.fieldsListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.fieldsListBox.FormattingEnabled = true;
            this.fieldsListBox.Location = new System.Drawing.Point(0, 0);
            this.fieldsListBox.Name = "fieldsListBox";
            this.fieldsListBox.Size = new System.Drawing.Size(214, 199);
            this.fieldsListBox.TabIndex = 1;
            // 
            // fieldsToolStrip
            // 
            this.fieldsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.fieldsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fieldsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.deleteToolStripButton,
            this.moveUpToolStripButton,
            this.moveDownToolStripButton});
            this.fieldsToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.fieldsToolStrip.Location = new System.Drawing.Point(220, 0);
            this.fieldsToolStrip.Name = "fieldsToolStrip";
            this.fieldsToolStrip.Size = new System.Drawing.Size(24, 94);
            this.fieldsToolStrip.TabIndex = 2;
            this.fieldsToolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.discNumberToolStripMenuItem,
            this.trackNumberToolStripMenuItem,
            this.trackNameToolStripMenuItem,
            this.toolStripSeparator2,
            this.customStringToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(22, 20);
            this.toolStripDropDownButton1.Text = "Add...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // discNumberToolStripMenuItem
            // 
            this.discNumberToolStripMenuItem.Name = "discNumberToolStripMenuItem";
            this.discNumberToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.discNumberToolStripMenuItem.Text = "Disc Number";
            this.discNumberToolStripMenuItem.Click += new System.EventHandler(this.discNumberToolStripMenuItem_Click);
            // 
            // trackNumberToolStripMenuItem
            // 
            this.trackNumberToolStripMenuItem.Name = "trackNumberToolStripMenuItem";
            this.trackNumberToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.trackNumberToolStripMenuItem.Text = "Track Number";
            this.trackNumberToolStripMenuItem.Click += new System.EventHandler(this.trackNumberToolStripMenuItem_Click);
            // 
            // trackNameToolStripMenuItem
            // 
            this.trackNameToolStripMenuItem.Name = "trackNameToolStripMenuItem";
            this.trackNameToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.trackNameToolStripMenuItem.Text = "Track Name";
            this.trackNameToolStripMenuItem.Click += new System.EventHandler(this.trackNameToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // customStringToolStripMenuItem
            // 
            this.customStringToolStripMenuItem.Name = "customStringToolStripMenuItem";
            this.customStringToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.customStringToolStripMenuItem.Text = "Custom String...";
            this.customStringToolStripMenuItem.Click += new System.EventHandler(this.customStringToolStripMenuItem_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(22, 20);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // moveUpToolStripButton
            // 
            this.moveUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("moveUpToolStripButton.Image")));
            this.moveUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpToolStripButton.Name = "moveUpToolStripButton";
            this.moveUpToolStripButton.Size = new System.Drawing.Size(22, 20);
            this.moveUpToolStripButton.Text = "Move Up";
            this.moveUpToolStripButton.Click += new System.EventHandler(this.moveUpToolStripButton_Click);
            // 
            // moveDownToolStripButton
            // 
            this.moveDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("moveDownToolStripButton.Image")));
            this.moveDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownToolStripButton.Name = "moveDownToolStripButton";
            this.moveDownToolStripButton.Size = new System.Drawing.Size(22, 20);
            this.moveDownToolStripButton.Text = "Move Down";
            this.moveDownToolStripButton.Click += new System.EventHandler(this.moveDownToolStripButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(9);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 348);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fieldsListBox);
            this.panel1.Controls.Add(this.fieldsToolStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 199);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mp3tagFormatStringLinkLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.delimiterTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(12, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 49);
            this.panel2.TabIndex = 1;
            // 
            // mp3tagFormatStringLinkLabel
            // 
            this.mp3tagFormatStringLinkLabel.AutoSize = true;
            this.mp3tagFormatStringLinkLabel.Location = new System.Drawing.Point(3, 30);
            this.mp3tagFormatStringLinkLabel.Name = "mp3tagFormatStringLinkLabel";
            this.mp3tagFormatStringLinkLabel.Size = new System.Drawing.Size(138, 13);
            this.mp3tagFormatStringLinkLabel.TabIndex = 4;
            this.mp3tagFormatStringLinkLabel.TabStop = true;
            this.mp3tagFormatStringLinkLabel.Text = "Show Mp3tag Format String";
            this.mp3tagFormatStringLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mp3tagFormatStringLinkLabel_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.presetsToolStrip);
            this.panel3.Controls.Add(this.presetComboBox);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 29);
            this.panel3.TabIndex = 2;
            // 
            // presetsToolStrip
            // 
            this.presetsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.presetsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.presetsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPresetToolStripButton,
            this.removePresetToolStripButton});
            this.presetsToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.presetsToolStrip.Location = new System.Drawing.Point(197, 3);
            this.presetsToolStrip.Name = "presetsToolStrip";
            this.presetsToolStrip.Size = new System.Drawing.Size(80, 25);
            this.presetsToolStrip.TabIndex = 3;
            this.presetsToolStrip.Text = "toolStrip1";
            // 
            // removePresetToolStripButton
            // 
            this.removePresetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removePresetToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removePresetToolStripButton.Image")));
            this.removePresetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removePresetToolStripButton.Name = "removePresetToolStripButton";
            this.removePresetToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.removePresetToolStripButton.Text = "Remove";
            this.removePresetToolStripButton.Click += new System.EventHandler(this.removePresetToolStripButton_Click);
            // 
            // presetComboBox
            // 
            this.presetComboBox.FormattingEnabled = true;
            this.presetComboBox.Location = new System.Drawing.Point(52, 3);
            this.presetComboBox.Name = "presetComboBox";
            this.presetComboBox.Size = new System.Drawing.Size(142, 21);
            this.presetComboBox.TabIndex = 0;
            this.presetComboBox.SelectedIndexChanged += new System.EventHandler(this.presetComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Preset:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.exportButton);
            this.panel4.Controls.Add(this.cancelButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(12, 307);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 29);
            this.panel4.TabIndex = 3;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(87, 3);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "&Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(168, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // exportSaveFileDialog
            // 
            this.exportSaveFileDialog.DefaultExt = "txt";
            this.exportSaveFileDialog.Filter = "UTF-8 Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.exportSaveFileDialog.Title = "Export Album Data";
            // 
            // addPresetToolStripButton
            // 
            this.addPresetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addPresetToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addPresetToolStripButton.Image")));
            this.addPresetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addPresetToolStripButton.Name = "addPresetToolStripButton";
            this.addPresetToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addPresetToolStripButton.Text = "Add...";
            this.addPresetToolStripButton.Click += new System.EventHandler(this.addPresetToolStripButton_Click);
            // 
            // ExportForm
            // 
            this.AcceptButton = this.exportButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(270, 348);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Export";
            this.fieldsToolStrip.ResumeLayout(false);
            this.fieldsToolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.presetsToolStrip.ResumeLayout(false);
            this.presetsToolStrip.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox delimiterTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox fieldsListBox;
        private System.Windows.Forms.ToolStrip fieldsToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem discNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem customStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton moveUpToolStripButton;
        private System.Windows.Forms.ToolStripButton moveDownToolStripButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox presetComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SaveFileDialog exportSaveFileDialog;
        private System.Windows.Forms.LinkLabel mp3tagFormatStringLinkLabel;
        private System.Windows.Forms.ToolStrip presetsToolStrip;
        private System.Windows.Forms.ToolStripButton removePresetToolStripButton;
        private System.Windows.Forms.ToolStripButton addPresetToolStripButton;
    }
}