using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RodjendanProjekat.Models;
using RodjendanProjekat.Repositories;

namespace RodjendanProjekat.Forms
{
    public partial class ZaposleniForm : Form
    {
        private ZaposleniRepository repo = new ZaposleniRepository();
        private int? selectedId = null;
        public ZaposleniForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void dgvZaposleni_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            dgvZaposleni.DataSource = null;
            dgvZaposleni.DataSource = repo.GetAll();
        }

        private void dgvZaposleni_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvZaposleni.CurrentRow?.DataBoundItem is Zaposleni z)
            {
                selectedId = z.ZaposleniId;
                txtIme.Text = z.Ime;
                txtPrezime.Text = z.Prezime;
                txtTelefon.Text = z.Telefon;
                cmbPozicija.Text = z.Pozicija;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIme.Text)) { MessageBox.Show("Unesi ime!"); return; }

                repo.Insert(new Zaposleni
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Telefon = txtTelefon.Text,
                    Pozicija = cmbPozicija.Text
                });
                LoadData();
                Clear();
                MessageBox.Show("Zaposleni dodat!");
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            try
            {
                repo.Update(new Zaposleni
                {
                    ZaposleniId = selectedId.Value,
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Telefon = txtTelefon.Text,
                    Pozicija = cmbPozicija.Text
                });
                LoadData();
                Clear();
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            if (MessageBox.Show("Obrisati zaposlenog?", "Potvrda", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    repo.Delete(selectedId.Value);
                    LoadData();
                    Clear();
                }
                catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
            }
        }

        private void Clear()
        {
            selectedId = null;
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtTelefon.Text = "";
            cmbPozicija.SelectedIndex = -1;
        }
    }
}