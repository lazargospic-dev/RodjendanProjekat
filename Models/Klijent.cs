using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace RodjendanProjekat.Models
    {
        public class Klijent
        {
            public int KlijentId { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Telefon { get; set; }
            public string Email { get; set; }
            public string Napomena { get; set; }
            public override string ToString() => $"{Ime} {Prezime}";
        }
    }
