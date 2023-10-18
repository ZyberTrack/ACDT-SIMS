using SSPT_ACDT_ISMS_Project.mod;

namespace SSPT_ACDT_ISMS_Project

{
    internal class Program
    {


        // Menü des Programms - menü Punkte hier zu bearbeiten
        static void Main(string[] args)
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