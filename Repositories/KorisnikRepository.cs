using RodjendanProjekat.DataAccess;
using RodjendanProjekat.Models;
using System.Data.SqlClient;

namespace RodjendanProjekat.Repositories
{
    public class KorisnikRepository
    {
        public Korisnik Authenticate(string usernameOrEmail, string password)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM korisnici WHERE (username=@u OR email=@u) AND password=@p", con);
                cmd.Parameters.AddWithValue("@u", usernameOrEmail);
                cmd.Parameters.AddWithValue("@p", password);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Korisnik
                        {
                            KorisnikId = (int)dr["korisnik_id"],
                            Ime = dr["ime"].ToString(),
                            Prezime = dr["prezime"].ToString(),
                            Telefon = dr["telefon"]?.ToString(),
                            Email = dr["email"]?.ToString(),
                            Napomena = dr["napomena"]?.ToString(),
                            Username = dr["username"].ToString(),
                            Password = dr["password"].ToString(),
                            Uloga = dr["uloga"]?.ToString()
                        };
                    }
                }
                return null;
            }
        }

        public bool PostojiUsername(string username)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM korisnici WHERE username=@u", con);
                cmd.Parameters.AddWithValue("@u", username);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public void Register(string ime, string prezime, string telefon, string email,
                             string napomena, string username, string password)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(@"INSERT INTO korisnici(ime,prezime,telefon,email,napomena,username,password,uloga)
                                           VALUES(@ime,@prezime,@telefon,@email,@napomena,@username,@password,'Zaposleni')", con);
                cmd.Parameters.AddWithValue("@ime", ime);
                cmd.Parameters.AddWithValue("@prezime", prezime);
                cmd.Parameters.AddWithValue("@telefon", (object)telefon ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)email ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@napomena", (object)napomena ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
            }
        }
    }
}