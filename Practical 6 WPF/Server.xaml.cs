using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Practical_6_WPF
{
    public partial class Server : Window
    {
        private TcpClient client;
        private TcpServer serv;

        public Server(string login)
        {
            InitializeComponent();
            serv = new TcpServer(this, Users);
            client = new TcpClient(login, Messege,"127.0.0.1");
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string exitCommand = "/disconnect";
            if (TextTBox.Text == exitCommand)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                client.SendMessage(TextTBox.Text);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            Close();
        }

            private void Watch_Click(object sender, RoutedEventArgs e)
        {
            LogChats log = new LogChats();
            log.Show();
        }

        private void TextTBox_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextTBox.Text = "";
        }
    }
}
