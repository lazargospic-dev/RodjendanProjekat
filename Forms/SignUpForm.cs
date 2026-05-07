using RodjendanProjekat.Repositories;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace RodjendanProjekat.Forms
{
    public partial class SignUpForm : Form
    {
        private readonly KlijentRepository _repo = new KlijentRepository();

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                var ime = txtIme.Text.Trim();
                var prezime = txtPrezime.Text.Trim();
                var telefon = txtTelefon.Text.Trim();
                var email = txtEmail.Text.Trim();
                var napomena = txtNapomena.Text.Trim();
                var korisnicko = txtUser.Text.Trim();
                var sifra = txtPassword.Text;

                if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime) || string.IsNullOrEmpty(korisnicko) || string.IsNullOrEmpty(sifra))
                {
                    MessageBox.Show("Popunite obavezna polja: Ime, Prezime, Korisnicko ime i Šifra.");
                    return;
                }

                _repo.Register(ime, prezime, telefon, email, napomena, korisnicko, sifra);
                MessageBox.Show("Uspešna registracija.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Greška u bazi podataka: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
