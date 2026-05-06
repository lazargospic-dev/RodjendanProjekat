using System;

namespace RodjendanProjekat.Models
{
    public class Slavljenik
    {
        public int SlavljenikId { get; set; }
        public string Ime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Pol { get; set; }
        public int KlijentId { get; set; }
        public override string ToString() => Ime;
    }
}