using System;
using System.Runtime.InteropServices.Marshalling;

namespace CyberSecurityChatBot
{
    public static class Displayhelper
    {
        //shows the ASCII art logo
        public static void ShowLogo()
        {
           Console.Clear();
           Console.ForegroundColor = ConsoleColor.Cyan;
           Console.WriteLine(@"
           _________        ___.                 _________                          .__  __          __________        __   
\_   ___ \___.__.\_ |__   ___________/   _____/ ____   ____  __ _________|__|/  |_ ___.__.\______   \ _____/  |_ 
/    \  \<   |  | | __ \_/ __ \_  __ \_____  \_/ __ \_/ ___\|  |  \_  __ \  \   __<   |  | |    |  _//  _ \   __\
\     \___\___  | | \_\ \  ___/|  | \/        \  ___/\  \___|  |  /|  | \/  ||  |  \___  | |    |   (  <_> )  |  
 \______  / ____| |___  /\___  >__| /_______  /\___  >\___  >____/ |__|  |__||__|  / ____| |______  /\____/|__|  
        \/\/          \/     \/             \/     \/     \/                       \/             \/             "

           ); 
           Console.WriteLine();
           Console.ResetColor();

        }

        // Welcome box with user's name
        public static void ShowWelcomeMessage(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("                 Welcome to CYBERSECURITY CHATBOT                  ");
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
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.ResetColor();
        }

        //shows user prompt in Cyan colour
        public static void ShowUserPrompt(string userName)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(userName + ": "); //keeps the USER: and the question the user types on the same line
            Console.ResetColor();
        }

        //typing effect  which makes it fell like a real chat
        public static void ShowBotResponse(string response)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("CyberBot: ");
            Console.ResetColor();

            //Typing effect for bot responses
            Console.ForegroundColor = ConsoleColor.White;
            foreach (char c in response)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
            Console.ResetColor();
            Console.WriteLine("\n");
        }

    }

}