using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace SSPT_ACDT_ISMS_Project.repo
{
    public class LogEntryManager
    {
        private string connectionString;

        public LogEntryManager(string connectionStr)
        {
            connectionString = connectionStr;
        }

        public void GetLogEntries(LogEntryStatus status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM log";

                if (status == LogEntryStatus.Open)
                {
                    query += " WHERE Status = 'OFFEN'";
                }
                else if (status == LogEntryStatus.Closed)
                {
                    query += " WHERE Status = 'GESCHLOSSEN'";
                }
                else if (status == LogEntryStatus.Escalated)
                {
                    query += " WHERE Status = 'ESKALIERT'";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Hier können Sie die Daten aus dem Reader lesen und ausgeben
                            // Zum Beispiel:

                            int id = 0;
                            string getIdQuery = "SELECT SCOPE_IDENTITY()";
                            using (SqlCommand getIdCommand = new SqlCommand(getIdQuery, connection))
                            {
                                id = Convert.ToInt32(getIdCommand.ExecuteScalar());
                                string zeitstempel = reader.GetString(1);
                                string schweregrad = reader.GetString(2);
                                string statusT = reader.GetString(3);
                                string melder = reader.GetString(4);
                                string bearbeiter = reader.GetString(5);
                                string beschreibung = reader.GetString(6);
                                string cve = reader.GetString(7);
                                string system = reader.GetString(8);
                                Console.WriteLine($"ID: {id}, Zeitstempel: {zeitstempel}, Schweregrad: {schweregrad}, Status: {statusT}, Melder: {melder}, Bearbeiter: {bearbeiter}, Beschreibung: {beschreibung}, CVE: {cve}, System: {system}");
                            }
                        }
                        reader.Close();
                    }
                }
            }
            }
        }

    public enum LogEntryStatus
    {
        All,
        Open,
        Closed,
        Escalated
    }

}

