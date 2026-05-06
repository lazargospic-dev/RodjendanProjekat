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
    public partial class RezervacijeForm : Form
    {
            private RezervacijaRepository repo = new RezervacijaRepository();
            private KlijentRepository klijentRepo = new KlijentRepository();
            private SlavljenikRepository slavljenikRepo = new SlavljenikRepository();
            private SalaRepository salaRepo = new SalaRepository();
            private int? selectedId = null;
            public RezervacijeForm()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadComboBoxes()
        {
            cmbKlijent.DataSource = klijentRepo.GetAll();
            cmbKlijent.DisplayMember = "Ime";
            cmbKlijent.ValueMember = "KlijentId";

            cmbSala.DataSource = salaRepo.GetAll();
            cmbSala.DisplayMember = "Naziv";
            cmbSala.ValueMember = "SalaId";

            FilterSlavljenici();
        }

        private void FilterSlavljenici()
        {
            if (cmbKlijent.SelectedValue == null) return;
            int klijentId = (int)cmbKlijent.SelectedValue;
            var sviSlavljenici = slavljenikRepo.GetAll();
            cmbSlavljenik.DataSource = sviSlavljenici.FindAll(s => s.KlijentId == klijentId);
            cmbSlavljenik.DisplayMember = "Ime";
            cmbSlavljenik.ValueMember = "SlavljenikId";
        }

        private void LoadData()
        {
            dgvRezervacije.DataSource = null;
            dgvRezervacije.DataSource = repo.GetAll();
        }

        private void dgvRezervacije_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRezervacije.CurrentRow?.DataBoundItem is Rezervacija r)
            {
                selectedId = r.RezervacijaId;
                dtpDatum.Value = r.Datum;
                dtpVremeOd.Value = DateTime.Today.Add(r.VremeOd);
                dtpVremeDo.Value = DateTime.Today.Add(r.VremeDo);
                numBrojDece.Value = r.BrojDece;
                txtIznos.Text = r.UkupanIznos.ToString();
                cmbStatus.Text = r.Status;
                cmbKlijent.SelectedValue = r.KlijentId;
                FilterSlavljenici();
                cmbSlavljenik.SelectedValue = r.SlavljenikId;
                cmbSala.SelectedValue = r.SalaId;
            }
        }

        private void cmbKlijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSlavljenici();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSlavljenik.SelectedValue == null) { MessageBox.Show("Odaberi slavljenika!"); return; }
                if (cmbSala.SelectedValue == null) { MessageBox.Show("Odaberi salu!"); return; }

                repo.Insert(new Rezervacija
                {
                    Datum = dtpDatum.Value.Date,
                    VremeOd = dtpVremeOd.Value.TimeOfDay,
                    VremeDo = dtpVremeDo.Value.TimeOfDay,
                    BrojDece = (int)numBrojDece.Value,
                    UkupanIznos = decimal.Parse(string.IsNullOrEmpty(txtIznos.Text) ? "0" : txtIznos.Text),
                    Status = string.IsNullOrEmpty(cmbStatus.Text) ? "Rezervisano" : cmbStatus.Text,
                    KlijentId = (int)cmbKlijent.SelectedValue,
                    SlavljenikId = (int)cmbSlavljenik.SelectedValue,
                    SalaId = (int)cmbSala.SelectedValue
                });
                LoadData();
                Clear();
                MessageBox.Show("Rezervacija dodata!");
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            try
            {
                repo.Update(new Rezervacija
                {
                    RezervacijaId = selectedId.Value,
                    Datum = dtpDatum.Value.Date,
                    VremeOd = dtpVremeOd.Value.TimeOfDay,
                    VremeDo = dtpVremeDo.Value.TimeOfDay,
                    BrojDece = (int)numBrojDece.Value,
                    UkupanIznos = decimal.Parse(string.IsNullOrEmpty(txtIznos.Text) ? "0" : txtIznos.Text),
                    Status = cmbStatus.Text,
                    KlijentId = (int)cmbKlijent.SelectedValue,
                    SlavljenikId = (int)cmbSlavljenik.SelectedValue,
                    SalaId = (int)cmbSala.SelectedValue
                });
                LoadData();
                Clear();
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            if (MessageBox.Show("Obrisati rezervaciju?", "Potvrda", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            dtpDatum.Value = DateTime.Now;
            dtpVremeOd.Value = DateTime.Now;
            dtpVremeDo.Value = DateTime.Now.AddHours(2);
            numBrojDece.Value = 10;
            txtIznos.Text = "0";
            cmbStatus.SelectedIndex = -1;
        }
    }
}