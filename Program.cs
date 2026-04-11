using System;
using System.Runtime.CompilerServices;
/*
*This is the entry point of the CyberSecurityChatBot
*this class is responsible for starting the program execution
*/
namespace CyberSecurityChatBot
{
    class Program
    {
        /*
        *Main method is where the application begins running 
        *It creates an instance of a ChatBot.cs and start the chatbot
        */
        static void Main(string[] args)
        {
            //creates a new chatbot object
            ChatBot bot = new ChatBot();
            bot.Start();//start the chatbot interaction
            

            //github link:
            //https://github.com/Chan-000/CyberSecurityChatBot_-PROG6221.git
        }
    }
}