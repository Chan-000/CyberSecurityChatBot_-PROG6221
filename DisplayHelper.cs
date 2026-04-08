using System;
using System.Runtime.InteropServices.Marshalling;

namespace CyberSecurityChatBot
{
    /*
    *The DisplayHelper.cs is responsible for all visual output in the chatbot.
    *It handles colours, formatting, ASCII art, typing effects and structure UI elements 
    */
    public static class DisplayHelper
    {
        //displays the ASCII art logo at the start of the application
        //acts a s visual header to introduce the chatbot
        public static void ShowLogo()
        {
           //Set text colour of the logo
           Console.ForegroundColor = ConsoleColor.Cyan;
           //Print ASCII art logo
           Console.WriteLine(@"
            _________         ___.                  __________          __    
\_   ___ \ ___.__.\_ |__    ____ _______\______   \  ____ _/  |_  
/    \  \/<   |  | | __ \ _/ __ \\_  __ \|    |  _/ /  _ \\   __\ 
\     \____\___  | | \_\ \\  ___/ |  | \/|    |   \(  <_> )|  |   
 \______  // ____| |___  / \___  >|__|   |______  / \____/ |__|   
        \/ \/          \/      \/               \/                                                                                                                                                                                                                                                                                   
           "); 
           Console.ResetColor();

        }

        // Displays a welcome banner with user's name 
        // uses borders and spacing to create a structured UI section
        public static void ShowWelcomeMessage(string userName)
        {
            //sets the backgroound colour of the welcome banner
            Console.ForegroundColor = ConsoleColor.Green;
            //border + personalised welcome message
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("        Welcome " + userName + "! to CYBERSECURITY CHATBOT         ");
            Console.WriteLine("           Cybersecurity Awareness Assistant            ");
            Console.WriteLine("*******************************************************************");
 
            //Reset console colour
            Console.ResetColor();
        }

        /*
        *Displays the user input prompt in a distinct colour
        *Keeps chatbot responses visually separate from input
        */
        public static void ShowUserPrompt(string userName)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Display user name followed by colon on same line for input
            Console.Write(userName + ": "); 
            Console.ResetColor();
        }

        /*
        *Display the chatbot response with a typing animation effect
        *this simulates a real conversation & "response" is the chatbot reply text
        */
        public static void ShowBotResponse(string response)
        {
            //Display chatbot label
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("CyberBot: ");
            Console.ResetColor();

            //Small delay before typing starts (simulates thinking)
            Thread.Sleep(300);

            //Typing effect for the bot response text
            Console.ForegroundColor = ConsoleColor.White;
            foreach (char c in response)
            {
                Console.Write(c);
                Thread.Sleep(20); //Small delay to simulate typing
            }
            Console.ResetColor();
            Console.WriteLine("\n"); //skips a line
     
        }

        /*
        *Prints text in a specific colour
        *Used for highlighting important message pr sections
        *"text" is the text to display and "color" is the colour to display the text in
        */
        public static void PrintColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /*
        *Display text with a typing effect and optional delay
        *param name "delay" is the typing speed delay
        */
        public static void TypeText(string text, ConsoleColor color, int delay = 30)
        {
            Console.ForegroundColor = color;
            //Small delay before typing starts (simulates thinking)
            Thread.Sleep(300);
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.ResetColor();
            Console.WriteLine(); //moves to the next line
        }

        //Displays a divider line to separate sections of the interface 
        public static void ShowDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("_________________________________________________________________________");
            Console.ResetColor();
        }

    }

}