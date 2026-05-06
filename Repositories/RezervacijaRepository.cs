using RodjendanProjekat.DataAccess;
using RodjendanProjekat.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RodjendanProjekat.Repositories
{
    public class RezervacijaRepository
    {
        public List<Rezervacija> GetAll()
        {
            var lista = new List<Rezervacija>();
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                string sql = @"SELECT r.*, k.ime+' '+k.prezime AS klijent_full, s.ime AS slavljenik_ime, sa.naziv AS sala_naziv
                               FROM rezervacije r
                               JOIN klijenti k ON r.klijent_id = k.klijent_id
                               JOIN slavljenici s ON r.slavljenik_id = s.slavljenik_id
                               JOIN sale sa ON r.sala_id = sa.sala_id";
                var cmd = new SqlCommand(sql, con);
                using (var dr = cmd.ExecuteReader())
                    while (dr.Read())
                        lista.Add(new Rezervacija
                        {
                            RezervacijaId = (int)dr["rezervacija_id"],
                            Datum = (DateTime)dr["datum"],
                            VremeOd = (TimeSpan)dr["vreme_od"],
                            VremeDo = (TimeSpan)dr["vreme_do"],
                            BrojDece = (int)dr["broj_dece"],
                            UkupanIznos = (decimal)dr["ukupan_iznos"],
                            Status = dr["status"].ToString(),
                            KlijentId = (int)dr["klijent_id"],
                            SlavljenikId = (int)dr["slavljenik_id"],
                            SalaId = (int)dr["sala_id"],
                            KlijentImePrezime = dr["klijent_full"].ToString(),
                            SlavljenikIme = dr["slavljenik_ime"].ToString(),
                            SalaNaziv = dr["sala_naziv"].ToString()
                        });
            }
            return lista;
        }

        public int Insert(Rezervacija r)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(@"INSERT INTO rezervacije(datum,vreme_od,vreme_do,broj_dece,ukupan_iznos,status,klijent_id,slavljenik_id,sala_id)
                                           OUTPUT INSERTED.rezervacija_id
                                           VALUES(@d,@vo,@vd,@bd,@ui,@st,@k,@sl,@sa)", con);
                cmd.Parameters.AddWithValue("@d", r.Datum);
                cmd.Parameters.AddWithValue("@vo", r.VremeOd);
                cmd.Parameters.AddWithValue("@vd", r.VremeDo);
                cmd.Parameters.AddWithValue("@bd", r.BrojDece);
                cmd.Parameters.AddWithValue("@ui", r.UkupanIznos);
                cmd.Parameters.AddWithValue("@st", r.Status);
                cmd.Parameters.AddWithValue("@k", r.KlijentId);
                cmd.Parameters.AddWithValue("@sl", r.SlavljenikId);
                cmd.Parameters.AddWithValue("@sa", r.SalaId);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update(Rezervacija r)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(@"UPDATE rezervacije SET datum=@d,vreme_od=@vo,vreme_do=@vd,broj_dece=@bd,
                                           ukupan_iznos=@ui,status=@st,klijent_id=@k,slavljenik_id=@sl,sala_id=@sa
                                           WHERE rezervacija_id=@id", con);
                cmd.Parameters.AddWithValue("@d", r.Datum);
                cmd.Parameters.AddWithValue("@vo", r.VremeOd);
                cmd.Parameters.AddWithValue("@vd", r.VremeDo);
                cmd.Parameters.AddWithValue("@bd", r.BrojDece);
                cmd.Parameters.AddWithValue("@ui", r.UkupanIznos);
                cmd.Parameters.AddWithValue("@st", r.Status);
                cmd.Parameters.AddWithValue("@k", r.KlijentId);
                cmd.Parameters.AddWithValue("@sl", r.SlavljenikId);
                cmd.Parameters.AddWithValue("@sa", r.SalaId);
                cmd.Parameters.AddWithValue("@id", r.RezervacijaId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                new SqlCommand("DELETE FROM rezervacija_usluge WHERE rezervacija_id=" + id, con).ExecuteNonQuery();
                new SqlCommand("DELETE FROM rezervacija_zaposleni WHERE rezervacija_id=" + id, con).ExecuteNonQuery();
                new SqlCommand("DELETE FROM uplate WHERE rezervacija_id=" + id, con).ExecuteNonQuery();
                var cmd = new SqlCommand("DELETE FROM rezervacije WHERE rezervacija_id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}