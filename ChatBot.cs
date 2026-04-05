using System;
using System.Media;
using System.Threading;

namespace CyberSecurityChatBot
{
public class ChatBot
    {
        //this method will handle all user input and responses
        public string GetResponse(string input)
        {
            //converts text to lowercase, removes extra space
            input = input.ToLower().Trim();

            //chat responses
            if (input == "hello" || input == "hi")
            {
                return "Hello! How can l help you with today?";
            }
            else if (input == "how are you")
            {
                return "I'm just code, but l'm doing great and ready to help you!";
            }
            else if (input == "what is your purpose")
            {
                return "My purpose is to teach you about cybersecurity and online safety.";
            }
            else if (input == "what can l ask you")
            {
                return "You can ask me about password, phishing, malware, safe browsing and etc";
            }
            //cybersecurity topics
            else if (input.Contains("password"))
            {
                return "Use string password with symbols and numbers.";
            }
            else if (input.Contains("phishing"))
            {
                return "Do not click suspicious link in emails";
            }
            else if (input.Contains("malware"))
            {
                return "Malware is harmful software that can damage your device or steal data.";
            }
            else if (input.Contains("safe browsing"))
            {
                return "Only visit trusted websites and avoid clicking suspicious links.";
            }
            //input invalidation
            else if (string.IsNullOrWhiteSpace(input))
            {
                return "Please enter a message so l can help you.";
            }
            else
            {
                return "I'm not sure l understood that.Could you rephrase? Try asking about phishing, passwords or safe browsing.Type 'exit' to stop.";
            }
        }
    }
}