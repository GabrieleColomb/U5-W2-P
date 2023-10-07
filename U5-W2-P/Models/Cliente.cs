using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U5_W2_P.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string CodiceFiscale { get; set; }

        public static List<Cliente> GetCliente()
        {
            List<Cliente> ListaCliente = new List<Cliente>();
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("select * from Clienti", sql);
            SqlDataReader sqlDataReader;

            try
            {
                sql.Open();

                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Cliente Cliente = new Cliente();
                    Cliente.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                    Cliente.CodiceFiscale = sqlDataReader["CodiceFiscale"].ToString();
                    Cliente.Cognome = sqlDataReader["Cognome"].ToString();
                    Cliente.Nome = sqlDataReader["Nome"].ToString();
                    Cliente.Citta = sqlDataReader["Citta"].ToString();
                    Cliente.Provincia = sqlDataReader["Provincia"].ToString();
                    Cliente.Email = sqlDataReader["Email"].ToString();
                    Cliente.Telefono = sqlDataReader["Telefono"].ToString();
                    Cliente.Cellulare = sqlDataReader["Cellulare"].ToString();
                    ListaCliente.Add(Cliente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ListaCliente;
        }

        public static Cliente CreaCliente(Cliente cliente)
        {
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES (@CodiceFiscale, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)", sql);

            try
            {
                sql.Open();

                cmd.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Citta", cliente.Citta);
                cmd.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);

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

            return cliente;
        }
    }
}