using RodjendanProjekat.DataAccess;
using RodjendanProjekat.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RodjendanProjekat.Repositories
{
    public class UplataRepository
    {
        public List<Uplata> GetAll()
        {
            var lista = new List<Uplata>();
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM uplate", con);
                using (var dr = cmd.ExecuteReader())
                    while (dr.Read())
                        lista.Add(new Uplata
                        {
                            UplataId = (int)dr["uplata_id"],
                            RezervacijaId = (int)dr["rezervacija_id"],
                            DatumUplate = (DateTime)dr["datum_uplate"],
                            Iznos = (decimal)dr["iznos"],
                            NacinPlacanja = dr["nacin_placanja"]?.ToString()
                        });
            }
            return lista;
        }

        public void Insert(Uplata u)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("INSERT INTO uplate(rezervacija_id,datum_uplate,iznos,nacin_placanja) VALUES(@r,@d,@i,@n)", con);
                cmd.Parameters.AddWithValue("@r", u.RezervacijaId);
                cmd.Parameters.AddWithValue("@d", u.DatumUplate);
                cmd.Parameters.AddWithValue("@i", u.Iznos);
                cmd.Parameters.AddWithValue("@n", (object)u.NacinPlacanja ?? System.DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM uplate WHERE uplata_id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}