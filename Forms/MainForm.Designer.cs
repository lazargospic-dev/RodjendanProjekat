namespace RodjendanProjekat.Forms
{
    partial class MainForm
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
            this.lblNaslov = new System.Windows.Forms.Label();
            this.btnKlijenti = new System.Windows.Forms.Button();
            this.btnSlavljenici = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnZaposleni = new System.Windows.Forms.Button();
            this.btnUsluge = new System.Windows.Forms.Button();
            this.btnRezervacije = new System.Windows.Forms.Button();
            this.btnUplate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaslov.Location = new System.Drawing.Point(60, 20);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(248, 25);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "Organizovanje Rođendana";
            // 
            // btnKlijenti
            // 
            this.btnKlijenti.Location = new System.Drawing.Point(60, 80);
            this.btnKlijenti.Name = "btnKlijenti";
            this.btnKlijenti.Size = new System.Drawing.Size(280, 40);
            this.btnKlijenti.TabIndex = 1;
            this.btnKlijenti.Text = "Klijenti";
            this.btnKlijenti.UseVisualStyleBackColor = true;
            this.btnKlijenti.Click += new System.EventHandler(this.btnKlijenti_Click);
            // 
            // btnSlavljenici
            // 
            this.btnSlavljenici.Location = new System.Drawing.Point(60, 130);
            this.btnSlavljenici.Name = "btnSlavljenici";
            this.btnSlavljenici.Size = new System.Drawing.Size(280, 40);
            this.btnSlavljenici.TabIndex = 2;
            this.btnSlavljenici.Text = "Slavljenici";
            this.btnSlavljenici.UseVisualStyleBackColor = true;
            this.btnSlavljenici.Click += new System.EventHandler(this.btnSlavljenici_Click);
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(60, 180);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(280, 40);
            this.btnSale.TabIndex = 3;
            this.btnSale.Text = "Sale";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnZaposleni
            // 
            this.btnZaposleni.Location = new System.Drawing.Point(60, 230);
            this.btnZaposleni.Name = "btnZaposleni";
            this.btnZaposleni.Size = new System.Drawing.Size(280, 40);
            this.btnZaposleni.TabIndex = 4;
            this.btnZaposleni.Text = "Zaposleni";
            this.btnZaposleni.UseVisualStyleBackColor = true;
            this.btnZaposleni.Click += new System.EventHandler(this.btnZaposleni_Click);
            // 
            // btnUsluge
            // 
            this.btnUsluge.Location = new System.Drawing.Point(60, 280);
            this.btnUsluge.Name = "btnUsluge";
            this.btnUsluge.Size = new System.Drawing.Size(280, 40);
            this.btnUsluge.TabIndex = 5;
            this.btnUsluge.Text = "Dodatne Usluge";
            this.btnUsluge.UseVisualStyleBackColor = true;
            this.btnUsluge.Click += new System.EventHandler(this.btnUsluge_Click);
            // 
            // btnRezervacije
            // 
            this.btnRezervacije.Location = new System.Drawing.Point(60, 330);
            this.btnRezervacije.Name = "btnRezervacije";
            this.btnRezervacije.Size = new System.Drawing.Size(280, 40);
            this.btnRezervacije.TabIndex = 6;
            this.btnRezervacije.Text = "Rezervacije";
            this.btnRezervacije.UseVisualStyleBackColor = true;
            this.btnRezervacije.Click += new System.EventHandler(this.btnRezervacije_Click);
            // 
            // btnUplate
            // 
            this.btnUplate.Location = new System.Drawing.Point(60, 380);
            this.btnUplate.Name = "btnUplate";
            this.btnUplate.Size = new System.Drawing.Size(280, 40);
            this.btnUplate.TabIndex = 7;
            this.btnUplate.Text = "Uplate";
            this.btnUplate.UseVisualStyleBackColor = true;
            this.btnUplate.Click += new System.EventHandler(this.btnUplate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 511);
            this.Controls.Add(this.btnUplate);
            this.Controls.Add(this.btnRezervacije);
            this.Controls.Add(this.btnUsluge);
            this.Controls.Add(this.btnZaposleni);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnSlavljenici);
            this.Controls.Add(this.btnKlijenti);
            this.Controls.Add(this.lblNaslov);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rođendani - Glavni Meni";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Button btnKlijenti;
        private System.Windows.Forms.Button btnSlavljenici;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnZaposleni;
        private System.Windows.Forms.Button btnUsluge;
        private System.Windows.Forms.Button btnRezervacije;
        private System.Windows.Forms.Button btnUplate;
    }
}