using RodjendanProjekat.Models;
using RodjendanProjekat.Repositories;
using System;
using System.Windows.Forms;

namespace RodjendanProjekat.Forms
{
    public partial class LoginForm : Form
    {
        private readonly KorisnikRepository _repo = new KorisnikRepository();

        public Korisnik LoggedKorisnik { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var user = txtUser.Text.Trim();
                var pass = txtPassword.Text;
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Unesite korisničko ime/email i lozinku.");
                    return;
                }

                var korisnik = _repo.Authenticate(user, pass);
                if (korisnik != null)
                {
                    LoggedKorisnik = korisnik;
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("Neispravno korisničko ime ili lozinka.");
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

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            using (var sign = new SignUpForm())
            {
                var res = sign.ShowDialog();
                if (res == DialogResult.OK)
                {
                    MessageBox.Show("Registracija uspešna. Možete se prijaviti.");
                }
            }
        }
    }
}