using RodjendanProjekat.Models;
using RodjendanProjekat.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RodjendanProjekat.Forms
{
    public partial class UplateForm : Form
    {
        private UplataRepository repo = new UplataRepository();
        private RezervacijaRepository rezervacijaRepo = new RezervacijaRepository();
        private int? selectedId = null;

        // Pomoćna klasa za ComboBox
        private class RezervacijaPrikaz
        {
            public int RezervacijaId { get; set; }
            public string Prikaz { get; set; }
            public override string ToString() => Prikaz;
        }

        public UplateForm()
        {
            InitializeComponent();
            LoadRezervacije();
            LoadData();
        }

        private void LoadRezervacije()
        {
            var rezervacije = rezervacijaRepo.GetAll()
                .Select(r => new RezervacijaPrikaz
                {
                    RezervacijaId = r.RezervacijaId,
                    Prikaz = $"#{r.RezervacijaId} - {r.KlijentImePrezime} ({r.Datum:dd.MM.yyyy})"
                }).ToList();

            cmbRezervacija.DataSource = rezervacije;
            cmbRezervacija.DisplayMember = "Prikaz";
            cmbRezervacija.ValueMember = "RezervacijaId";
        }

        private void LoadData()
        {
            dgvUplate.DataSource = null;
            dgvUplate.DataSource = repo.GetAll();
        }

        private void dgvUplate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUplate.CurrentRow?.DataBoundItem is Uplata u)
            {
                selectedId = u.UplataId;

                foreach (RezervacijaPrikaz r in cmbRezervacija.Items)
                    if (r.RezervacijaId == u.RezervacijaId) { cmbRezervacija.SelectedItem = r; break; }

                dtpDatumUplate.Value = u.DatumUplate;
                txtIznos.Text = u.Iznos.ToString();
                cmbNacinPlacanja.Text = u.NacinPlacanja;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                var rez = cmbRezervacija.SelectedItem as RezervacijaPrikaz;
                if (rez == null) { MessageBox.Show("Odaberi rezervaciju!"); return; }
                if (string.IsNullOrWhiteSpace(txtIznos.Text)) { MessageBox.Show("Unesi iznos!"); return; }

                repo.Insert(new Uplata
                {
                    RezervacijaId = rez.RezervacijaId,
                    DatumUplate = dtpDatumUplate.Value.Date,
                    Iznos = decimal.Parse(txtIznos.Text),
                    NacinPlacanja = cmbNacinPlacanja.Text
                });
                LoadData();
                Clear();
                MessageBox.Show("Uplata zabeležena!");
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            if (MessageBox.Show("Obrisati uplatu?", "Potvrda", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            dtpDatumUplate.Value = DateTime.Now;
            txtIznos.Text = "";
            cmbNacinPlacanja.SelectedIndex = -1;
        }
    }
}