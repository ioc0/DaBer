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
        public int tick = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textInputed(object sender, TextCompositionEventArgs e)
        {
            
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 11; i++)
            {
                sb.Append(e.Text);
                i++;
            }
            string s = sb.ToString();
            MessageBox.Show(s);

            if (e.Text == "q")
            {
                Close();
            }
            if (e.Text == "1023676281")
            {
                rectangle.Fill = new SolidColorBrush(Colors.Green);
                tick++;
                //ticketCount.Content = "Количество электронных билетов: "+ tick.ToString();
            }
            if (e.Text == "9785496007405")
            {
                rectangle.Fill = new SolidColorBrush(Colors.Red);

            }
        }
    }
}
