using System;

namespace CyberSecurityChatBot
{
    class Program
    {
        //the program run from here
        static void Main(string[] args)
        {
           ChatBot bot = new ChatBot();
           Console.Write("Enter your name: ");
           string userName = Console.ReadLine().Trim().ToLower();

           Console.WriteLine("Hello!" + userName +  "Welcome to the Cybersecurity Awareness Bot."); 

           Console.WriteLine("You can ask me anything about cybersecurity!");
           Console.WriteLine("Examples:");
           Console.WriteLine("-How are you?\n-Tell me about Phishing\n -What is safe Browsing?- Or type EXIT or QUIT to end the conversation.\n");
           //Calls the chatBot class 
           

           while (true)
            {
               if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please type something.I didn't catch that.");
                    continue;
                }
                if (input == "exit" || input == "quit" || input == "bye")
                {
                    Console.WriteLine("Goodbye" + userName !+ "Stay safe online.");
                    break;
                }

                string response = bot.GetResponse(input, userName);
                Console.WriteLine("Bot:" + response);
            } 

        }
    }
}