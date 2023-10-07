using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U5_W2_P.Models
{
    public class ServizioAggiuntivo
    {
        public int IdServizioAggiuntivo { get; set; }

        public string Nome { get; set; }

        public decimal Prezzo { get; set; }

        public static List<ServizioAggiuntivo> GetServizioAggiuntivo()
        {
            List<ServizioAggiuntivo> ListaServizioAggiuntivo = new List<ServizioAggiuntivo>();
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("select * from ServiziAggiuntivi", sql);
            SqlDataReader sqlDataReader;

            try
            {
                sql.Open();

                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ServizioAggiuntivo ServizioAggiuntivo = new ServizioAggiuntivo();
                    ServizioAggiuntivo.IdServizioAggiuntivo = Convert.ToInt32(sqlDataReader["IdServizioAggiuntivo"]);
                    ServizioAggiuntivo.Nome = sqlDataReader["Nome"].ToString();
                    ServizioAggiuntivo.Prezzo = Convert.ToDecimal(sqlDataReader["Prezzo"]);
                    ListaServizioAggiuntivo.Add(ServizioAggiuntivo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ListaServizioAggiuntivo;
        }
    }
}