namespace RodjendanProjekat.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Napomena { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Uloga { get; set; }
        public override string ToString() => Username + " (" + Ime + " " + Prezime + ")";
    }
}