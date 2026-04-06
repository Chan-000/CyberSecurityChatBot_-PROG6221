using System;
using System.Media;

namespace CyberSecurityChatBot
{
    public static class AudioPlayer
    {
        public static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync();
            }
            catch
            {
                //the system does not crash even if the audio is missing or does not play
                Console.WriteLine("Voice greeting could not be played - file may be missing");
            }
        }
    }
}