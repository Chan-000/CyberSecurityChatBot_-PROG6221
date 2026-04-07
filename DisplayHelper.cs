using System;
using System.Runtime.InteropServices.Marshalling;

namespace CyberSecurityChatBot
{
    public static class DisplayHelper
    {
        //shows the ASCII art logo
        public static void ShowLogo()
        {
        
           Console.ForegroundColor = ConsoleColor.Cyan;
           Console.WriteLine(@"
            _________         ___.                  __________          __    
\_   ___ \ ___.__.\_ |__    ____ _______\______   \  ____ _/  |_  
/    \  \/<   |  | | __ \ _/ __ \\_  __ \|    |  _/ /  _ \\   __\ 
\     \____\___  | | \_\ \\  ___/ |  | \/|    |   \(  <_> )|  |   
 \______  // ____| |___  / \___  >|__|   |______  / \____/ |__|   
        \/ \/          \/      \/               \/                
                                                                                                                                                                                                                                                                             
           "); 
           Console.WriteLine();
           Console.ResetColor();

        }

        // Welcome box with user's name
        public static void ShowWelcomeMessage(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("           Welcome " + userName + "! to CYBERSECURITY CHATBOT ");
            Console.WriteLine("        Cybersecurity Awareness Assistant for                 ");
            Console.WriteLine("*******************************************************************");
 
            Console.ResetColor();
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
                Thread.Sleep(20);
            }
            Console.ResetColor();
            Console.WriteLine("\n");
     
        }

        //Helper to print in any colour
        public static void PrintColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        //
        public static void TypeText(string text, ConsoleColor color, int delay = 30)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        //draws a nice divider line
        public static void ShowDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("_________________________________________________________________________");
            Console.ResetColor();
        }

    }

}