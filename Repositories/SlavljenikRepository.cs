using RodjendanProjekat.DataAccess;
using RodjendanProjekat.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RodjendanProjekat.Repositories
{
    public class SlavljenikRepository
    {
        public List<Slavljenik> GetAll()
        {
            var lista = new List<Slavljenik>();
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM slavljenici", con);
                using (var dr = cmd.ExecuteReader())
                    while (dr.Read())
                        lista.Add(new Slavljenik
                        {
                            SlavljenikId = (int)dr["slavljenik_id"],
                            Ime = dr["ime"].ToString(),
                            DatumRodjenja = (DateTime)dr["datum_rodjenja"],
                            Pol = dr["pol"]?.ToString(),
                            KlijentId = (int)dr["klijent_id"]
                        });
            }
            return lista;
        }

        public void Insert(Slavljenik s)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("INSERT INTO slavljenici(ime,datum_rodjenja,pol,klijent_id) VALUES(@i,@d,@p,@k)", con);
                cmd.Parameters.AddWithValue("@i", s.Ime);
                cmd.Parameters.AddWithValue("@d", s.DatumRodjenja);
                cmd.Parameters.AddWithValue("@p", (object)s.Pol ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@k", s.KlijentId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Slavljenik s)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("UPDATE slavljenici SET ime=@i,datum_rodjenja=@d,pol=@p,klijent_id=@k WHERE slavljenik_id=@id", con);
                cmd.Parameters.AddWithValue("@i", s.Ime);
                cmd.Parameters.AddWithValue("@d", s.DatumRodjenja);
                cmd.Parameters.AddWithValue("@p", (object)s.Pol ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@k", s.KlijentId);
                cmd.Parameters.AddWithValue("@id", s.SlavljenikId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM slavljenici WHERE slavljenik_id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}