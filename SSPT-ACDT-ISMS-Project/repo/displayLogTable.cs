﻿using Microsoft.Data.SqlClient;

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

                            string getIdQuery = "SELECT SCOPE_IDENTITY()";
                            using (SqlCommand getIdCommand = new SqlCommand(getIdQuery, connection))
                            {
                                int id = reader.GetInt32(0);
                                DateTime zeitstempel = reader.GetDateTime(1);
                                string schweregrad = reader.GetString(2);
                                string statusT = reader.GetString(3);
                                string melder = reader.GetString(4);
                                string bearbeiter = reader.GetString(5);
                                string beschreibung = reader.GetString(6);
                                string cve = reader.GetString(7);
                                string system = reader.GetString(8);

                                beschreibung = beschreibung.Replace("  ", "_");
                                beschreibung = beschreibung.Replace("_", "");
                                beschreibung = beschreibung.Replace(" ", "_");

                                string output = $"ID:_{id}, Zeitstempel:_{zeitstempel}, Schweregrad:_{schweregrad}, Status:_{statusT}, Melder:_{melder}, Bearbeiter:_{bearbeiter}, Beschreibung:_{beschreibung}, CVE:_{cve}, System:_{system}";
                                output = output.Replace(" ", "");
                                output = output.Replace(",", ",  ");
                                output = output.Replace("_", " ");
                                output = output.Replace(" ,", ",");
                                //output = output.Replace(":", ": ");
                                Console.WriteLine(output);
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

