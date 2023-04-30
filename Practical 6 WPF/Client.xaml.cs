using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Practical_6_WPF
{
    public partial class Client : Window
    {
        private TcpClient client;
        public Client(string login, string ip)
        {           
            InitializeComponent();
            client = new TcpClient(login, Messege, ip);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string exitCommand = "/disconnect";
            if (Text.Text == exitCommand)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                client.SendMessage(Text.Text);
            }
        }

        private void Text_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Text.Text = "";
        }
    }
}
