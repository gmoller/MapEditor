namespace MapEditor
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseGridSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseGridSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSelectedImage = new System.Windows.Forms.Panel();
            this.lblSelectedImage = new System.Windows.Forms.Label();
            this.picSelectedImage = new System.Windows.Forms.PictureBox();
            this.pnlPalette = new System.Windows.Forms.Panel();
            this.picPalette = new System.Windows.Forms.PictureBox();
            this.pnlSelectedPalette = new System.Windows.Forms.Panel();
            this.cboPalette = new System.Windows.Forms.ComboBox();
            this.lblSelectedPalette = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblShowLayer = new System.Windows.Forms.Label();
            this.chkLayer1 = new System.Windows.Forms.CheckBox();
            this.chkLayer0 = new System.Windows.Forms.CheckBox();
            this.radLayer1 = new System.Windows.Forms.RadioButton();
            this.radLayer0 = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSelectedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedImage)).BeginInit();
            this.pnlPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPalette)).BeginInit();
            this.pnlSelectedPalette.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1377, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseGridSizeToolStripMenuItem,
            this.decreaseGridSizeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // increaseGridSizeToolStripMenuItem
            // 
            this.increaseGridSizeToolStripMenuItem.Name = "increaseGridSizeToolStripMenuItem";
            this.increaseGridSizeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.increaseGridSizeToolStripMenuItem.Text = "Increase Grid Size";
            this.increaseGridSizeToolStripMenuItem.Click += new System.EventHandler(this.increaseGridSizeToolStripMenuItem_Click);
            // 
            // decreaseGridSizeToolStripMenuItem
            // 
            this.decreaseGridSizeToolStripMenuItem.Name = "decreaseGridSizeToolStripMenuItem";
            this.decreaseGridSizeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.decreaseGridSizeToolStripMenuItem.Text = "Decrease Grid Size";
            this.decreaseGridSizeToolStripMenuItem.Click += new System.EventHandler(this.decreaseGridSizeToolStripMenuItem_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.pnlSelectedImage);
            this.pnlLeft.Controls.Add(this.pnlPalette);
            this.pnlLeft.Controls.Add(this.pnlSelectedPalette);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 24);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(201, 696);
            this.pnlLeft.TabIndex = 2;
            // 
            // pnlSelectedImage
            // 
            this.pnlSelectedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectedImage.Controls.Add(this.lblSelectedImage);
            this.pnlSelectedImage.Controls.Add(this.picSelectedImage);
            this.pnlSelectedImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSelectedImage.Location = new System.Drawing.Point(0, 637);
            this.pnlSelectedImage.Name = "pnlSelectedImage";
            this.pnlSelectedImage.Size = new System.Drawing.Size(199, 57);
            this.pnlSelectedImage.TabIndex = 2;
            // 
            // lblSelectedImage
            // 
            this.lblSelectedImage.Location = new System.Drawing.Point(47, 12);
            this.lblSelectedImage.Name = "lblSelectedImage";
            this.lblSelectedImage.Size = new System.Drawing.Size(153, 32);
            this.lblSelectedImage.TabIndex = 1;
            // 
            // picSelectedImage
            // 
            this.picSelectedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSelectedImage.Location = new System.Drawing.Point(9, 12);
            this.picSelectedImage.Name = "picSelectedImage";
            this.picSelectedImage.Size = new System.Drawing.Size(32, 32);
            this.picSelectedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectedImage.TabIndex = 0;
            this.picSelectedImage.TabStop = false;
            // 
            // pnlPalette
            // 
            this.pnlPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPalette.Controls.Add(this.picPalette);
            this.pnlPalette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPalette.Location = new System.Drawing.Point(0, 29);
            this.pnlPalette.Name = "pnlPalette";
            this.pnlPalette.Size = new System.Drawing.Size(199, 665);
            this.pnlPalette.TabIndex = 1;
            // 
            // picPalette
            // 
            this.picPalette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPalette.Location = new System.Drawing.Point(0, 0);
            this.picPalette.Name = "picPalette";
            this.picPalette.Size = new System.Drawing.Size(197, 663);
            this.picPalette.TabIndex = 0;
            this.picPalette.TabStop = false;
            this.picPalette.Click += new System.EventHandler(this.picPalette_Click);
            // 
            // pnlSelectedPalette
            // 
            this.pnlSelectedPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectedPalette.Controls.Add(this.cboPalette);
            this.pnlSelectedPalette.Controls.Add(this.lblSelectedPalette);
            this.pnlSelectedPalette.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectedPalette.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectedPalette.Name = "pnlSelectedPalette";
            this.pnlSelectedPalette.Size = new System.Drawing.Size(199, 29);
            this.pnlSelectedPalette.TabIndex = 0;
            // 
            // cboPalette
            // 
            this.cboPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPalette.FormattingEnabled = true;
            this.cboPalette.Location = new System.Drawing.Point(49, 2);
            this.cboPalette.Name = "cboPalette";
            this.cboPalette.Size = new System.Drawing.Size(144, 21);
            this.cboPalette.TabIndex = 1;
            this.cboPalette.SelectedIndexChanged += new System.EventHandler(this.cboPalette_SelectedIndexChanged);
            // 
            // lblSelectedPalette
            // 
            this.lblSelectedPalette.AutoSize = true;
            this.lblSelectedPalette.Location = new System.Drawing.Point(0, 5);
            this.lblSelectedPalette.Name = "lblSelectedPalette";
            this.lblSelectedPalette.Size = new System.Drawing.Size(43, 13);
            this.lblSelectedPalette.TabIndex = 0;
            this.lblSelectedPalette.Text = "Palette:";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.AutoScroll = true;
            this.pnlMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMiddle.Controls.Add(this.picMap);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMiddle.Location = new System.Drawing.Point(201, 24);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1047, 696);
            this.pnlMiddle.TabIndex = 3;
            // 
            // picMap
            // 
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMap.Location = new System.Drawing.Point(0, 0);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(1000, 694);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            this.picMap.Click += new System.EventHandler(this.picMap_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.lblShowLayer);
            this.pnlRight.Controls.Add(this.chkLayer1);
            this.pnlRight.Controls.Add(this.chkLayer0);
            this.pnlRight.Controls.Add(this.radLayer1);
            this.pnlRight.Controls.Add(this.radLayer0);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1254, 24);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(123, 696);
            this.pnlRight.TabIndex = 4;
            // 
            // lblShowLayer
            // 
            this.lblShowLayer.AutoSize = true;
            this.lblShowLayer.Location = new System.Drawing.Point(78, 6);
            this.lblShowLayer.Name = "lblShowLayer";
            this.lblShowLayer.Size = new System.Drawing.Size(40, 13);
            this.lblShowLayer.TabIndex = 4;
            this.lblShowLayer.Text = "Show?";
            // 
            // chkLayer1
            // 
            this.chkLayer1.AutoSize = true;
            this.chkLayer1.Checked = true;
            this.chkLayer1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLayer1.Location = new System.Drawing.Point(86, 46);
            this.chkLayer1.Name = "chkLayer1";
            this.chkLayer1.Size = new System.Drawing.Size(15, 14);
            this.chkLayer1.TabIndex = 3;
            this.chkLayer1.UseVisualStyleBackColor = true;
            this.chkLayer1.CheckedChanged += new System.EventHandler(this.chkLayer1_CheckedChanged);
            // 
            // chkLayer0
            // 
            this.chkLayer0.AutoSize = true;
            this.chkLayer0.Checked = true;
            this.chkLayer0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLayer0.Location = new System.Drawing.Point(86, 23);
            this.chkLayer0.Name = "chkLayer0";
            this.chkLayer0.Size = new System.Drawing.Size(15, 14);
            this.chkLayer0.TabIndex = 2;
            this.chkLayer0.UseVisualStyleBackColor = true;
            this.chkLayer0.CheckedChanged += new System.EventHandler(this.chkLayer0_CheckedChanged);
            // 
            // radLayer1
            // 
            this.radLayer1.AutoSize = true;
            this.radLayer1.Location = new System.Drawing.Point(11, 44);
            this.radLayer1.Name = "radLayer1";
            this.radLayer1.Size = new System.Drawing.Size(60, 17);
            this.radLayer1.TabIndex = 1;
            this.radLayer1.Text = "Layer 1";
            this.radLayer1.UseVisualStyleBackColor = true;
            this.radLayer1.CheckedChanged += new System.EventHandler(this.radLayer1_CheckedChanged);
            // 
            // radLayer0
            // 
            this.radLayer0.AutoSize = true;
            this.radLayer0.Checked = true;
            this.radLayer0.Location = new System.Drawing.Point(11, 21);
            this.radLayer0.Name = "radLayer0";
            this.radLayer0.Size = new System.Drawing.Size(60, 17);
            this.radLayer0.TabIndex = 0;
            this.radLayer0.TabStop = true;
            this.radLayer0.Text = "Layer 0";
            this.radLayer0.UseVisualStyleBackColor = true;
            this.radLayer0.CheckedChanged += new System.EventHandler(this.radLayer0_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 720);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlSelectedImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedImage)).EndInit();
            this.pnlPalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPalette)).EndInit();
            this.pnlSelectedPalette.ResumeLayout(false);
            this.pnlSelectedPalette.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlSelectedImage;
        private System.Windows.Forms.Panel pnlPalette;
        private System.Windows.Forms.Panel pnlSelectedPalette;
        private System.Windows.Forms.PictureBox picPalette;
        private System.Windows.Forms.Label lblSelectedPalette;
        private System.Windows.Forms.PictureBox picSelectedImage;
        private System.Windows.Forms.Label lblSelectedImage;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.RadioButton radLayer1;
        private System.Windows.Forms.RadioButton radLayer0;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkLayer1;
        private System.Windows.Forms.CheckBox chkLayer0;
        private System.Windows.Forms.Label lblShowLayer;
        private System.Windows.Forms.ComboBox cboPalette;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseGridSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseGridSizeToolStripMenuItem;
    }
}

