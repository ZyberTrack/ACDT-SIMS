using SSPT_ACDT_ISMS_Project.mod;
using System.Net;
using System.Net.Quic;

namespace SSPT_ACDT_ISMS_Project

{
    internal class Program
    {

        static void Main(string[] args)
        {   
            Login();
        }
        static void Login()
        {
            string connectionString = "Server=localhost,1433;Database=ISMS-REPO;User=sa;Password=12qwasyxcvfgtz&/;Encrypt=False;\r\n";
            DatabaseLogin login = new DatabaseLogin(connectionString);

            Console.Write("Benutzername: ");
            string username = Console.ReadLine();
            Console.Write("Passwort: ");
            string password = Console.ReadLine();

            bool loggedIn = login.Authenticate(username, password);

            if (loggedIn == true)
            {
                // Dauerschleife um eingeloggt zu bleiben
                bool endProgram = false; // variable zum beenden des Programms
                while (endProgram == false)
                {
                    endProgram = MenuDisplay(username, password, connectionString); // Hier können Sie den angemeldeten Benutzer weiterleiten oder andere Aktionen ausführen.
                }
            }

        }
        static bool MenuDisplay(string username, string password, string connectionString)   // Menü des Programms - menü Punkte hier zu bearbeiten
        {
            List<string> menuOptions = new List<string>
            {
                "Event Management",
                "Benutzerverwaltung",
                "Das Programm beenden"
            };

            ConsoleMenu menu = new ConsoleMenu(menuOptions);
            int choice = menu.Display();

            // Event Management
            if (choice == 0) 
            {
                Console.Clear(); // Löscht die Konsolenausgabe

                // Weitere Optionen im Event Management
                menuOptions = new List<string>
                {
                    "Einen neuen Vorfall Erfassen",
                    "Offene Vorfälle",
                    "Alle Vorfälle",
                    "Zurück zum Menü"
                };

                menu = new ConsoleMenu(menuOptions);
                int secChoice = menu.Display();

                if (secChoice == 0)
                {

                }
                else if (secChoice == 1)
                {

                }
                else
                {

                    return false; //zurück zum Menü Programm wird nicht beendet
                }


                return false; //Programm wird nicht beendet
            }

            // Benutzerverwaltung -- nur für admins
            else if (choice == 1 && checkAdmin.isAdmin(username,password, connectionString) == true)
            {
                Console.Clear(); // Löscht die Konsolenausgabe

                // Weitere Optionen im Event Management
                menuOptions = new List<string>
                {
                    "Benutzer Hinzufügen",
                    "Benutzer Entfernen",
                    "Zurück zum Menü"
                };

                menu = new ConsoleMenu(menuOptions);
                int secChoice = menu.Display();

                if (secChoice == 0)
                {

                }
                else if (secChoice == 1)
                {

                }
                else
                {

                    return false; //zurück zum Menü Programm wird nicht beendet
                }

                return false; //Programm wird nicht beendet
            }
            else if (choice == 1 && checkAdmin.isAdmin(username, password, connectionString) == false)
            {
                Console.WriteLine("Sie haben keine Berechtigung die Benutzer zu verwalten");
                Console.ReadKey();
                Console.Clear();
                return false; //zurück zum Menü Programm wird nicht beendet
            }

            else
            {
                Console.Clear();
                return true; //Programm wird beendet
            }
        }
    }
}