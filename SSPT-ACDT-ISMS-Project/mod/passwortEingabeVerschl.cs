using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSPT_ACDT_ISMS_Project.mod
{
    public class PasswordInput
    {
        public string GetPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*"); // Zeige einen Stern anstelle des eingegebenen Zeichens
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b"); // Lösche den zuletzt eingegebenen Stern
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(); // Neue Zeile nach der Passworteingabe
            return password;
        }
    }

}
