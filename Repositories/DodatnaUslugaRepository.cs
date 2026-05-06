using RodjendanProjekat.DataAccess;
using RodjendanProjekat.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RodjendanProjekat.Repositories
{
    public class DodatnaUslugaRepository
    {
        public List<DodatnaUsluga> GetAll()
        {
            var lista = new List<DodatnaUsluga>();
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM dodatne_usluge", con);
                using (var dr = cmd.ExecuteReader())
                    while (dr.Read())
                        lista.Add(new DodatnaUsluga
                        {
                            UslugaId = (int)dr["usluga_id"],
                            Naziv = dr["naziv"].ToString(),
                            Cena = (decimal)dr["cena"],
                            Opis = dr["opis"]?.ToString()
                        });
            }
            return lista;
        }

        public void Insert(DodatnaUsluga u)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("INSERT INTO dodatne_usluge(naziv,cena,opis) VALUES(@n,@c,@o)", con);
                cmd.Parameters.AddWithValue("@n", u.Naziv);
                cmd.Parameters.AddWithValue("@c", u.Cena);
                cmd.Parameters.AddWithValue("@o", (object)u.Opis ?? System.DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(DodatnaUsluga u)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("UPDATE dodatne_usluge SET naziv=@n,cena=@c,opis=@o WHERE usluga_id=@id", con);
                cmd.Parameters.AddWithValue("@n", u.Naziv);
                cmd.Parameters.AddWithValue("@c", u.Cena);
                cmd.Parameters.AddWithValue("@o", (object)u.Opis ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@id", u.UslugaId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM dodatne_usluge WHERE usluga_id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}