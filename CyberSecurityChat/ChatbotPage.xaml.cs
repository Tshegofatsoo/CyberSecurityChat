using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CyberSecurityChat.Pages
{
    public partial class ChatbotPage : Page
    {
        private string userName = "friend";
        private List<string> chatHistory = new List<string>();

        public ChatbotPage()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            // Save and display user message
            string userDisplay = $"You: {userMessage}";
            ChatHistory.Items.Add(userDisplay);
            chatHistory.Add(userDisplay);

            // Generate bot response
            string response = GenerateResponse(userMessage);

            string botDisplay = $"Ultron: {response}";
            ChatHistory.Items.Add(botDisplay);
            chatHistory.Add(botDisplay);

            ChatHistory.ScrollIntoView(ChatHistory.Items[ChatHistory.Items.Count - 1]);
            UserInput.Clear();
            UserInput.Focus();
        }

        private string GenerateResponse(string input)
        {
            string lower = input.ToLower();

            // Name detection
            if (lower.StartsWith("my name is "))
            {
                userName = input.Substring(11).Trim();
                return $"Nice to meet you, {userName}!";
            }

            if (lower.Contains("what is my name"))
                return $"Your name is {userName}, unless you're tricking me. 😏";

            // Basic convo flow
            if (lower.Contains("hello") || lower.Contains("hi"))
                return $"Hey {userName}! Ready to learn some cyber security?";
            if (lower.Contains("how are you"))
                return "I'm just binary and logic, but thanks for asking! 😊";
            if (lower.Contains("what is your name"))
                return "I'm Ultron, your cybersecurity assistant. I never sleep.";
            if (lower.Contains("thank you"))
                return "You're welcome, stay secure!";
            if (lower.Contains("bye"))
                return $"Goodbye {userName}, don’t forget to log out of your accounts!";

            // Cybersecurity questions
            if (lower.Contains("password"))
                return "Use strong, unique passwords with a manager. No birthdays or names!";
            if (lower.Contains("phishing"))
                return "Phishing tricks you into revealing private info. Always double-check links.";
            if (lower.Contains("wifi"))
                return "Public Wi-Fi is risky. Use VPN or avoid logging in.";
            if (lower.Contains("firewall"))
                return "A firewall protects your system from unauthorized access.";

            // Sentiment
            if (lower.Contains("sad") || lower.Contains("tired") || lower.Contains("depressed"))
                return $"I'm sorry you're feeling down, {userName}. Breathe, hydrate, and take breaks. 💙";
            if (lower.Contains("happy") || lower.Contains("great") || lower.Contains("excited"))
                return $"That's amazing to hear, {userName}! Keep that energy up! ⚡";

            return $"Hmm... I didn’t get that, {userName}. Ask me about cyber security or tell me more.";
        }
    }
}


