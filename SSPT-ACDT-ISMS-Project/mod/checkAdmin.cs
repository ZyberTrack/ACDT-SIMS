using Microsoft.Data.SqlClient;
using System.Data;


namespace SSPT_ACDT_ISMS_Project.mod
{
    //Public wegen den Unit Tests!
    public class checkAdmin
    {
        public static bool isAdmin(string username, string password, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                // SQL-Abfrage, um Benutzerdaten abzurufen
                string query = "SELECT COUNT(*) FROM Benutzer WHERE Benutzername = @Username AND Passwort = @Password AND Rolle = @Role";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar)).Value = username;
                    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = password;
                    command.Parameters.Add(new SqlParameter("@Role", SqlDbType.VarChar)).Value = "admin";

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
