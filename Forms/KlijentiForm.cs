using RodjendanProjekat.Models;
using RodjendanProjekat.Repositories;
using System;
using System.Windows.Forms;

namespace RodjendanProjekat.Forms
{
    public partial class KlijentiForm : Form
    {
        private KlijentRepository repo = new KlijentRepository();
        private int? selectedId = null;

        public KlijentiForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvKlijenti.DataSource = null;
            dgvKlijenti.DataSource = repo.GetAll();
        }

        private void dgvKlijenti_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKlijenti.CurrentRow?.DataBoundItem is Klijent k)
            {
                selectedId = k.KlijentId;
                txtIme.Text = k.Ime;
                txtPrezime.Text = k.Prezime;
                txtTelefon.Text = k.Telefon;
                txtEmail.Text = k.Email;
                txtNapomena.Text = k.Napomena;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                repo.Insert(new Klijent
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Telefon = txtTelefon.Text,
                    Email = txtEmail.Text,
                    Napomena = txtNapomena.Text
                });
                LoadData();
                Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            repo.Update(new Klijent
            {
                KlijentId = selectedId.Value,
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Telefon = txtTelefon.Text,
                Email = txtEmail.Text,
                Napomena = txtNapomena.Text
            });
            LoadData();
            Clear();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            if (MessageBox.Show("Obrisati?", "Potvrda", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                repo.Delete(selectedId.Value);
                LoadData();
                Clear();
            }
        }

        private void Clear()
        {
            selectedId = null;
            txtIme.Text = txtPrezime.Text = txtTelefon.Text = txtEmail.Text = txtNapomena.Text = "";
        }
    }
}