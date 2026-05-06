using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RodjendanProjekat.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnKlijenti_Click(object sender, EventArgs e) => new KlijentiForm().ShowDialog();
        private void btnSlavljenici_Click(object sender, EventArgs e) => new SlavljeniciForm().ShowDialog();
        private void btnSale_Click(object sender, EventArgs e) => new SaleForm().ShowDialog();
        private void btnZaposleni_Click(object sender, EventArgs e) => new ZaposleniForm().ShowDialog();
        private void btnUsluge_Click(object sender, EventArgs e) => new DodatneUslugeForm().ShowDialog();
        private void btnRezervacije_Click(object sender, EventArgs e) => new RezervacijeForm().ShowDialog();
        private void btnUplate_Click(object sender, EventArgs e) => new UplateForm().ShowDialog();

        private void btnKlijenti_Click(object sender, EventArgs e)
        {

        }

        private void btnSlavljenici_Click(object sender, EventArgs e)
        {

        }

        private void btnSale_Click(object sender, EventArgs e)
        {

        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {

        }

        private void btnUsluge_Click(object sender, EventArgs e)
        {

        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {

        }

        private void btnUplate_Click(object sender, EventArgs e)
        {

        }
    }
}
