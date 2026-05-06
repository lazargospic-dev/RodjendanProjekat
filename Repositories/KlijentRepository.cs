using RodjendanProjekat.DataAccess;
using RodjendanProjekat.DataAccess;
using RodjendanProjekat.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RodjendanProjekat.Repositories
{
    public class KlijentRepository
    {
        public List<Klijent> GetAll()
        {
            var lista = new List<Klijent>();
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM klijenti", con);
                using (var dr = cmd.ExecuteReader())
                    while (dr.Read())
                        lista.Add(new Klijent
                        {
                            KlijentId = (int)dr["klijent_id"],
                            Ime = dr["ime"].ToString(),
                            Prezime = dr["prezime"].ToString(),
                            Telefon = dr["telefon"]?.ToString(),
                            Email = dr["email"]?.ToString(),
                            Napomena = dr["napomena"]?.ToString()
                        });
            }
            return lista;
        }

        // Authenticate by email or several possible username column names and plain-text password 'sifra'.
        public Klijent Authenticate(string usernameOrEmail, string password)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();

                // Try matching by email first
                using (var cmd = new SqlCommand("SELECT * FROM klijenti WHERE email = @u AND sifra = @p", con))
                {
                    cmd.Parameters.AddWithValue("@u", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@p", password);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return MapReaderToKlijent(dr);
                    }
                }

                // Try several possible username column names; catch SqlException if column missing
                var usernameCols = new[] { "korisnicko_ime", "korinsicko_ime", "korisnickoime", "user", "username" };
                foreach (var col in usernameCols)
                {
                    try
                    {
                        var sql = $"SELECT * FROM klijenti WHERE [{col}] = @u AND sifra = @p";
                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@u", usernameOrEmail);
                            cmd.Parameters.AddWithValue("@p", password);
                            using (var dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                    return MapReaderToKlijent(dr);
                            }
                        }
                    }
                    catch (SqlException)
                    {
                        continue;
                    }
                }
            }
            return null;
        }

        private Klijent MapReaderToKlijent(SqlDataReader dr)
        {
            return new Klijent
            {
                KlijentId = (int)dr["klijent_id"],
                Ime = dr["ime"].ToString(),
                Prezime = dr["prezime"].ToString(),
                Telefon = dr["telefon"]?.ToString(),
                Email = dr["email"]?.ToString(),
                Napomena = dr["napomena"]?.ToString()
            };
        }

        public void Insert(Klijent k)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO klijenti(ime,prezime,telefon,email,napomena) VALUES(@i,@p,@t,@e,@n)", con);
                cmd.Parameters.AddWithValue("@i", k.Ime);
                cmd.Parameters.AddWithValue("@p", k.Prezime);
                cmd.Parameters.AddWithValue("@t", (object)k.Telefon ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@e", (object)k.Email ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@n", (object)k.Napomena ?? System.DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Klijent k)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE klijenti SET ime=@i,prezime=@p,telefon=@t,email=@e,napomena=@n WHERE klijent_id=@id", con);
                cmd.Parameters.AddWithValue("@i", k.Ime);
                cmd.Parameters.AddWithValue("@p", k.Prezime);
                cmd.Parameters.AddWithValue("@t", (object)k.Telefon ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@e", (object)k.Email ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@n", (object)k.Napomena ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@id", k.KlijentId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM klijenti WHERE klijent_id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // Register a new klijent with optional username and password fields.
        public void Register(string ime, string prezime, string telefon, string email, string napomena, string korisnickoIme, string sifra)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                // Try to insert with username and password columns. If the DB schema doesn't have these columns
                // this will throw SqlException which should be handled by the caller if needed.
                var cmd = new SqlCommand(
                    "INSERT INTO klijenti(ime,prezime,telefon,email,napomena,korisnicko_ime,sifra) VALUES(@i,@p,@t,@e,@n,@k,@s)", con);
                cmd.Parameters.AddWithValue("@i", (object)ime ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@p", (object)prezime ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@t", (object)telefon ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@e", (object)email ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@n", (object)napomena ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@k", (object)korisnickoIme ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@s", (object)sifra ?? System.DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
