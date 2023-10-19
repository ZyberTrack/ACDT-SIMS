using SSPT_ACDT_ISMS_Project.mod;
using SSPT_ACDT_ISMS_Project.repo;
using System.Net;
using System.Net.Quic;

namespace SSPT_ACDT_ISMS_Project

{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool endProgram = false;
            while (endProgram == false)
            {
                Console.Clear();
                endProgram = Login();
            }
 
        }
        static bool Login()
        {
            string connectionString = "Server=localhost,1433;Database=ISMS-REPO;User=sa;Password=12qwasyxcvfgtz&/;Encrypt=False;\r\n";
            DatabaseLogin login = new DatabaseLogin(connectionString);

            Console.Write("Benutzername: ");
            string username = Console.ReadLine();
            Console.Write("Passwort: ");
            PasswordInput passwordInput = new PasswordInput(); // PW Eingabe verschteckt
            string password = passwordInput.GetPassword();

            bool loggedIn = login.Authenticate(username, password);

            if (loggedIn == true)
            {
                // Dauerschleife um eingeloggt zu bleiben
                int endProgram = -1; // variable zum beenden des Programms
                while (endProgram == -1)
                {
                    endProgram = MenuDisplay(username, password, connectionString); // Hier können Sie den angemeldeten Benutzer weiterleiten oder andere Aktionen ausführen.
                }
                if(endProgram == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        static int MenuDisplay(string username, string password, string connectionString)   // Menü des Programms - menü Punkte hier zu bearbeiten
        {
            List<string> menuOptions = new List<string>
            {
                "Event Management",
                "Benutzerverwaltung",
                "Ausloggen",
                "Das Programm beenden"
            };

            ConsoleMenu menu = new ConsoleMenu(menuOptions);
            int choice = menu.Display();

            // Event Management
            if (choice == 0) 
            {
                Console.Clear(); // Löscht die Konsolenausgabe
                while (true)
                {
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

                        return -1; //zurück zum Menü Programm wird nicht beendet
                    }
                }
            }

            // Benutzerverwaltung -- nur für admins
            else if (choice == 1 && checkAdmin.isAdmin(username,password, connectionString) == true)
            {
                Console.Clear(); // Löscht die Konsolenausgabe

                while (true)
                {
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
                        //Ausgabe der aktuellen Benutzer
                        Console.Clear();
                        DisplayBenutzerTable table = new DisplayBenutzerTable(connectionString);
                        table.ShowTable("Benutzer");
                        Console.ReadKey();
                    }
                    else
                    {

                        return -1; //zurück zum Menü Programm wird nicht beendet
                    }
                }
            }
            else if (choice == 1 && checkAdmin.isAdmin(username, password, connectionString) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sie haben keine Berechtigung die Benutzer zu verwalten");
                Console.ReadKey();
                Console.ResetColor();
                Console.Clear();
                return -1; //zurück zum Menü Programm wird nicht beendet
            }

            else if (choice == 2)
            {
                //true user wird nur ausgelogt
                return 0;
            }

            else
            {
                Console.Clear();
                return 1; //Programm wird beendet
            }
        }
    }
}