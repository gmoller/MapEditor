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
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.palletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSelectedImage = new System.Windows.Forms.Panel();
            this.lblSelectedImage = new System.Windows.Forms.Label();
            this.picSelectedImage = new System.Windows.Forms.PictureBox();
            this.pnlPalette = new System.Windows.Forms.Panel();
            this.picPalette = new System.Windows.Forms.PictureBox();
            this.pnlSelectedPalette = new System.Windows.Forms.Panel();
            this.lblSelectedPalette = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSelectedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedImage)).BeginInit();
            this.pnlPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPalette)).BeginInit();
            this.pnlSelectedPalette.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.palletteToolStripMenuItem,
            this.layerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1377, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // palletteToolStripMenuItem
            // 
            this.palletteToolStripMenuItem.Name = "palletteToolStripMenuItem";
            this.palletteToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.palletteToolStripMenuItem.Text = "&Palette";
            // 
            // layerToolStripMenuItem
            // 
            this.layerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.layerToolStripMenuItem.Name = "layerToolStripMenuItem";
            this.layerToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.layerToolStripMenuItem.Text = "&Layer";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "0";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "1";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
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
            this.pnlLeft.Size = new System.Drawing.Size(256, 696);
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
            this.pnlSelectedImage.Size = new System.Drawing.Size(254, 57);
            this.pnlSelectedImage.TabIndex = 2;
            // 
            // lblSelectedImage
            // 
            this.lblSelectedImage.Location = new System.Drawing.Point(47, 12);
            this.lblSelectedImage.Name = "lblSelectedImage";
            this.lblSelectedImage.Size = new System.Drawing.Size(195, 32);
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
            this.pnlPalette.Size = new System.Drawing.Size(254, 665);
            this.pnlPalette.TabIndex = 1;
            // 
            // picPalette
            // 
            this.picPalette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPalette.Location = new System.Drawing.Point(0, 0);
            this.picPalette.Name = "picPalette";
            this.picPalette.Size = new System.Drawing.Size(252, 663);
            this.picPalette.TabIndex = 0;
            this.picPalette.TabStop = false;
            this.picPalette.Click += new System.EventHandler(this.picPalette_Click);
            this.picPalette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPalette_MouseDown);
            // 
            // pnlSelectedPalette
            // 
            this.pnlSelectedPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectedPalette.Controls.Add(this.lblSelectedPalette);
            this.pnlSelectedPalette.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectedPalette.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectedPalette.Name = "pnlSelectedPalette";
            this.pnlSelectedPalette.Size = new System.Drawing.Size(254, 29);
            this.pnlSelectedPalette.TabIndex = 0;
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
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.picMap);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(256, 24);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(1121, 696);
            this.pnlRight.TabIndex = 3;
            // 
            // picMap
            // 
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMap.Location = new System.Drawing.Point(0, 0);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(1119, 694);
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            this.picMap.Click += new System.EventHandler(this.picMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 720);
            this.Controls.Add(this.pnlRight);
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
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
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
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ToolStripMenuItem palletteToolStripMenuItem;
        private System.Windows.Forms.Panel pnlSelectedImage;
        private System.Windows.Forms.Panel pnlPalette;
        private System.Windows.Forms.Panel pnlSelectedPalette;
        private System.Windows.Forms.PictureBox picPalette;
        private System.Windows.Forms.Label lblSelectedPalette;
        private System.Windows.Forms.PictureBox picSelectedImage;
        private System.Windows.Forms.Label lblSelectedImage;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.ToolStripMenuItem layerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}

