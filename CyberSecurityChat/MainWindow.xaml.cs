using System.Windows;
using CyberSecurityApp.Pages;
using CyberSecurityChat.Pages; // ✅ must match the AddTask.xaml.cs namespace

namespace CyberSecurityApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new QuizPage());
        }

        private void StartChat_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ChatbotPage());
        }

        private void StartTask_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddTask());
        }
    }
}
