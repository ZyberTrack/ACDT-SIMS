using SSPT_ACDT_ISMS_Project.mod;
using System.Net;

namespace SSPT_ACDT_ISMS_Project

{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Login();
            }
            
        }


        static void Login()
        {
            // Sorgt dafür, dass man trotz nicht Vertrauenswürdiger SSL Verbindung connecten kann
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            string connectionString = "Data Source=ZYBERTRACK-PC\\SQLEXPRESS;Database=ISMS-Repository";
            DatabaseLogin login = new DatabaseLogin(connectionString);

            Console.Write("Benutzername: ");
            string username = Console.ReadLine();
            Console.Write("Passwort: ");
            string password = Console.ReadLine();

            bool loggedIn = login.Authenticate(username, password);

            if (loggedIn == true)
            {
                MenuDisplay(); // Hier können Sie den angemeldeten Benutzer weiterleiten oder andere Aktionen ausführen.
            }

        }


        static void MenuDisplay()   // Menü des Programms - menü Punkte hier zu bearbeiten
        {
            List<string> menuOptions = new List<string>
        {
            "Einen Vorfall Eintragen",
            "Einen Vorfall Bearbeiten",
            "Einen Vorfall Schließen",
            "Einen Benutzer Hinzufügen",
            "Einen Benutzer Entfernen",
            "Das Programm beenden"
        };

            ConsoleMenu menu = new ConsoleMenu(menuOptions);
            menu.Display();
        }

    }
}