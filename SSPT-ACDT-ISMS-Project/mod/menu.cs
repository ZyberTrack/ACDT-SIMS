namespace SSPT_ACDT_ISMS_Project.mod
{
    public class ConsoleMenu(List<string> menuOptions)
    {
        private List<string> options = menuOptions;

        public int Display()
        {
            int choice = -1;
            int currentOption = 0;
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

            return choice; // gibt due auswahl zurück um sie weiter zu verarbeiten - macht menu Klasse reusable
        }

        private void ShowOptions(int currentOption)
        {
            Console.WriteLine("Menü:");
            for (int i = 0; i < options.Count; i++)
            {
                if (i == currentOption)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // marks the chosen option
                }
                Console.WriteLine($"({i + 1}) {options[i]}"); // displays the Options
                Console.ResetColor();
            }
            Console.WriteLine("\nWählen Sie eine Option mit den Pfeiltasten.");
        }
    }

}