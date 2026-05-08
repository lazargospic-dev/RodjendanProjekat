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
            var klijent = cmbKlijent.SelectedItem as Klijent;
            if (klijent == null) return;

            var sviSlavljenici = slavljenikRepo.GetAll();
            cmbSlavljenik.DataSource = sviSlavljenici.FindAll(s => s.KlijentId == klijent.KlijentId);
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

                foreach (Klijent k in cmbKlijent.Items)
                    if (k.KlijentId == r.KlijentId) { cmbKlijent.SelectedItem = k; break; }

                FilterSlavljenici();

                foreach (Slavljenik s in cmbSlavljenik.Items)
                    if (s.SlavljenikId == r.SlavljenikId) { cmbSlavljenik.SelectedItem = s; break; }

                foreach (Sala sa in cmbSala.Items)
                    if (sa.SalaId == r.SalaId) { cmbSala.SelectedItem = sa; break; }
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
                var klijent = cmbKlijent.SelectedItem as Klijent;
                var slavljenik = cmbSlavljenik.SelectedItem as Slavljenik;
                var sala = cmbSala.SelectedItem as Sala;

                if (klijent == null) { MessageBox.Show("Odaberi klijenta!"); return; }
                if (slavljenik == null) { MessageBox.Show("Odaberi slavljenika!"); return; }
                if (sala == null) { MessageBox.Show("Odaberi salu!"); return; }

                Rezervacija novaRezervacija = new Rezervacija
                {
                    Datum = dtpDatum.Value.Date,
                    VremeOd = dtpVremeOd.Value.TimeOfDay,
                    VremeDo = dtpVremeDo.Value.TimeOfDay,
                    BrojDece = (int)numBrojDece.Value,
                    UkupanIznos = decimal.Parse(string.IsNullOrEmpty(txtIznos.Text) ? "0" : txtIznos.Text),
                    Status = string.IsNullOrEmpty(cmbStatus.Text) ? "Rezervisano" : cmbStatus.Text,
                    KlijentId = klijent.KlijentId,
                    SlavljenikId = slavljenik.SlavljenikId,
                    SalaId = sala.SalaId
                };

                if (novaRezervacija.VremeDo <= novaRezervacija.VremeOd)
                {
                    MessageBox.Show("Vreme završetka mora biti posle vremena početka!", "Neispravno vreme",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (repo.PostojiIdenticna(novaRezervacija))
                {
                    MessageBox.Show("Identična rezervacija već postoji!", "Duplikat",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var konflikt = repo.PronadjiKolizijuSale(novaRezervacija);
                if (konflikt != null)
                {
                    string poruka =
                        $" Sala je već zauzeta u tom terminu!\n\n" +
                        $" Sala: {konflikt.SalaNaziv}\n" +
                        $" Datum: {konflikt.Datum:dd.MM.yyyy}\n" +
                        $" Vreme: {konflikt.VremeOd:hh\\:mm} - {konflikt.VremeDo:hh\\:mm}\n" +
                        $" Klijent: {konflikt.KlijentImePrezime}\n" +
                        $" Slavljenik: {konflikt.SlavljenikIme}\n\n" +
                        $"Izaberi drugi termin ili drugu salu.";

                    MessageBox.Show(poruka, "Sala zauzeta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                repo.Insert(novaRezervacija);
                LoadData();
                Clear();
                MessageBox.Show(" Rezervacija uspešno dodata!", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Greška: " + ex.Message); }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Selektuj red!"); return; }
            try
            {
                var klijent = cmbKlijent.SelectedItem as Klijent;
                var slavljenik = cmbSlavljenik.SelectedItem as Slavljenik;
                var sala = cmbSala.SelectedItem as Sala;

                if (klijent == null || slavljenik == null || sala == null)
                {
                    MessageBox.Show("Odaberi sve vrednosti!");
                    return;
                }

                Rezervacija izmenjenaRezervacija = new Rezervacija
                {
                    RezervacijaId = selectedId.Value,
                    Datum = dtpDatum.Value.Date,
                    VremeOd = dtpVremeOd.Value.TimeOfDay,
                    VremeDo = dtpVremeDo.Value.TimeOfDay,
                    BrojDece = (int)numBrojDece.Value,
                    UkupanIznos = decimal.Parse(string.IsNullOrEmpty(txtIznos.Text) ? "0" : txtIznos.Text),
                    Status = cmbStatus.Text,
                    KlijentId = klijent.KlijentId,
                    SlavljenikId = slavljenik.SlavljenikId,
                    SalaId = sala.SalaId
                };

                if (izmenjenaRezervacija.VremeDo <= izmenjenaRezervacija.VremeOd)
                {
                    MessageBox.Show("Vreme završetka mora biti posle vremena početka!");
                    return;
                }

                if (repo.PostojiIdenticna(izmenjenaRezervacija, ignoreId: selectedId.Value))
                {
                    MessageBox.Show("Identična rezervacija već postoji!");
                    return;
                }
                var konflikt = repo.PronadjiKolizijuSale(izmenjenaRezervacija, ignoreId: selectedId.Value);
                if (konflikt != null)
                {
                    string poruka =
                        $"Sala je već zauzeta u tom terminu!\n\n" +
                        $"Sala: {konflikt.SalaNaziv}\n" +
                        $"Datum: {konflikt.Datum:dd.MM.yyyy}\n" +
                        $"Vreme: {konflikt.VremeOd:hh\\:mm} - {konflikt.VremeDo:hh\\:mm}\n" +
                        $"Klijent: {konflikt.KlijentImePrezime}\n" +
                        $"Slavljenik: {konflikt.SlavljenikIme}\n\n" +
                        $"Izaberi drugi termin ili drugu salu.";

                    MessageBox.Show(poruka, "Sala zauzeta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                repo.Update(izmenjenaRezervacija);
                LoadData();
                Clear();
                MessageBox.Show(" Rezervacija izmenjena!");
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