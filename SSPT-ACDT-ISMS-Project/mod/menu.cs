using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SSPT_ACDT_ISMS_Project.mod
{
    public class ConsoleMenu
    {
        private List<string> options;

        public ConsoleMenu(List<string> menuOptions)
        {
            options = menuOptions;
        }

        public void Display()
        {
            int choice = -1;
            int currentOption = -1;
            ConsoleKey key;

            do
            {
                Console.Clear(); // Löscht die Konsolenausgabe
                ShowOptions(currentOption);
                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    currentOption = (currentOption - 1 + options.Count) % options.Count;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    currentOption = (currentOption + 1) % options.Count;
                }
                else if (key == ConsoleKey.Enter)
                {
                    choice = currentOption;
                }
            } while (choice == -1);

            ProcessChoice(choice);
        }

        private void ShowOptions(int currentOption)
        {
            Console.WriteLine("Menü:");
            for (int i = 0; i < options.Count; i++)
            {
                if (i == currentOption)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // marks the chosen option
                }
                Console.WriteLine($"({i + 1}) {options[i]}"); // displays the Options
                Console.ResetColor();
            }
            Console.WriteLine("\nWählen Sie eine Option mit den Pfeiltasten.");
        }

        private void ProcessChoice(int choice)
        {
            Console.Clear(); // Löscht die Konsolenausgabe

            Console.WriteLine($"Option {choice + 1}: {options[choice]} wurde ausgewählt.");
            // Hier können Sie die Logik für Ihre Menüoptionen hinzufügen

            Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();
        }
    }

}