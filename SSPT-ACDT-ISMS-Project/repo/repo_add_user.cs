using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SSPT_ACDT_ISMS_Project.mod;

namespace SSPT_ACDT_ISMS_Project.repo
{
    public class UserRegistration
    {
        private string connectionString;

        public UserRegistration(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void RegisterUser()
        {
            Console.Write("Benutzername eingeben: ");
            string username = Console.ReadLine();

            Console.Write("Passwort eingeben: ");
            PasswordInput passwordInput = new PasswordInput(); // PW Eingabe verschteckt
            string password = passwordInput.GetPassword();

            string role = SelectRole();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Benutzer (Benutzername, Passwort, Rolle) VALUES (@Username, @Password, @Role);";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Benutzer wurde erfolgreich hinzugefügt.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fehler beim Hinzufügen des Benutzers.");
                        Console.ResetColor();
                    }
                }
            }
        }

        private string SelectRole()
        {
            List<string> menuOptions = new List<string>
                {
                    "Administrator",
                    "Standart Benutzer"
                };
            ConsoleMenu menu = new ConsoleMenu(menuOptions);
            int choice = menu.Display();

            if (choice == 0)
            {
                return "admin";
            }
            else
            {
                return "user";
            }

        }
    }

}
