using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodjendanProjekat.Models
{
    public class DodatnaUsluga
    {
        public int UslugaId { get; set; }
        public string Naziv { get; set; }
        public decimal Cena { get; set; }
        public string Opis { get; set; }
        public override string ToString() => $"{Naziv} ({Cena} RSD)";
    }
}