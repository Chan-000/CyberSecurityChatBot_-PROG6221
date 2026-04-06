using System;
using System.Runtime.InteropServices.Marshalling;

namespace CyberSecurityChatBot
{
    public static class Displayhelper
    {
        //shows the ASCII art logo
        public static void ShowLogo()
        {
           Console.ForegroundColor = ConsoleColor.Cyan;
           Console.WriteLine(@"
           _________        ___.                 _________                          .__  __          __________        __   
\_   ___ \___.__.\_ |__   ___________/   _____/ ____   ____  __ _________|__|/  |_ ___.__.\______   \ _____/  |_ 
/    \  \<   |  | | __ \_/ __ \_  __ \_____  \_/ __ \_/ ___\|  |  \_  __ \  \   __<   |  | |    |  _//  _ \   __\
\     \___\___  | | \_\ \  ___/|  | \/        \  ___/\  \___|  |  /|  | \/  ||  |  \___  | |    |   (  <_> )  |  
 \______  / ____| |___  /\___  >__| /_______  /\___  >\___  >____/ |__|  |__||__|  / ____| |______  /\____/|__|  
        \/\/          \/     \/             \/     \/     \/                       \/             \/             "

           ); 
           Console.ResetColor();

        }

        // Welcome box with user's name
        public static void ShowWelcomeMessage(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Welcome" + userName.PadRight(55));
            Console.WriteLine("You are now chatting with CyberBot - CYBERSECURITY CHATBOT");
            Console.WriteLine("*******************************************************************");

            Console.ResetColor();
            Console.ResetColor();
        }

        //Helper to print in any colour
        public static void PrintColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        //draws a nice divider line
        public static void ShowDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ResetColor();
        }

        //typing effect  which makes it fell like a real chat
        public static void TypeText(string text, int delays = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delays);
            }
            Console.WriteLine();
        }

    }

}