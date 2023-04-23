namespace Pedikir_manikir
{
    partial class Pocetna_stranica
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
            this.sifarniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klijentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uslugaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposleniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervacijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sifarniciToolStripMenuItem,
            this.zaposleniToolStripMenuItem,
            this.rezervacijaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sifarniciToolStripMenuItem
            // 
            this.sifarniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klijentToolStripMenuItem,
            this.plataToolStripMenuItem,
            this.uslugaToolStripMenuItem});
            this.sifarniciToolStripMenuItem.Name = "sifarniciToolStripMenuItem";
            this.sifarniciToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.sifarniciToolStripMenuItem.Text = "Sifarnici";
            // 
            // klijentToolStripMenuItem
            // 
            this.klijentToolStripMenuItem.Name = "klijentToolStripMenuItem";
            this.klijentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.klijentToolStripMenuItem.Text = "Klijent";
            this.klijentToolStripMenuItem.Click += new System.EventHandler(this.klijentToolStripMenuItem_Click);
            // 
            // plataToolStripMenuItem
            // 
            this.plataToolStripMenuItem.Name = "plataToolStripMenuItem";
            this.plataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.plataToolStripMenuItem.Text = "Plata";
            this.plataToolStripMenuItem.Click += new System.EventHandler(this.plataToolStripMenuItem_Click);
            // 
            // uslugaToolStripMenuItem
            // 
            this.uslugaToolStripMenuItem.Name = "uslugaToolStripMenuItem";
            this.uslugaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uslugaToolStripMenuItem.Text = "Usluga";
            this.uslugaToolStripMenuItem.Click += new System.EventHandler(this.uslugaToolStripMenuItem_Click);
            // 
            // zaposleniToolStripMenuItem
            // 
            this.zaposleniToolStripMenuItem.Name = "zaposleniToolStripMenuItem";
            this.zaposleniToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.zaposleniToolStripMenuItem.Text = "Zaposleni";
            // 
            // rezervacijaToolStripMenuItem
            // 
            this.rezervacijaToolStripMenuItem.Name = "rezervacijaToolStripMenuItem";
            this.rezervacijaToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.rezervacijaToolStripMenuItem.Text = "Rezervacija";
            // 
            // Pocetna_stranica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Pocetna_stranica";
            this.Text = "Pocetna_stranica";
            this.Load += new System.EventHandler(this.Pocetna_stranica_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sifarniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klijentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uslugaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposleniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervacijaToolStripMenuItem;
    }
}