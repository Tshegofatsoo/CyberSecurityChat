using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CyberSecurityChat.Pages
{
    public partial class AddTask : Page
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void show_chats_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (show_chats.SelectedItem == null) return;

            string selectedTask = show_chats.SelectedItem.ToString();

            if (!selectedTask.Contains("status done"))
            {
                int index = show_chats.Items.IndexOf(selectedTask);
                show_chats.Items[index] = selectedTask + " status done";
            }
            else
            {
                show_chats.Items.Remove(selectedTask);
            }
        }

        private void ask_question(object sender, RoutedEventArgs e)
        {
            string userText = user_question.Text.Trim();

            if (string.IsNullOrEmpty(userText))
            {
                MessageBox.Show("Question field is required!");
                return;
            }

            if (userText.ToLower().Contains("add task"))
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                show_chats.Items.Add("User: " + userText + "\n" + timestamp);
                show_chats.ScrollIntoView(show_chats.Items[show_chats.Items.Count - 1]);
                user_question.Clear();
                user_question.Focus();
            }
            else
            {
                MessageBox.Show("To add a task, start your message with 'add task'.");
            }
        }
    }
}
