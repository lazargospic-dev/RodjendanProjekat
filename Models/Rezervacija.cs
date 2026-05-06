using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace RodjendanProjekat.Models
{
    public class Rezervacija
    {
        public int RezervacijaId { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan VremeOd { get; set; }
        public TimeSpan VremeDo { get; set; }
        public int BrojDece { get; set; }
        public decimal UkupanIznos { get; set; }
        public string Status { get; set; }
        public int KlijentId { get; set; }
        public int SlavljenikId { get; set; }
        public int SalaId { get; set; }
        public string KlijentImePrezime { get; set; }
        public string SlavljenikIme { get; set; }
        public string SalaNaziv { get; set; }
    }
}