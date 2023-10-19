using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSPT_ACDT_ISMS_Project.repo
{
    internal class repo_delete_user
    {
        static public class DisplayBenutzer
        {
            //Ausgabe der aktuellen Benutzer
            Console.Clear();
            DisplayBenutzerTable table = new DisplayBenutzerTable(connectionString);
            table.ShowTable("Benutzer");
            Console.ReadKey();
        }
    }
}
