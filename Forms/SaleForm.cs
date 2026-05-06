using RodjendanProjekat.Models;
using RodjendanProjekat.Repositories;
using System;
using System.Windows.Forms;

namespace RodjendanProjekat.Forms
{
    public partial class SaleForm : Form
    {
        private SalaRepository repo = new SalaRepository();
        private int? selectedId = null;

        public SaleForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvSale.DataSource = null;
            dgvSale.DataSource = repo.GetAll();
        }

        private void dgvSale_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSale.CurrentRow?.DataBoundItem is Sala s)
            {
                selectedId = s.SalaId;
                txtNaziv.Text = s.Naziv;
                txtKapacitet.Text = s.Kapacitet.ToString();
                txtOpis.Text = s.Opis;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                repo.Insert(new Sala
                {
                    Naziv = txtNaziv.Text,
                    Kapacitet = int.Parse(txtKapacitet.Text),
                    Opis = txtOpis.Text
                });
                LoadData();
                Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            repo.Update(new Sala
            {
                SalaId = selectedId.Value,
                Naziv = txtNaziv.Text,
                Kapacitet = int.Parse(txtKapacitet.Text),
                Opis = txtOpis.Text
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
            txtNaziv.Text = txtKapacitet.Text = txtOpis.Text = "";
        }
    }

}


 