using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodjendanProjekat.Models
{
    public class Sala
    {
        public int SalaId { get; set; }
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public string Opis { get; set; }
        public override string ToString() => Naziv;
    }
}
