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
        StringBuilder sb = new StringBuilder();
        int marker = 0;
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

                if (passwordBox.Password == "4606453849072") {
                    rectangle.Fill = new SolidColorBrush(Colors.DarkGreen);
                    passwordBox.Password = "";
                    marker++;
                    ticketCount.Content = "Количество электронных билетов:" + marker;
                    PassYes.Opacity = 100;
                    PassYes.Content = "Проезд разрешен";
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
            List<int> passwords = new List<int>();
                for (int i = 0; i < 1000; i++)
            {
                passwords.Add(i);
            }
            PassYes.Opacity = 0;
            passwordBox.Focus();
        }
    }
}
