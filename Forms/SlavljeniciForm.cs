using RodjendanProjekat.Models;
using RodjendanProjekat.Repositories;
using System;
using System.Windows.Forms;

namespace RodjendanProjekat.Forms
{
    public partial class SlavljeniciForm : Form
    {
        private SlavljenikRepository repo = new SlavljenikRepository();
        private KlijentRepository klijentRepo = new KlijentRepository();
        private int? selectedId = null;

        public SlavljeniciForm()
        {
            InitializeComponent();
            LoadKlijente();
            LoadData();
        }

        private void LoadKlijente()
        {
            cmbKlijent.DataSource = klijentRepo.GetAll();
            cmbKlijent.DisplayMember = "Ime";
            cmbKlijent.ValueMember = "KlijentId";
        }

        private void LoadData()
        {
            dgvSlavljenici.DataSource = null;
            dgvSlavljenici.DataSource = repo.GetAll();
        }

        private void dgvSlavljenici_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSlavljenici.CurrentRow?.DataBoundItem is Slavljenik s)
            {
                selectedId = s.SlavljenikId;
                txtIme.Text = s.Ime;
                dtpDatumRodjenja.Value = s.DatumRodjenja;
                cmbPol.Text = s.Pol;
                cmbKlijent.SelectedValue = s.KlijentId;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIme.Text)) { MessageBox.Show("Unesi ime!"); return; }
                if (cmbKlijent.SelectedValue == null) { MessageBox.Show("Odaberi klijenta!"); return; }

                repo.Insert(new Slavljenik
                {
                    Ime = txtIme.Text,
                    DatumRodjenja = dtpDatumRodjenja.Value,
                    Pol = cmbPol.Text,
                    KlijentId = (int)cmbKlijent.SelectedValue
                });
                LoadData();
                Clear();
                MessageBox.Show("Slavljenik dodat!");
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            try
            {
                repo.Update(new Slavljenik
                {
                    SlavljenikId = selectedId.Value,
                    Ime = txtIme.Text,
                    DatumRodjenja = dtpDatumRodjenja.Value,
                    Pol = cmbPol.Text,
                    KlijentId = (int)cmbKlijent.SelectedValue
                });
                LoadData();
                Clear();
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            if (MessageBox.Show("Obrisati slavljenika?", "Potvrda", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            dtpDatumRodjenja.Value = DateTime.Now;
            cmbPol.SelectedIndex = -1;
            if (cmbKlijent.Items.Count > 0) cmbKlijent.SelectedIndex = 0;
        }
    }
}