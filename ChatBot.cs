using System;
using System.Media;


namespace CyberSecurityChatBot
{
public class ChatBot
    {

        public string botName = "CyberBot";
        public string userName = "";

        public void Start()
        {
            PlayVoiceGreeting();
            Displayhelper.ShowLogo(); //Shows your ASCII art
            Displayhelper.ShowWelcomeMessage(userName); //Shows a nice welcome box
            Console.WriteLine("Please enter your name: ");
            userName = Console.ReadLine()!;

            //automatically uses friend if the user does not type their name
            if (string.IsNullOrEmpty(userName))
            {
                userName = "Friend";
            }

            Displayhelper.PrintColored("Hello " + userName + "! Nice to meet you.", ConsoleColor.Yellow);
            Displayhelper.PrintColored("I am " + botName + ", your Cybersecurity Assistant who is here to give you practical tips so that you can protect your self online.", ConsoleColor.Yellow);
            Console.WriteLine("Just type yo question naturally.\n");

            Displayhelper.ShowDivider();
            RunChat();
        }

        // plays the voice message
        public void PlayVoiceGreeting()
        {
            //using try and catch method so that the system does not crash when voice does not play
            try
            {

                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync(); //plays fully before continuing
            }
            catch
            {
                Console.WriteLine("Audio file not found!");
            }
        }

        // main chat loop
        public void RunChat()
        {
            while (true)
            {
                //this shows the conversation between the bot and user
                Displayhelper.ShowUserPrompt(userName);

                string input = Console.ReadLine()!.Trim();
                //allows the user to end the chat
                if (input.ToLower() == "exit" || input.ToLower()== "quit")
                {
                    Displayhelper.PrintColored("Goodbye and thank you for chatting, " + userName + ". Stay safe online!", ConsoleColor.DarkYellow);
                    break;
                }
                // Get bot response
                string response = GetResponse(input);
                
                //Shows bot response with typing effect
                Displayhelper.ShowBotResponse(response);
                Displayhelper.ShowDivider();
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
                return "Hello " + userName +  "! How can l help you with today?";
            }
            else if (input == "how are you")
            {
                return "I'm just code, but l'm doing great and ready to help you!";
            }
            else if (input == "what is your purpose" || input.Contains("purpose"))
            {
                return "My purpose is to teach you about cybersecurity and online safety " + userName +".";
            }
            else if (input == "what can l ask you about" || input.Contains("ask") ||input.Contains("topics"))
            {
                return "You can ask me anything related to staying safe online, " + userName + ".\n\n" +
                       "Popular topics inlude:\n" +
                       "-creating strong password\n" + 
                       "-safe browsing, phishing,links etc\n" + 
                       "Go ahead and ask" + userName;
            }
            //cybersecurity topics
            else if (input.Contains("password"))
            {
                return "Use strong password with symbols and numbers.A password should have at least 16 characters long, for example (OkayNow2026!Coffe)";
            }
            else if (input.Contains("phishing"))
            {
                return "Phishing is currently the biggest Cyber threat in SA where scammers send emails or or SMS pretending to be genuine. To avoid this do no click on suspicious links " + userName + ".";
            }
            else if (input.Contains("malware"))
            {
                return "Malware is harmful software that can damage your device or steal data.";
            }
            else if (input.Contains("safe browsing") || input.Contains("suspicious links"))
            {
                return "Only visit trusted websites and avoid clicking suspicious links. Avoid connecting your phone on public Wi-fi.";
            }
            else if (input.Contains("sharing pin") || input.Contains("otp scams"))
            {
                return userName +" never share your OTP or pin because this a very common scam in SA right now.If someone claims to be from your bank, hang up or call the bank using their offficial number.";
            } 
            else if (input.Contains("updates") || input.Contains("antivirus"))
            {
                return "Always keep your phone, computer and apps updated. Enable automatic updates and use built-in protection like Windows Defender.";
            }
            //input invalidation
            else if (string.IsNullOrWhiteSpace(input))
            {
                return "Please enter a message so that l am able to assist.";
            }
            else
            {
                return "I'm not sure l understood that.Could you rephrase? Try asking about phishing, passwords or safe browsing.Type 'exit' or 'quit' to stop.";
            }
        }
    }
}