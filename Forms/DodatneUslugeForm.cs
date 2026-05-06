using RodjendanProjekat.Models;
using RodjendanProjekat.Repositories;
using System;
using System.Windows.Forms;

namespace RodjendanProjekat.Forms
{
    public partial class DodatneUslugeForm : Form
    {
        private DodatnaUslugaRepository repo = new DodatnaUslugaRepository();
        private int? selectedId = null;

        public DodatneUslugeForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvUsluge.DataSource = null;
            dgvUsluge.DataSource = repo.GetAll();
        }

        private void dgvUsluge_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsluge.CurrentRow?.DataBoundItem is DodatnaUsluga u)
            {
                selectedId = u.UslugaId;
                txtNaziv.Text = u.Naziv;
                txtCena.Text = u.Cena.ToString();
                txtOpis.Text = u.Opis;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNaziv.Text)) { MessageBox.Show("Unesi naziv!"); return; }

                repo.Insert(new DodatnaUsluga
                {
                    Naziv = txtNaziv.Text,
                    Cena = decimal.Parse(txtCena.Text),
                    Opis = txtOpis.Text
                });
                LoadData();
                Clear();
                MessageBox.Show("Usluga dodata!");
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            try
            {
                repo.Update(new DodatnaUsluga
                {
                    UslugaId = selectedId.Value,
                    Naziv = txtNaziv.Text,
                    Cena = decimal.Parse(txtCena.Text),
                    Opis = txtOpis.Text
                });
                LoadData();
                Clear();
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            if (MessageBox.Show("Obrisati uslugu?", "Potvrda", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            txtNaziv.Text = "";
            txtCena.Text = "";
            txtOpis.Text = "";
        }
    }
}