using System;
using System.Media;


namespace CyberSecurityChatBot
{
public class ChatBot
    {
        // automatic properties
        public string botName {get; set;}= "CyberBot";
        public string userName{get; set;} = "";

        public void Start()
        {
            AudioPlayer.PlayVoiceGreeting();
            DisplayHelper.ShowLogo(); //Shows your ASCII art

            Console.Write("Please enter your name: ");
            userName = Console.ReadLine()!;
            
            //automatically uses friend if the user does not type their name
            if (string.IsNullOrEmpty(userName))
            {
                userName = "Friend";
            }
            DisplayHelper.ShowWelcomeMessage(userName); //Shows a nice welcome box

            DisplayHelper.TypeText("Hello " + userName + "! Nice to meet you.", ConsoleColor.Yellow);
            DisplayHelper.TypeText("I'm " + botName + ", your Cybersecurity Assistant, here to assist you in staying safe online.", ConsoleColor.Yellow);
            
            ShowMenu();
            DisplayHelper.ShowDivider();
            RunChat();
        }

        //menue option
        public void ShowMenu()
        {
           DisplayHelper.PrintColored("\nChoose a topic or type your own question:",ConsoleColor.DarkCyan); 

           Console.WriteLine("1. Password safety");
           Console.WriteLine("2. Phishing scams");
           Console.WriteLine("3. Malware");
           Console.WriteLine("4. Safe browsing");
           Console.WriteLine("5. OTP & PIN scams");
           Console.WriteLine("6. Updates & Antivirus");
           Console.WriteLine("7. What can l ask\n");
           Console.WriteLine("You can type 'menu' to see this menu list again");
           DisplayHelper.PrintColored("Type 'exit or 'quit' to quit the conversation.", ConsoleColor.DarkRed);
        }

        // main chat loop
        public void RunChat()
        {
            while (true)
            {
                
                //this shows the conversation between the bot and user
                DisplayHelper.ShowUserPrompt(userName);
                string input = Console.ReadLine()!.Trim().ToLower();

                //allows the user to end the chat
                if (input == "exit" || input == "quit")
                {
                    DisplayHelper.PrintColored("Goodbye and thank you for chatting, " + userName + ". Stay safe online!", ConsoleColor.DarkYellow);
                    break;
                }
                //Menu shortcuts
                if(input == "1") input = "password";
                else if(input == "2") input = "phishing";
                else if(input == "3") input = "malware";
                else if(input == "4") input = "safe browsing";
                else if(input == "5") input = "otp scams";
                else if(input == "6") input = "updates";
                else if(input == "7") input = "what can l ask";
                
                if (input.ToLower() == "menu")
                {
                    ShowMenu();
                    continue;
                }
                
                // Get bot response
                string response = GetResponse(input);
                
                //Shows bot response with typing effect
                DisplayHelper.ShowBotResponse(response);
                DisplayHelper.ShowDivider();

            }
        }
        //this method will handle all user input and responses
        public string GetResponse(string input)
        {
            //converts text to lowercase, removes extra space
            input = input.ToLower().Trim();

            //chat responses
            if (input == "hello" || input == "hi")
            {
                return "Hello " + userName +  "! What would you like to learn about today?";
            }
            else if (input == "how are you")
            {
                return "I'm just code, but l'm doing great and always ready to help you stay safe online!";
            }
            else if (input == "what is your purpose" || input.Contains("purpose"))
            {
                return "My purpose " + userName + " is to raise cybersecurity awareness and teach practical tips on online safety.";
            }
            else if (input == "what can l ask" || input.Contains("ask") ||input.Contains("topics"))
            {
                return "You can ask me anything related to staying safe online, " + userName + ".\n\n" +
                       "Popular topics include:\n" +
                       "-Strong password\n" + 
                       "-Malware\n" +
                       "-safe browsing, phishing,links etc\n" + 
                       "Go ahead and type your question naturally!";
            }
            //cybersecurity topics
            else if (input.Contains("password"))
            {
                return "Create strong passwords with at least 16 characters including uppercase, lowercase, numbers and symbols.\n Example:MyS@feP@ss2026!";
            }
            else if (input.Contains("phishing"))
            {
                return "Phishing is currently one of the biggest Cyber threat in SA where scammers send emails or or SMS pretending to be from  banks. Never click on suspicious links " + userName + ".";
            }
            else if (input.Contains("malware"))
            {
                return "Malware is harmful software that can damage your device or steal data. Always keep your antivirus updated.";
            }
            else if (input.Contains("safe browsing") || input.Contains("suspicious links"))
            {
                return "Only visit trusted websites with https://. Avoid clicking unknown links and be careful when using public Wi-fi.";
            }
            else if (input.Contains("sharing pin") || input.Contains("otp scams"))
            {
                return userName +" never share your OTP or pin because this a very common scam in SA right now. Always verify by calling the official number.";
            } 
            else if (input.Contains("updates") || input.Contains("antivirus"))
            {
                return "Always keep your devices and apps updated. Enable automatic updates and use good antivirus protection.";
            }
            //input invalidation
            else if (string.IsNullOrWhiteSpace(input))
            {
                return "Please enter a message so that l am able to assist.";
            }
            else
            {
                return "I'm sorry, " + userName + " l didn't understand that.Could you rephrase your question? Try asking about phishing, passwords or safe browsing.";
            }
        }
    }
}