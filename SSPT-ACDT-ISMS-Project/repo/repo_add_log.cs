using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SSPT_ACDT_ISMS_Project.mod;

namespace SSPT_ACDT_ISMS_Project.repo
{


    public class SecurityIncident
    {
        private string connectionString;

        public SecurityIncident(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertIncident(string username)
        {

            DateTime zeitstempel = DateTime.Now; // Automatischer Zeitstempel

            Console.Clear();
            Console.WriteLine("Bitte geben Sie die folgenden Informationen für den Sicherheitsvorfall ein:");
            Schweregrad schweregrad = SelectSchweregrad(); // Schweregrad mit Enum Auswählen

            Console.Clear();
            Console.WriteLine("Bitte geben Sie die folgenden Informationen für den Sicherheitsvorfall ein:");
            Status status = SelectStatus(); // Schweregrad mit Enum Auswählen

            string melder = username; // Melder ist der eingeloggte user der den Vorfall meldet

            string bearbeiter = ""; // nur beim bearbeiten eines offenen Vorfalls benötigt

            Console.Clear();
            Console.WriteLine("Bitte geben Sie die folgenden Informationen für den Sicherheitsvorfall ein:");
            Console.Write("Beschreibung: ");
            string beschreibung = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Bitte geben Sie die folgenden Informationen für den Sicherheitsvorfall ein:");
            Console.Write("CVE: ");
            string cve = Console.ReadLine();
            if (cve == "" || cve == " ") // Wenn nicht eingetragen wird "unbekannt einfügen"
            {
                cve = "unbekannt";
            }

            Console.Clear();
            Console.WriteLine("Bitte geben Sie die folgenden Informationen für den Sicherheitsvorfall ein:");
            Console.Write("System: ");
            string system = Console.ReadLine();
            if (system == "" || system == " ") // Wenn nicht eingetragen wird "unbekannt einfügen"
            {
                system = "unbekannt";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO log (Zeitstempel, Schweregrad, Status, Melder, Bearbeiter, Beschreibung, CVE, System) " +
                    "VALUES (@Zeitstempel, @Schweregrad, @Status, @Melder, @Bearbeiter, @Beschreibung, @CVE, @System);";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add("@Zeitstempel", SqlDbType.DateTime).Value = zeitstempel;
                    command.Parameters.Add("@Schweregrad", SqlDbType.NVarChar, 10).Value = schweregrad;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar, 10).Value = status;
                    command.Parameters.Add("@Melder", SqlDbType.NVarChar, 40).Value = melder;
                    command.Parameters.Add("@Bearbeiter", SqlDbType.NVarChar, 40).Value = bearbeiter;
                    command.Parameters.Add("@Beschreibung", SqlDbType.NVarChar, 300).Value = beschreibung;
                    command.Parameters.Add("@CVE", SqlDbType.NVarChar, 15).Value = cve;
                    command.Parameters.Add("@System", SqlDbType.NVarChar, 10).Value = system;

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Sicherheitsvorfall wurde erfolgreich in die Datenbank eingefügt.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fehler beim Einfügen des Sicherheitsvorfalls in die Datenbank.");
                        Console.ResetColor();
                    }
                }
            }
        }
        private Schweregrad SelectSchweregrad()
        {
            List<string> menuOptions = new List<string>
                {
                    "Niedrig",
                    "Mittel",
                    "Hoch"
                };

            ConsoleMenu menu = new ConsoleMenu(menuOptions);
            int choice = menu.Display();

            if (choice == 0)
            {
                return 0;
            }
            else if (choice == 1) 
            {
                return (Schweregrad)1;
            }
            else
            {
                return (Schweregrad)2;
            }
        }

        private Status SelectStatus()
        {
            List<string> menuOptions = new List<string>
                {
                    "OFFEN",
                    "GESCHLOSSEN"
                };

            ConsoleMenu menu = new ConsoleMenu(menuOptions);
            int choice = menu.Display();

            if (choice == 1)
            {
                return (Status)1;
            }
            else
            {
                return 0;
            }
        }
    }

}
