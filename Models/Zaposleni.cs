using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodjendanProjekat.Models
{
    public class Zaposleni
    {
        public int ZaposleniId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Pozicija { get; set; }
        public override string ToString() => $"{Ime} {Prezime} ({Pozicija})";
    }
}