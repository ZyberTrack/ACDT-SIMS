using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSPT_ACDT_ISMS_Project.repo
{
    public class DisplayBenutzerTable
    {
        private string connectionString; // Verbindungszeichenfolge zur Datenbank

        public DisplayBenutzerTable(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ShowTable(string table)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {table}";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Hier können Sie die Daten aus dem Reader lesen und ausgeben
                            // Zum Beispiel:

                            string benutzername = reader.GetString(0);
                            string rang = reader.GetString(2);
                            Console.WriteLine($"Benutzername: {benutzername}, Rolle: {rang}");
                        }
                    }
                }
            }

        } // Die Verbindung wird automatisch geschlossen, wenn der using-Block verlassen wird.

        /*
        enum Level
        {
            admin  = 0,
            user = 1,
        }*/
    }
}