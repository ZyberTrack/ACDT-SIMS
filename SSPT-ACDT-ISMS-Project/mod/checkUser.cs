using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSPT_ACDT_ISMS_Project.mod
{
    internal class CheckUser
    {
        public static bool IsUser(string username, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                // SQL-Abfrage, um Benutzerdaten abzurufen
                string query = "SELECT COUNT(*) FROM Benutzer WHERE Benutzername = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar)).Value = username;

                    int userCount = (int)command.ExecuteScalar();

                    if (userCount == 1)
                    {
                        /*
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nSie haben keine Berechtigung um diese Option auszuwählen.");
                        Console.ResetColor();*/
                        return true;
                    }
                    else
                    {
                        connection.Close();
                    }
                }
            } // Die Verbindung wird automatisch geschlossen, wenn der using-Block verlassen wird. 
            return false;
        }
    }
}
