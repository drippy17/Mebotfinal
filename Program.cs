using System;
using System.Media;
using System.IO;
using System.Threading;
using System.Speech.Synthesis;
class Program
{
  
    static void Main()
    {
        Console.Title = "MeBot - Cybersecurity Awareness Assistant"; // Set console title
        DisplayAsciiLogo();
        PlayVoiceGreeting();
        string userName = GetUserInput();
        ShowMenu(userName);
    }

    static void DisplayAsciiLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
___________________
 | _______________ |
 | |XXXXXXXXXXXXX| |
 | |XXXXXXXXXXXXX| |
 | |XXXXXXXXXXXXX| |
 | |XXXXXXXXXXXXX| |
 | |XXXXXXXXXXXXX| |
 |_________________|
     _[_______]_
 ___[___________]___
|         [_____] []|__
|         [_____] []|  \__
L___________________J     \ \___\/
                          /\
                         (__)
______  ___    ________      _____ 
___   |/  /_______  __ )_______  /_
__  /|_/ /_  _ \_  __  |  __ \  __/
_  /  / / /  __/  /_/ // /_/ / /_  
/_/  /_/  \___//_____/ \____/\__/    
""Hi , Im MeBot. here to protect you from the outside dangers of the internet !"" ");
        Console.ResetColor();
    }

    static void PlayVoiceGreeting()
    {
        string audioPath = "Resources/welcome.wav";

        if (File.Exists(audioPath))
        {
            using (SoundPlayer player = new SoundPlayer(audioPath))
            {
                player.PlaySync();
            }
        }
        else
        {
            Console.WriteLine("Audio file not found. Please check the path.");
        }
    }

    static string GetUserInput()
    {
        Console.Write("\n🔹 Please enter your name: ");
        string userName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠ Name cannot be empty. Please enter a valid name.");
            Console.ResetColor();
            Console.Write("\n🔹 Please enter your name: ");
            userName = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n🌟 Welcome, {userName}! MeBot is here to help you stay safe online.");
        Console.WriteLine("💡 You can ask me about cybersecurity topics like password safety, phishing, or safe browsing.");
        Console.ResetColor();
        return userName;
    }

    static void ShowMenu(string userName)
    {
        while (true)
        {
            Console.WriteLine("\n📌 What would you like to ask MeBot?");
            Console.WriteLine("1️⃣ How are you?");
            Console.WriteLine("2️⃣ What's your purpose?");
            Console.WriteLine("3️⃣ What can I ask you about?");
            Console.WriteLine("4️⃣ Password Safety");
            Console.WriteLine("5️⃣ Phishing Protection");
            Console.WriteLine("6️⃣ Safe Browsing Tips");
            Console.WriteLine("7️⃣ Exit");
            Console.Write("👉 Enter a number: ");

            string choice = Console.ReadLine();
            ProcessUserChoice(choice, userName);
        }
    }

    static void ProcessUserChoice(string choice, string userName)
    {
        Console.WriteLine("\n🖥️ MeBot is thinking...");
        Thread.Sleep(1000); // Simulate typing effect

        switch (choice)
        {
            case "1":
                Console.WriteLine("🤖 I'm just a bot, but I'm doing great! Thanks for asking.");
                break;
            case "2":
                Console.WriteLine("🔍 My purpose is to help you stay safe online by providing cybersecurity tips.");
                break;
            case "3":
                Console.WriteLine("🛡️ You can ask about:");
                Console.WriteLine("   - Password safety 🛠️");
                Console.WriteLine("   - Phishing protection 🎣");
                Console.WriteLine("   - Safe browsing tips 🔐");
                break;
            case "4":
                Console.WriteLine("🔑 Password Safety Tip: Use strong, unique passwords for each account.");
                Console.WriteLine("   Consider using a password manager to keep track of them.");
                break;
            case "5":
                Console.WriteLine("🚨 Phishing Alert: Never click on suspicious links in emails.");
                Console.WriteLine("   Always verify the sender before entering any personal information.");
                break;
            case "6":
                Console.WriteLine("🖥️ Safe Browsing: Avoid downloading files from untrusted sources.");
                Console.WriteLine("   Use HTTPS websites for secure transactions.");
                break;
            case "7":
                Console.WriteLine($"👋 Goodbye, {userName}! Stay safe online. 🔐");
                Environment.Exit(0);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠ I didn't quite understand that. Please enter a valid number from the menu.");
                Console.ResetColor();
                break;
        }
    }
}
