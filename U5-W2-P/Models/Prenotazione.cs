using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U5_W2_P.Models
{
    public class Prenotazione
    {
        public int IdPrenotazione { get; set; }
        public int ClienteId { get; set; }
        public int NumeroCamera { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public int Anno { get; set; }
        public int NumeroProgressivoAnno { get; set; }
        public DateTime DataArrivo { get; set; }
        public DateTime DataPartenza { get; set; }
        public decimal CaparraConfirmatoria { get; set; }
        public decimal Tariffa { get; set; }
        public string TipoPasto { get; set; }

        public static List<Prenotazione> GetPrenotazione()
        {
            List<Prenotazione> ListaPrenotazione = new List<Prenotazione>();
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("select * from Prenotazioni", sql);
            SqlDataReader sqlDataReader;

            try
            {
                sql.Open();

                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Prenotazione Prenotazione = new Prenotazione();
                    Prenotazione.IdPrenotazione = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                    Prenotazione.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                    Prenotazione.NumeroCamera = Convert.ToInt32(sqlDataReader["NumeroCamera"]);
                    Prenotazione.Anno = Convert.ToInt32(sqlDataReader["Anno"]);
                    Prenotazione.DataArrivo = Convert.ToDateTime(sqlDataReader["DataArrivo"]);
                    Prenotazione.DataPartenza = Convert.ToDateTime(sqlDataReader["DataPartenza"]);
                    Prenotazione.CaparraConfirmatoria = Convert.ToDecimal(sqlDataReader["CaparraConfirmatoria"]);
                    Prenotazione.Tariffa = Convert.ToDecimal(sqlDataReader["Tariffa"]);
                    Prenotazione.TipoPasto = sqlDataReader["TipoPasto"].ToString();
                    Prenotazione.ClienteId = Convert.ToInt32(sqlDataReader["ClienteId"]);
                    Prenotazione.NumeroCamera = Convert.ToInt32(sqlDataReader["NumeroCamera"]);
                    ListaPrenotazione.Add(Prenotazione);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ListaPrenotazione;
        }

            public static Prenotazione CreaPrenotazione(Prenotazione prenotazione)
            {
                string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
                SqlConnection sql = new SqlConnection(Connection);

                SqlCommand cmd = new SqlCommand("INSERT INTO Prenotazioni (DataPrenotazione, NumeroProgressivoAnno, Anno, DataArrivo, DataPartenza, CaparraConfirmatoria, Tariffa, TipoPasto, ClienteId, NumeroCamera) VALUES (@DataPrenotazione, @NumeroProgressivoAnno, @Anno, @DataArrivo, @DataPartenza, @CaparraConfirmatoria, @Tariffa, @TipoPasto, @ClienteId, @NumeroCamera)", sql);

                try
                {
                    sql.Open();

                    cmd.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                    cmd.Parameters.AddWithValue("@NumeroProgressivoAnno", prenotazione.NumeroProgressivoAnno);
                    cmd.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                    cmd.Parameters.AddWithValue("@DataArrivo", prenotazione.DataArrivo);
                    cmd.Parameters.AddWithValue("@DataPartenza", prenotazione.DataPartenza);
                    cmd.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria);
                    cmd.Parameters.AddWithValue("@Tariffa", prenotazione.Tariffa);
                    cmd.Parameters.AddWithValue("@TipoPasto", prenotazione.TipoPasto);
                    cmd.Parameters.AddWithValue("@ClienteId", prenotazione.ClienteId);
                    cmd.Parameters.AddWithValue("@NumeroCamera", prenotazione.NumeroCamera);

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

                return prenotazione;
            }
        }
    }