using RodjendanProjekat.Models;
using RodjendanProjekat.Repositories;
using System;
using System.Windows.Forms;

namespace RodjendanProjekat.Forms
{
    public partial class LoginForm : Form
    {
        private readonly KlijentRepository _repo = new KlijentRepository();

        public Klijent LoggedKlijent { get; private set; }

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
                    MessageBox.Show("Unesite korisni?ko ime/email i lozinku.");
                    return;
                }

                var klijent = _repo.Authenticate(user, pass);
                if (klijent != null)
                {
                    LoggedKlijent = klijent;
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("Neispravno korisni?ko ime ili lozinka.");
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
