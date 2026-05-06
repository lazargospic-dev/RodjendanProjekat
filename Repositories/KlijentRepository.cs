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
    }
}