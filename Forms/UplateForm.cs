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

                decimal iznos;
                if (!decimal.TryParse(txtIznos.Text, out iznos) || iznos <= 0)
                {
                    MessageBox.Show("Iznos mora biti broj veći od 0!");
                    return;
                }

                var trenutnaRez = rezervacijaRepo.GetById(rez.RezervacijaId);
                if (trenutnaRez == null)
                {
                    MessageBox.Show("Rezervacija nije pronađena!");
                    return;
                }

                decimal vecPlaceno = repo.UkupnoPlaceno(rez.RezervacijaId);
                if (vecPlaceno >= trenutnaRez.UkupanIznos)
                {
                    MessageBox.Show("Rezervacija je već u potpunosti plaćena!");
                    return;
                }

                repo.Insert(new Uplata
                {
                    RezervacijaId = rez.RezervacijaId,
                    DatumUplate = dtpDatumUplate.Value.Date,
                    Iznos = iznos,
                    NacinPlacanja = cmbNacinPlacanja.Text
                });

                decimal noviZbir = repo.UkupnoPlaceno(rez.RezervacijaId);

                if (noviZbir >= trenutnaRez.UkupanIznos)
                {
                    rezervacijaRepo.UpdateStatus(rez.RezervacijaId, "Plaćeno");
                    MessageBox.Show($"Uplata zabeležena!\nRezervacija je u potpunosti plaćena.");
                }
                else
                {
                    decimal preostalo = trenutnaRez.UkupanIznos - noviZbir;
                    MessageBox.Show($"Uplata zabeležena!\nPreostalo za uplatu: {preostalo} RSD");
                }

                LoadData();
                LoadRezervacije();
                Clear();
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