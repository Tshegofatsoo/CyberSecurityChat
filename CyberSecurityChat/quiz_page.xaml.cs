using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CyberSecurityApp.Pages
{
    public partial class QuizPage : Page
    {
        private List<QuizQuestion> quizData;
        private int questionIndex = 0;
        private int currentScore = 0;

        private Button selectedChoice = null;
        private Button correctChoiceButton = null;

        public QuizPage()
        {
            InitializeComponent();
            LoadQuizData();
            showQuiz();
        }

        private void LoadQuizData()
        {
            quizData = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What does 2FA stand for?",
                    CorrectChoice = "Two-factor authentication",
                    Choices = new List<string>
                    { "two-firewall access", "fast-factor authentication", "two-factor authority" }
                },
                new QuizQuestion
                {
                    Question = "What should you never do with your password?",
                    CorrectChoice = "Share it over WhatsApp",
                    Choices = new List<string>
                    { "Memorize it", "Use symbols and numbers", "Store it in a password manager" }
                },
                new QuizQuestion
                {
                    Question = "Which of the following is a malware type?",
                    CorrectChoice = "Worm",
                    Choices = new List<string> { "Cookie", "Firewall", "Antivirus" }
                },
                new QuizQuestion
                {
                    Question = "Which of the following is the strongest password?",
                    CorrectChoice = "7j$L!zR#xQ2",
                    Choices = new List<string> { "password123", "P@ssword", "Cyril2025" }
                },
                new QuizQuestion
                {
                    Question = "Why is reusing the same password risky?",
                    CorrectChoice = "If one account is hacked, all others are exposed",
                    Choices = new List<string>
                    { "It uses more data", "It's harder to remember", "Hackers can guess it from your birth year" }
                },
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    CorrectChoice = "Sending fake messages to trick people into giving personal info",
                    Choices = new List<string> { "A game where you catch fish", "Blocking spam calls", "Coding a secure website" }
                },
                new QuizQuestion
                {
                    Question = "Which of these is a red flag on a website?",
                    CorrectChoice = "The padlock icon is missing in the URL bar",
                    Choices = new List<string> { "It has ads", "It loads quickly", "It's mobile friendly" }
                },
                new QuizQuestion
                {
                    Question = "What's a safe way to download apps or software?",
                    CorrectChoice = "From the official app store or trusted website",
                    Choices = new List<string>
                    { "From pop-up ads", "Through social media", "From third-party sites" }
                },
                new QuizQuestion
                {
                    Question = "What is clickjacking?",
                    CorrectChoice = "Tricking someone into clicking something harmful",
                    Choices = new List<string>
                    { "Speed-clicking for rewards", "Clicking ads for money", "A game" }
                },
                new QuizQuestion
                {
                    Question = "What does social engineering mean?",
                    CorrectChoice = "Tricking people into giving up sensitive info",
                    Choices = new List<string>
                    { "Engineers using social media", "Building online networks", "Cyber community outreach" }
                }
            };
        }

        private void showQuiz()
        {
            if (questionIndex >= quizData.Count)
            {
                string feedback = currentScore switch
                {
                    var s when s == quizData.Count => "Excellent! 🔐 You’re a Cyber Security Pro!",
                    var s when s >= quizData.Count * 0.7 => "Great job! 💪 Just a few more to master.",
                    var s when s >= quizData.Count * 0.4 => "Not bad! 👀 Keep learning.",
                    _ => "Keep going! 📚 Don’t give up."
                };

                MessageBox.Show($"You completed the quiz with {currentScore}/{quizData.Count}.\n\n{feedback}");

                currentScore = 0;
                questionIndex = 0;
                DisplayScore.Text = $"Score: {currentScore}";
                showQuiz();
                return;
            }

            correctChoiceButton = null;
            selectedChoice = null;

            var currentQuiz = quizData[questionIndex];

            DisplayedQuestion.Text = currentQuiz.Question;

            var shuffled = currentQuiz.Choices.OrderBy(_ => Guid.NewGuid()).ToList();
            int insertIndex = new Random().Next(0, 4);
            shuffled.Insert(insertIndex, currentQuiz.CorrectChoice);

            FirstChoiceButton.Content = shuffled[0];
            SecondChoiceButton.Content = shuffled[1];
            ThirdChoiceButton.Content = shuffled[2];
            FourthChoiceButton.Content = shuffled[3];

            clearStyle();
        }

        private void clearStyle()
        {
            foreach (var choice in new[] { FirstChoiceButton, SecondChoiceButton, ThirdChoiceButton, FourthChoiceButton })
            {
                choice.Background = Brushes.LightGray;
            }
        }

        private void HandleAnswerSelection(object sender, RoutedEventArgs e)
        {
            selectedChoice = sender as Button;
            string chosen = selectedChoice.Content.ToString();
            string correct = quizData[questionIndex].CorrectChoice;

            if (chosen == correct)
            {
                selectedChoice.Background = Brushes.LightGreen;
                correctChoiceButton = selectedChoice;
            }
            else
            {
                selectedChoice.Background = Brushes.DarkRed;
                correctChoiceButton = selectedChoice;
            }
        }

        private void HandleNextQuestion(object sender, RoutedEventArgs e)
        {
            if (selectedChoice == null)
            {
                MessageBox.Show("Please select one choice.");
                return;
            }

            string chosen = selectedChoice.Content.ToString();
            string correct = quizData[questionIndex].CorrectChoice;

            if (chosen == correct)
            {
                currentScore++;
                DisplayScore.Text = $"Score: {currentScore}";
            }

            questionIndex++;
            showQuiz();
        }
    }

    public class QuizQuestion
    {
        public string Question { get; set; }
        public string CorrectChoice { get; set; }
        public List<string> Choices { get; set; }
    }
}
