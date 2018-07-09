namespace WinFormsGui
{
    partial class SettlementForm
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
            this.lblRace = new System.Windows.Forms.Label();
            this.lblPopulation = new System.Windows.Forms.Label();
            this.lblResidents = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblResources = new System.Windows.Forms.Label();
            this.lblEnchantments = new System.Windows.Forms.Label();
            this.lstResources = new System.Windows.Forms.ListBox();
            this.lstEnchantments = new System.Windows.Forms.ListBox();
            this.lblBuildings = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.lblProducing = new System.Windows.Forms.Label();
            this.lstProducing = new System.Windows.Forms.ListBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Location = new System.Drawing.Point(12, 9);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(36, 13);
            this.lblRace.TabIndex = 0;
            this.lblRace.Text = "Race:";
            // 
            // lblPopulation
            // 
            this.lblPopulation.AutoSize = true;
            this.lblPopulation.Location = new System.Drawing.Point(265, 9);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(60, 13);
            this.lblPopulation.TabIndex = 1;
            this.lblPopulation.Text = "Population:";
            // 
            // lblResidents
            // 
            this.lblResidents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResidents.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResidents.Location = new System.Drawing.Point(12, 22);
            this.lblResidents.Name = "lblResidents";
            this.lblResidents.Size = new System.Drawing.Size(370, 23);
            this.lblResidents.TabIndex = 2;
            this.lblResidents.Text = "FFFF";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(388, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 171);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblResources
            // 
            this.lblResources.AutoSize = true;
            this.lblResources.Location = new System.Drawing.Point(12, 56);
            this.lblResources.Name = "lblResources";
            this.lblResources.Size = new System.Drawing.Size(61, 13);
            this.lblResources.TabIndex = 3;
            this.lblResources.Text = "Resources:";
            // 
            // lblEnchantments
            // 
            this.lblEnchantments.AutoSize = true;
            this.lblEnchantments.Location = new System.Drawing.Point(265, 56);
            this.lblEnchantments.Name = "lblEnchantments";
            this.lblEnchantments.Size = new System.Drawing.Size(78, 13);
            this.lblEnchantments.TabIndex = 5;
            this.lblEnchantments.Text = "Enchantments:";
            // 
            // lstResources
            // 
            this.lstResources.FormattingEnabled = true;
            this.lstResources.Location = new System.Drawing.Point(12, 72);
            this.lstResources.Name = "lstResources";
            this.lstResources.Size = new System.Drawing.Size(245, 108);
            this.lstResources.TabIndex = 4;
            // 
            // lstEnchantments
            // 
            this.lstEnchantments.FormattingEnabled = true;
            this.lstEnchantments.Location = new System.Drawing.Point(263, 72);
            this.lstEnchantments.Name = "lstEnchantments";
            this.lstEnchantments.Size = new System.Drawing.Size(119, 108);
            this.lstEnchantments.TabIndex = 6;
            // 
            // lblBuildings
            // 
            this.lblBuildings.AutoSize = true;
            this.lblBuildings.Location = new System.Drawing.Point(12, 192);
            this.lblBuildings.Name = "lblBuildings";
            this.lblBuildings.Size = new System.Drawing.Size(52, 13);
            this.lblBuildings.TabIndex = 7;
            this.lblBuildings.Text = "Buildings:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 208);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(370, 147);
            this.listBox1.TabIndex = 8;
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(385, 192);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(34, 13);
            this.lblUnits.TabIndex = 9;
            this.lblUnits.Text = "Units:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(388, 208);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(187, 43);
            this.listBox2.TabIndex = 10;
            // 
            // lblProducing
            // 
            this.lblProducing.AutoSize = true;
            this.lblProducing.Location = new System.Drawing.Point(391, 263);
            this.lblProducing.Name = "lblProducing";
            this.lblProducing.Size = new System.Drawing.Size(58, 13);
            this.lblProducing.TabIndex = 11;
            this.lblProducing.Text = "Producing:";
            // 
            // lstProducing
            // 
            this.lstProducing.FormattingEnabled = true;
            this.lstProducing.Location = new System.Drawing.Point(388, 279);
            this.lstProducing.Name = "lstProducing";
            this.lstProducing.Size = new System.Drawing.Size(187, 43);
            this.lstProducing.TabIndex = 12;
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(388, 332);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(58, 23);
            this.btnBuy.TabIndex = 13;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(452, 332);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(58, 23);
            this.btnChange.TabIndex = 14;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(517, 332);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(58, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // SettlementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 362);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.lstProducing);
            this.Controls.Add(this.lblProducing);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.lblUnits);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblBuildings);
            this.Controls.Add(this.lstEnchantments);
            this.Controls.Add(this.lstResources);
            this.Controls.Add(this.lblEnchantments);
            this.Controls.Add(this.lblResources);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblResidents);
            this.Controls.Add(this.lblPopulation);
            this.Controls.Add(this.lblRace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettlementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettlementForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.Label lblPopulation;
        private System.Windows.Forms.Label lblResidents;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblResources;
        private System.Windows.Forms.Label lblEnchantments;
        private System.Windows.Forms.ListBox lstResources;
        private System.Windows.Forms.ListBox lstEnchantments;
        private System.Windows.Forms.Label lblBuildings;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label lblProducing;
        private System.Windows.Forms.ListBox lstProducing;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnOk;
    }
}