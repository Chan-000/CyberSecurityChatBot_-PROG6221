using System;
using System.Media;

namespace CyberSecurityChatBot
{
    public class ChatBot
    {
        // Automatic properties (required by the POE)
        public string BotName { get; set; } = "CyberGuard SA";
        public string UserName { get; set; } = "Friend";

        private readonly string greetingAudioPath = "greeting.wav";

        public void Start()
        {
            PlayVoiceGreeting();

            // Ask for name
            Console.WriteLine("Hello! Welcome to CyberGuard SA.");
            Console.Write("Please enter your name: ");
            UserName = Console.ReadLine()?.Trim() ?? "Friend";

            if (string.IsNullOrEmpty(UserName))
                UserName = "Friend";

            ShowPersonalisedWelcome();
            ShowInstructions();
            RunConversationLoop();
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                if (System.IO.File.Exists(greetingAudioPath))
                {
                    SoundPlayer player = new SoundPlayer(greetingAudioPath);
                    player.PlaySync();
                }
            }
            catch
            {
                // Ignore if audio file is missing for now
            }
        }

        private void ShowPersonalisedWelcome()
        {
            Console.WriteLine($"\nHello {UserName}! Nice to meet you.");
            Console.WriteLine($"I am {BotName}, your Cybersecurity Awareness Assistant.");
            Console.WriteLine("I'm here to help you stay safe online.\n");
        }

        private void ShowInstructions()
        {
            Console.WriteLine("You can ask me anything about cybersecurity!");
            Console.WriteLine("Examples: how are you, what is your purpose, phishing, password, malware, safe browsing");
            Console.WriteLine("Type 'exit' to stop.\n");
        }

        private void RunConversationLoop()
        {
            while (true)
            {
                Console.Write($"{UserName}: ");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot: Please type something so I can help you.");
                    continue;
                }

                if (input.ToLower() == "exit" || input.ToLower() == "quit" || input.ToLower() == "bye")
                {
                    Console.WriteLine($"Bot: Goodbye {UserName}! Stay safe online. 👋");
                    break;
                }

                string response = GetResponse(input);
                Console.WriteLine($"Bot: {response}\n");
            }
        }

        public string GetResponse(string input)
        {
            input = input.ToLower().Trim();

            if (input.Contains("hello") || input.Contains("hi"))
                return "Hello! How can I help you with cybersecurity today?";

            if (input.Contains("how are you"))
                return "I'm doing great and ready to help South Africans stay safe online!";

            if (input.Contains("purpose") || input.Contains("who are you"))
                return "My purpose is to teach you about cybersecurity and online safety in South Africa.";

            if (input.Contains("what can i ask"))
                return "You can ask about password, phishing, malware, safe browsing, and more!";

            if (input.Contains("password"))
                return "Use a strong password with at least 12 characters including uppercase, lowercase, numbers and symbols. Never reuse the same password.";

            if (input.Contains("phishing"))
                return "Phishing is when criminals send fake emails or messages to trick you. Never click suspicious links. Always go directly to the official website.";

            if (input.Contains("malware"))
                return "Malware is harmful software that can steal your data or damage your device. Keep your antivirus updated and avoid downloading unknown files.";

            if (input.Contains("safe browsing") || input.Contains("browse"))
                return "Only visit trusted websites. Look for https:// and the padlock icon. Keep your browser updated.";

            // Default response for anything we don't understand
            return "I'm not sure I understood that. Could you rephrase? Try asking about phishing, password, malware or safe browsing.";
        }
    }
}