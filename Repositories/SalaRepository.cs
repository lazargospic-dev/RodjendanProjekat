using RodjendanProjekat.DataAccess;
using RodjendanProjekat.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RodjendanProjekat.Repositories
{
    public class SalaRepository
    {
        public List<Sala> GetAll()
        {
            var lista = new List<Sala>();
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM sale", con);
                using (var dr = cmd.ExecuteReader())
                    while (dr.Read())
                        lista.Add(new Sala
                        {
                            SalaId = (int)dr["sala_id"],
                            Naziv = dr["naziv"].ToString(),
                            Kapacitet = (int)dr["kapacitet"],
                            Opis = dr["opis"]?.ToString()
                        });
            }
            return lista;
        }

        public void Insert(Sala s)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("INSERT INTO sale(naziv,kapacitet,opis) VALUES(@n,@k,@o)", con);
                cmd.Parameters.AddWithValue("@n", s.Naziv);
                cmd.Parameters.AddWithValue("@k", s.Kapacitet);
                cmd.Parameters.AddWithValue("@o", (object)s.Opis ?? System.DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Sala s)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("UPDATE sale SET naziv=@n,kapacitet=@k,opis=@o WHERE sala_id=@id", con);
                cmd.Parameters.AddWithValue("@n", s.Naziv);
                cmd.Parameters.AddWithValue("@k", s.Kapacitet);
                cmd.Parameters.AddWithValue("@o", (object)s.Opis ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@id", s.SalaId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM sale WHERE sala_id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}