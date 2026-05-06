namespace RodjendanProjekat.Forms
{
    partial class UplateForm
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
            this.dgvUplate = new System.Windows.Forms.DataGridView();
            this.lblRezervacija = new System.Windows.Forms.Label();
            this.cmbRezervacija = new System.Windows.Forms.ComboBox();
            this.lblDatumUplate = new System.Windows.Forms.Label();
            this.dtpDatumUplate = new System.Windows.Forms.DateTimePicker();
            this.lblIznos = new System.Windows.Forms.Label();
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.lblNacinPlacanja = new System.Windows.Forms.Label();
            this.cmbNacinPlacanja = new System.Windows.Forms.ComboBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUplate
            // 
            this.dgvUplate.AllowUserToAddRows = false;
            this.dgvUplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUplate.Location = new System.Drawing.Point(20, 20);
            this.dgvUplate.MultiSelect = false;
            this.dgvUplate.Name = "dgvUplate";
            this.dgvUplate.ReadOnly = true;
            this.dgvUplate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUplate.Size = new System.Drawing.Size(760, 250);
            this.dgvUplate.TabIndex = 0;
            this.dgvUplate.SelectionChanged += new System.EventHandler(this.dgvUplate_SelectionChanged);
            // 
            // lblRezervacija
            // 
            this.lblRezervacija.AutoSize = true;
            this.lblRezervacija.Location = new System.Drawing.Point(20, 290);
            this.lblRezervacija.Name = "lblRezervacija";
            this.lblRezervacija.Size = new System.Drawing.Size(66, 13);
            this.lblRezervacija.TabIndex = 1;
            this.lblRezervacija.Text = "Rezervacija:";
            // 
            // cmbRezervacija
            // 
            this.cmbRezervacija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRezervacija.FormattingEnabled = true;
            this.cmbRezervacija.Location = new System.Drawing.Point(140, 287);
            this.cmbRezervacija.Name = "cmbRezervacija";
            this.cmbRezervacija.Size = new System.Drawing.Size(400, 21);
            this.cmbRezervacija.TabIndex = 2;
            // 
            // lblDatumUplate
            // 
            this.lblDatumUplate.AutoSize = true;
            this.lblDatumUplate.Location = new System.Drawing.Point(20, 320);
            this.lblDatumUplate.Name = "lblDatumUplate";
            this.lblDatumUplate.Size = new System.Drawing.Size(73, 13);
            this.lblDatumUplate.TabIndex = 3;
            this.lblDatumUplate.Text = "Datum uplate:";
            // 
            // dtpDatumUplate
            // 
            this.dtpDatumUplate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumUplate.Location = new System.Drawing.Point(140, 317);
            this.dtpDatumUplate.Name = "dtpDatumUplate";
            this.dtpDatumUplate.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumUplate.TabIndex = 4;
            // 
            // lblIznos
            // 
            this.lblIznos.AutoSize = true;
            this.lblIznos.Location = new System.Drawing.Point(20, 350);
            this.lblIznos.Name = "lblIznos";
            this.lblIznos.Size = new System.Drawing.Size(67, 13);
            this.lblIznos.TabIndex = 5;
            this.lblIznos.Text = "Iznos (RSD):";
            // 
            // txtIznos
            // 
            this.txtIznos.Location = new System.Drawing.Point(140, 347);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(200, 20);
            this.txtIznos.TabIndex = 6;
            // 
            // lblNacinPlacanja
            // 
            this.lblNacinPlacanja.AutoSize = true;
            this.lblNacinPlacanja.Location = new System.Drawing.Point(20, 380);
            this.lblNacinPlacanja.Name = "lblNacinPlacanja";
            this.lblNacinPlacanja.Size = new System.Drawing.Size(81, 13);
            this.lblNacinPlacanja.TabIndex = 7;
            this.lblNacinPlacanja.Text = "Način plaćanja:";
            // 
            // cmbNacinPlacanja
            // 
            this.cmbNacinPlacanja.FormattingEnabled = true;
            this.cmbNacinPlacanja.Items.AddRange(new object[] {
            "Gotovina",
            "Kartica",
            "Uplata na račun"});
            this.cmbNacinPlacanja.Location = new System.Drawing.Point(140, 377);
            this.cmbNacinPlacanja.Name = "cmbNacinPlacanja";
            this.cmbNacinPlacanja.Size = new System.Drawing.Size(200, 21);
            this.cmbNacinPlacanja.TabIndex = 8;
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.LightGreen;
            this.btnDodaj.Location = new System.Drawing.Point(580, 287);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(200, 30);
            this.btnDodaj.TabIndex = 9;
            this.btnDodaj.Text = "Dodaj uplatu";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.LightCoral;
            this.btnObrisi.Location = new System.Drawing.Point(580, 350);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(200, 30);
            this.btnObrisi.TabIndex = 10;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // UplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.cmbNacinPlacanja);
            this.Controls.Add(this.lblNacinPlacanja);
            this.Controls.Add(this.txtIznos);
            this.Controls.Add(this.lblIznos);
            this.Controls.Add(this.dtpDatumUplate);
            this.Controls.Add(this.lblDatumUplate);
            this.Controls.Add(this.cmbRezervacija);
            this.Controls.Add(this.lblRezervacija);
            this.Controls.Add(this.dgvUplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uplate";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUplate;
        private System.Windows.Forms.Label lblRezervacija;
        private System.Windows.Forms.ComboBox cmbRezervacija;
        private System.Windows.Forms.Label lblDatumUplate;
        private System.Windows.Forms.DateTimePicker dtpDatumUplate;
        private System.Windows.Forms.Label lblIznos;
        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.Label lblNacinPlacanja;
        private System.Windows.Forms.ComboBox cmbNacinPlacanja;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnObrisi;
    }
}