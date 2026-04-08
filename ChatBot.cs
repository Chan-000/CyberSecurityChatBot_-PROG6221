using System;
using System.Media;
using System.Threading.Tasks.Dataflow;


namespace CyberSecurityChatBot
{

    /*
    *The ChatBot class controls the main logic of the application
    *It manages user interaction, input handling, menu navigation and generates cybersecurity responses
    */
    public class ChatBot
    {
        // Stores the chatbot's name used in responses
        public string botName {get; set;}= "CyberBot";
        //Stores the user's name for personalised interaction
        public string userName{get; set;} = "";

        //Start the chatbot by displaying UI elements, playing audio and collecting the user's name
        public void Start()
        {
            //Play voice greeting at application launch
            AudioPlayer.PlayVoiceGreeting();
            // Display ASCII logo header
            DisplayHelper.ShowLogo(); 

            //ask user to enter their name
            Console.Write("Please enter your name: ");
            userName = Console.ReadLine()!;
            
            //automatically uses friend if the user enters nothing
            if (string.IsNullOrEmpty(userName))
            {
                userName = "Friend";
            }
            
            //Display structured welcome message
            DisplayHelper.ShowWelcomeMessage(userName); 

            //Personalised introduction with typing effect
            DisplayHelper.TypeText("Hello " + userName + "! Nice to meet you.", ConsoleColor.Yellow);
            DisplayHelper.TypeText("I'm " + botName + ", your Cybersecurity Assistant, here to assist you in staying safe online.", ConsoleColor.Yellow);
            
            //Divider for visual separation
            DisplayHelper.ShowDivider();
            //Start chatbot conversation loop
            RunChat();
        }

        /*
        *Displays a menue of cybersecurity topics
        *Users can either select a number or type their own question
        */
        public void ShowMenu()
        {
           //Styled menu header using colours and spacing 
           DisplayHelper.PrintColored("\n  ===== Menu =====  ", ConsoleColor.Cyan);
           DisplayHelper.PrintColored("\nChoose a topic or type your own question:",ConsoleColor.DarkCyan); 

           //Menue option with symbols(from ChatGPT) to improve UI appearance
           Console.WriteLine("1.🔐 Password safety");
           Console.WriteLine("2.⚠ Phishing scams");
           Console.WriteLine("3.💻 Malware");
           Console.WriteLine("4.🌐 Safe browsing");
           Console.WriteLine("5.🔑 OTP & PIN scams");
           Console.WriteLine("6.🛡 Updates & Antivirus");
           Console.WriteLine("7. What can l ask\n");

           //Instructions for user navigation
           Console.WriteLine("You can type 'options' to see this menu again");
           DisplayHelper.PrintColored("Type 'exit or 'quit' to quit the conversation.", ConsoleColor.DarkRed);
        }

        /*
        *Runs the main chatbot loop where user interacts with the system
        *Handles input validation, mene selection and response generation
        */
        public void RunChat()
        {
            //Show menu once at the beginning
            ShowMenu();
            DisplayHelper.ShowDivider();

            while (true)
            {
                //Display user input prompt
                DisplayHelper.ShowUserPrompt(userName);
                //Read and normalise input
                string input = Console.ReadLine() ?? "";
                input = input.Trim().ToLower();

                //Validate empty input to prevent errors
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a message so that l am able to assist.");
                    continue;//ask again
                }

                //Exit condition for ending the chat
                if (input == "exit" || input == "quit")
                {
                    DisplayHelper.PrintColored("Goodbye and thank you for chatting, " + userName + ". Stay safe online!", ConsoleColor.DarkYellow);
                    break;
                }

                //Converts menu number input into keyword based input
                if(input == "1") input = "password";
                else if(input == "2") input = "phishing";
                else if(input == "3") input = "malware";
                else if(input == "4") input = "safe browsing";
                else if(input == "5") input = "otp scams";
                else if(input == "6") input = "updates";
                else if(input == "7") input = "what can l ask you about";
                
                //Allow user to reopen the menu at any time
                if (input == "options")
                {
                    ShowMenu();
                    continue;
                }
                
                //Generate chatbot response based on input
                string response = GetResponse(input);
                
                //Display response with typing effect
                DisplayHelper.ShowBotResponse(response);
                DisplayHelper.ShowDivider();

            }
        }
        
        /*
        *Generate chatbot responses based on user input
        *Use keyword matching to identify cybersecurity topics
        */
        public string GetResponse(string input)
        {
            //Ensure consistent processing of user input
            input = input.ToLower().Trim();

            //General conversational responses
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
            else if (input == "what can l ask you about" || input.Contains("ask") ||input.Contains("topics"))
            {
                return "You can ask me anything related to staying safe online, " + userName + ".\n\n" +
                       "Popular topics include:\n" +
                       "-Strong password\n" + 
                       "-Malware\n" +
                       "-safe browsing, phishing,links etc\n" + 
                       "Go ahead and type your question naturally!";
            }

            //cybersecurity-specific responses
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
            else //Default response for unknown input
            {
                return "I'm sorry, " + userName + " l didn't understand that.Could you rephrase your question? Try asking about phishing, passwords or safe browsing.";
            }
        }
    }
}