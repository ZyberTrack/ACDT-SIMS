using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SSPT_ACDT_ISMS_Project.repo
{
    public class UserRemoval
    {
        private string connectionString;

        public UserRemoval(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void RemoveUser()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Benutzername: ");
            Console.ResetColor();
            string username = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "DELETE FROM Benutzer WHERE Benutzername = @Username;";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Benutzer wurde erfolgreich entfernt.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Benutzer mit diesem Benutzernamen wurde nicht gefunden.");
                        Console.ResetColor();
                    }
                }
            }
        }
    }

}
