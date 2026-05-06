using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RodjendanProjekat.Models
{
    public class Uplata
    {
        public int UplataId { get; set; }
        public int RezervacijaId { get; set; }
        public DateTime DatumUplate { get; set; }
        public decimal Iznos { get; set; }
        public string NacinPlacanja { get; set; }
    }
}