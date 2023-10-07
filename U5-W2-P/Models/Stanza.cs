using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U5_W2_P.Models
{
    public class Stanza
    {
        public int IdCamera { get; set; }
        public int Numero { get; set; }
        public string Descrizione { get; set; }
        public string Tipologia { get; set; }

        public static List<Stanza> GetStanza()
        {
            List<Stanza> ListaStanza = new List<Stanza>();
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("select * from Camere", sql);
            SqlDataReader sqlDataReader;

            try
            {
                sql.Open();

                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Stanza Stanza = new Stanza();
                    Stanza.IdCamera = Convert.ToInt32(sqlDataReader["IdCamera"]);
                    Stanza.Numero = Convert.ToInt32(sqlDataReader["Numero"]);
                    Stanza.Descrizione = sqlDataReader["Descrizione"].ToString();
                    Stanza.Tipologia = sqlDataReader["Tipologia"].ToString();
                    ListaStanza.Add(Stanza);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ListaStanza;
        }
    }
}