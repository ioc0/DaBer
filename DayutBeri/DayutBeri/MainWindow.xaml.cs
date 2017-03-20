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
            if (e.Text == "q")
            {
                this.Close();
            }
            if (e.Text == "a")
            {
                rectangle.Fill = new SolidColorBrush(Colors.Green);
                tick++;
                ticketCount.Content = "Количество электронных билетов: "+ tick.ToString();
            }
            if (e.Text == "b")
            {
                rectangle.Fill = new SolidColorBrush(Colors.Red);

            }
        }
    }
}
