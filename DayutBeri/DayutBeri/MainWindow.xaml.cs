using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Net.NetworkInformation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;


namespace DayutBeri
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isBarCorrect = false;
        StringBuilder sb = new StringBuilder();
        List<int> passList = new List<int>();
        int marker = 0;
        static int connectionStatus = 0;
        bool pingable = false;

        public MainWindow()
        {
            
        }

        protected void textInputed(object sender, TextCompositionEventArgs e)
        {
          
            


        }
        

        private void _enterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                checker();
                //Оттестировать почему нет перехода состояния.
                //if (passwordBox.Password == "4606453849072") {
                if (isBarCorrect) { 
                rectangle.Fill = new SolidColorBrush(Colors.DarkGreen);
                    passwordBox.Password = "";
                    marker++;
                    ticketCount.Content = "Количество электронных билетов:" + marker;
                    PassYes.Opacity = 100;
                    PassYes.Content = "Проезд разрешен";
                    isBarCorrect = false;
                }
                else
                {
                    rectangle.Fill = new SolidColorBrush(Colors.DarkRed);
                    PassYes.Opacity = 100;
                    PassYes.Content = "Проезд Запрещен";
                    passwordBox.Password = "";
                }
                
               
            }
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            
                for (int i = 0; i < 10000; i++)
            {
                passList.Add(i);
            }
            PassYes.Opacity = 0;
            PingHost();
            connectMarker.Fill = new SolidColorBrush(Colors.DarkRed);
            passwordBox.Focus();
            if (connectionStatus!=0) { connectMarker.Fill = new SolidColorBrush(Colors.DarkGreen); } else { connectMarker.Fill = new SolidColorBrush(Colors.DarkRed); }
        }
        private void checker()
        {
            foreach (int n in passList)
            {
                if (passwordBox.Password == n.ToString())
                {
                    
                    isBarCorrect = true;
                    break;
                }
                else
                {

                    isBarCorrect = false;
                    
                }
            }

            
        }
        public static bool PingHost()
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send("8.8.8.8");
                pingable = reply.Status == IPStatus.Success;
                connectionStatus++;


            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }
    }
}
