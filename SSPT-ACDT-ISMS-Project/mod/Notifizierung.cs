namespace SSPT_ACDT_ISMS_Project.mod
{
    internal class Notifizierung
    {

        public static void SendeNotifizierung() 
        {


            List<string> menuOptions = new List<string>
                {
                    "E-Mail",
                    "SMS"
                };

            ConsoleMenu menu = new ConsoleMenu(menuOptions);
            int choice = menu.Display();

            if (choice == 0)
            {
                Console.Clear();
                Mail_msg.SendMail();
            }

            else
            {
                Console.Clear();
                SMS_msg.SendSMS();
            }



        }
    }
}
