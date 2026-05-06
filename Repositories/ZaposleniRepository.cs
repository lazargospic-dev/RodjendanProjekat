using RodjendanProjekat.DataAccess;
using RodjendanProjekat.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RodjendanProjekat.Repositories
{
    public class ZaposleniRepository
    {
        public List<Zaposleni> GetAll()
        {
            var lista = new List<Zaposleni>();
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM zaposleni", con);
                using (var dr = cmd.ExecuteReader())
                    while (dr.Read())
                        lista.Add(new Zaposleni
                        {
                            ZaposleniId = (int)dr["zaposleni_id"],
                            Ime = dr["ime"].ToString(),
                            Prezime = dr["prezime"].ToString(),
                            Telefon = dr["telefon"]?.ToString(),
                            Pozicija = dr["pozicija"]?.ToString()
                        });
            }
            return lista;
        }

        public void Insert(Zaposleni z)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("INSERT INTO zaposleni(ime,prezime,telefon,pozicija) VALUES(@i,@p,@t,@po)", con);
                cmd.Parameters.AddWithValue("@i", z.Ime);
                cmd.Parameters.AddWithValue("@p", z.Prezime);
                cmd.Parameters.AddWithValue("@t", (object)z.Telefon ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@po", (object)z.Pozicija ?? System.DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Zaposleni z)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("UPDATE zaposleni SET ime=@i,prezime=@p,telefon=@t,pozicija=@po WHERE zaposleni_id=@id", con);
                cmd.Parameters.AddWithValue("@i", z.Ime);
                cmd.Parameters.AddWithValue("@p", z.Prezime);
                cmd.Parameters.AddWithValue("@t", (object)z.Telefon ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@po", (object)z.Pozicija ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@id", z.ZaposleniId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM zaposleni WHERE zaposleni_id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}