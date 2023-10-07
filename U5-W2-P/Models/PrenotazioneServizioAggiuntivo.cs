using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U5_W2_P.Models
{
    public class PrenotazioneServizioAggiuntivo
    {
        public int IdPrenotazioneServizioAggiuntivo { get; set; }
        public int PrenotazioneId { get; set; }
        public int ServizioAggiuntivoId { get; set; }
        public DateTime DataAcquisto { get; set; }
        public int Quantita { get; set; }

        public static List<PrenotazioneServizioAggiuntivo> GetPrenotazioneServizioAggiuntivo()
        {
            List<PrenotazioneServizioAggiuntivo> ListaPrenotazioneServizioAggiuntivo = new List<PrenotazioneServizioAggiuntivo>();
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("select * from PrenotazioneServiziAggiuntivi", sql);
            SqlDataReader sqlDataReader;

            try
            {
                sql.Open();

                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    PrenotazioneServizioAggiuntivo PrenotazioneServizioAggiuntivo = new PrenotazioneServizioAggiuntivo();
                    PrenotazioneServizioAggiuntivo.IdPrenotazioneServizioAggiuntivo = Convert.ToInt32(sqlDataReader["IdPrenotazioneServizioAggiuntivo"]);
                    PrenotazioneServizioAggiuntivo.PrenotazioneId = Convert.ToInt32(sqlDataReader["PrenotazioneId"]);
                    PrenotazioneServizioAggiuntivo.ServizioAggiuntivoId = Convert.ToInt32(sqlDataReader["ServizioAggiuntivoId"]);
                    PrenotazioneServizioAggiuntivo.DataAcquisto = Convert.ToDateTime(sqlDataReader["DataAcquisto"]);
                    PrenotazioneServizioAggiuntivo.Quantita = Convert.ToInt32(sqlDataReader["ClienteId"]);
                    ListaPrenotazioneServizioAggiuntivo.Add(PrenotazioneServizioAggiuntivo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ListaPrenotazioneServizioAggiuntivo;
        }

        public static PrenotazioneServizioAggiuntivo CreaServiziAggiuntivi (PrenotazioneServizioAggiuntivo prenotazioneServizioAggiuntivo)
        {
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("INSERT INTO PrenotazioneServiziAggiuntivi (PrenotazioneId, ServizioAggiuntivoId, DataAcquisto, Quantita) VALUES (@PrenotazioneId, @ServizioAggiuntivoId, @DataAcquisto, @Quantita)", sql);

            try
            {
                sql.Open();

                cmd.Parameters.AddWithValue("@PrenotazioneId", prenotazioneServizioAggiuntivo.PrenotazioneId);
                cmd.Parameters.AddWithValue("@ServiziAggiuntiviId", prenotazioneServizioAggiuntivo.ServizioAggiuntivoId);
                cmd.Parameters.AddWithValue("@DataAcquisto", prenotazioneServizioAggiuntivo.DataAcquisto);
                cmd.Parameters.AddWithValue("@DataAcquisto", prenotazioneServizioAggiuntivo.DataAcquisto);
                cmd.Parameters.AddWithValue("@Quantita", prenotazioneServizioAggiuntivo.Quantita);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Inserimento riuscito!");
                }
                else
                {
                    Console.WriteLine("Nessuna riga inserita.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
            finally
            {
                sql.Close();
            }

            return prenotazioneServizioAggiuntivo;
        }
    }
}