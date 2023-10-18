using System;
using System.Data;
using System.Net;
using Microsoft.Data.SqlClient;

namespace SSPT_ACDT_ISMS_Project.mod
{


    public class DatabaseLogin
    {
        private string connectionString; // Verbindungszeichenfolge zur Datenbank

        public DatabaseLogin(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Authenticate(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                // SQL-Abfrage, um Benutzerdaten abzurufen
                string query = "SELECT COUNT(*) FROM Benutzer WHERE Benutzername = @Username AND Passwort = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar)).Value = username;
                    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = password;

                    int userCount = (int)command.ExecuteScalar();

                    if (userCount == 1)
                    {
                        Console.WriteLine("Anmeldung erfolgreich.");
                        connection.Close();
                        return true;
                    }
                }
                connection.Close();
            } // Die Verbindung wird automatisch geschlossen, wenn der using-Block verlassen wird.

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Anmeldung fehlgeschlagen. Bitte überprüfen Sie Ihren Benutzernamen und Ihr Passwort.");
            Console.ResetColor();
            return false;
        }
    }
}