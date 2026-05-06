namespace RodjendanProjekat.Forms
{
    partial class RezervacijeForm
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
            this.dgvRezervacije = new System.Windows.Forms.DataGridView();
            this.lblDatum = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.lblVremeOd = new System.Windows.Forms.Label();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            this.lblVremeDo = new System.Windows.Forms.Label();
            this.lblBrojDece = new System.Windows.Forms.Label();
            this.numBrojDece = new System.Windows.Forms.NumericUpDown();
            this.lblIznos = new System.Windows.Forms.Label();
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbKlijent = new System.Windows.Forms.ComboBox();
            this.lblKlijent = new System.Windows.Forms.Label();
            this.lblSlavljenik = new System.Windows.Forms.Label();
            this.cmbSlavljenik = new System.Windows.Forms.ComboBox();
            this.cmbSala = new System.Windows.Forms.ComboBox();
            this.lblSala = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBrojDece)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRezervacije
            // 
            this.dgvRezervacije.AllowUserToAddRows = false;
            this.dgvRezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervacije.Location = new System.Drawing.Point(20, 20);
            this.dgvRezervacije.MultiSelect = false;
            this.dgvRezervacije.Name = "dgvRezervacije";
            this.dgvRezervacije.ReadOnly = true;
            this.dgvRezervacije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervacije.Size = new System.Drawing.Size(1040, 250);
            this.dgvRezervacije.TabIndex = 0;
            this.dgvRezervacije.SelectionChanged += new System.EventHandler(this.dgvRezervacije_SelectionChanged);
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(20, 290);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(41, 13);
            this.lblDatum.TabIndex = 1;
            this.lblDatum.Text = "Datum:";
            this.lblDatum.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtpDatum
            // 
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatum.Location = new System.Drawing.Point(140, 287);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpDatum.TabIndex = 2;
            // 
            // lblVremeOd
            // 
            this.lblVremeOd.AutoSize = true;
            this.lblVremeOd.Location = new System.Drawing.Point(20, 320);
            this.lblVremeOd.Name = "lblVremeOd";
            this.lblVremeOd.Size = new System.Drawing.Size(55, 13);
            this.lblVremeOd.TabIndex = 3;
            this.lblVremeOd.Text = "Vreme od:";
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpVremeOd.Location = new System.Drawing.Point(140, 317);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.ShowUpDown = true;
            this.dtpVremeOd.Size = new System.Drawing.Size(200, 20);
            this.dtpVremeOd.TabIndex = 4;
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpVremeDo.Location = new System.Drawing.Point(140, 347);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.ShowUpDown = true;
            this.dtpVremeDo.Size = new System.Drawing.Size(200, 20);
            this.dtpVremeDo.TabIndex = 5;
            // 
            // lblVremeDo
            // 
            this.lblVremeDo.AutoSize = true;
            this.lblVremeDo.Location = new System.Drawing.Point(20, 350);
            this.lblVremeDo.Name = "lblVremeDo";
            this.lblVremeDo.Size = new System.Drawing.Size(55, 13);
            this.lblVremeDo.TabIndex = 6;
            this.lblVremeDo.Text = "Vreme do:";
            // 
            // lblBrojDece
            // 
            this.lblBrojDece.AutoSize = true;
            this.lblBrojDece.Location = new System.Drawing.Point(20, 380);
            this.lblBrojDece.Name = "lblBrojDece";
            this.lblBrojDece.Size = new System.Drawing.Size(55, 13);
            this.lblBrojDece.TabIndex = 7;
            this.lblBrojDece.Text = "Broj dece:";
            // 
            // numBrojDece
            // 
            this.numBrojDece.Location = new System.Drawing.Point(140, 377);
            this.numBrojDece.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numBrojDece.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numBrojDece.Name = "numBrojDece";
            this.numBrojDece.Size = new System.Drawing.Size(200, 20);
            this.numBrojDece.TabIndex = 8;
            this.numBrojDece.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblIznos
            // 
            this.lblIznos.AutoSize = true;
            this.lblIznos.Location = new System.Drawing.Point(20, 410);
            this.lblIznos.Name = "lblIznos";
            this.lblIznos.Size = new System.Drawing.Size(75, 13);
            this.lblIznos.TabIndex = 9;
            this.lblIznos.Text = "Ukupan iznos:";
            // 
            // txtIznos
            // 
            this.txtIznos.Location = new System.Drawing.Point(140, 407);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(200, 20);
            this.txtIznos.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(380, 290);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Rezervisano",
            "Plaćeno",
            "Otkazano",
            "Završeno"});
            this.cmbStatus.Location = new System.Drawing.Point(510, 287);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 21);
            this.cmbStatus.TabIndex = 12;
            // 
            // cmbKlijent
            // 
            this.cmbKlijent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKlijent.FormattingEnabled = true;
            this.cmbKlijent.Location = new System.Drawing.Point(510, 317);
            this.cmbKlijent.Name = "cmbKlijent";
            this.cmbKlijent.Size = new System.Drawing.Size(250, 21);
            this.cmbKlijent.TabIndex = 13;
            this.cmbKlijent.SelectedIndexChanged += new System.EventHandler(this.cmbKlijent_SelectedIndexChanged);
            // 
            // lblKlijent
            // 
            this.lblKlijent.AutoSize = true;
            this.lblKlijent.Location = new System.Drawing.Point(380, 320);
            this.lblKlijent.Name = "lblKlijent";
            this.lblKlijent.Size = new System.Drawing.Size(38, 13);
            this.lblKlijent.TabIndex = 14;
            this.lblKlijent.Text = "Klijent:";
            // 
            // lblSlavljenik
            // 
            this.lblSlavljenik.AutoSize = true;
            this.lblSlavljenik.Location = new System.Drawing.Point(380, 350);
            this.lblSlavljenik.Name = "lblSlavljenik";
            this.lblSlavljenik.Size = new System.Drawing.Size(55, 13);
            this.lblSlavljenik.TabIndex = 15;
            this.lblSlavljenik.Text = "Slavljenik:";
            // 
            // cmbSlavljenik
            // 
            this.cmbSlavljenik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSlavljenik.FormattingEnabled = true;
            this.cmbSlavljenik.Location = new System.Drawing.Point(510, 347);
            this.cmbSlavljenik.Name = "cmbSlavljenik";
            this.cmbSlavljenik.Size = new System.Drawing.Size(250, 21);
            this.cmbSlavljenik.TabIndex = 16;
            // 
            // cmbSala
            // 
            this.cmbSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSala.FormattingEnabled = true;
            this.cmbSala.Location = new System.Drawing.Point(510, 377);
            this.cmbSala.Name = "cmbSala";
            this.cmbSala.Size = new System.Drawing.Size(250, 21);
            this.cmbSala.TabIndex = 17;
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Location = new System.Drawing.Point(380, 380);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(31, 13);
            this.lblSala.TabIndex = 18;
            this.lblSala.Text = "Sala:";
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.LightGreen;
            this.btnDodaj.Location = new System.Drawing.Point(820, 285);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(240, 35);
            this.btnDodaj.TabIndex = 19;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.BackColor = System.Drawing.Color.LightYellow;
            this.btnIzmeni.Location = new System.Drawing.Point(820, 325);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(240, 35);
            this.btnIzmeni.TabIndex = 20;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.LightCoral;
            this.btnObrisi.Location = new System.Drawing.Point(820, 365);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(240, 35);
            this.btnObrisi.TabIndex = 21;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // RezervacijeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.cmbSala);
            this.Controls.Add(this.cmbSlavljenik);
            this.Controls.Add(this.lblSlavljenik);
            this.Controls.Add(this.lblKlijent);
            this.Controls.Add(this.cmbKlijent);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtIznos);
            this.Controls.Add(this.lblIznos);
            this.Controls.Add(this.numBrojDece);
            this.Controls.Add(this.lblBrojDece);
            this.Controls.Add(this.lblVremeDo);
            this.Controls.Add(this.dtpVremeDo);
            this.Controls.Add(this.dtpVremeOd);
            this.Controls.Add(this.lblVremeOd);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.dgvRezervacije);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RezervacijeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezervacije";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBrojDece)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRezervacije;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label lblVremeOd;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
        private System.Windows.Forms.Label lblVremeDo;
        private System.Windows.Forms.Label lblBrojDece;
        private System.Windows.Forms.NumericUpDown numBrojDece;
        private System.Windows.Forms.Label lblIznos;
        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbKlijent;
        private System.Windows.Forms.Label lblKlijent;
        private System.Windows.Forms.Label lblSlavljenik;
        private System.Windows.Forms.ComboBox cmbSlavljenik;
        private System.Windows.Forms.ComboBox cmbSala;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
    }
}