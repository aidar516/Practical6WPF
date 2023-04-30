using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Practical_6_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (NameUser.Text == "Admin")
            {
                if (IP.Text.Length <= 16 && IP.Text.Length != 0)
                {
                    Server server = new Server(NameUser.Text);
                    server.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Введите ip");
                }
            }
            else if (NameUser.Text == "User")
            {
                if (IP.Text.Length <= 16 && IP.Text.Length != 0)
                {
                    Client client = new Client(NameUser.Text, IP.Text);
                    client.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Введите ip");
                }
            }
            else
            {
                MessageBox.Show("Введите имя пользователя");
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (NameUser.Text == "Admin" || NameUser.Text == "User")
            {
                Server server = new Server(NameUser.Text);
                server.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Введите имя пользователя");
            }
        }

        private void IP_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static readonly Regex onlyNumbers = new Regex("[^0-9.]+");

        private static bool IsTextAllowed(string text)
        {
            return !onlyNumbers.IsMatch(text);
        }
    }
}
