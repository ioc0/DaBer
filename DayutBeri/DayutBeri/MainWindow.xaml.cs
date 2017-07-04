using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
using System.Net.Http;
using System.Reflection.Emit;


namespace DayutBeri
{
   
    public partial class MainWindow : Window
    {
        bool isBarCorrect = false;
        StringBuilder sb = new StringBuilder();
        List<String> passList = new List<String>();
        int marker = 0;
        static int connectionStatus = 0;
        bool pingable = false;
        private static HttpClient client = new HttpClient();

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
                checkerAsync();
                //Оттестировать почему нет перехода состояния.
                //if (passwordBox.Password == "4607009520018") {
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
            PassYes.Opacity = 0;
            PingHostAsync();
            connectMarker.Fill = new SolidColorBrush(Colors.DarkRed);
            passwordBox.Focus();
            if (connectionStatus!=0) { connectMarker.Fill = new SolidColorBrush(Colors.DarkGreen); } else { connectMarker.Fill = new SolidColorBrush(Colors.DarkRed); }
        }
        private async Task checkerAsync()
        {
            foreach (string n in passList)
            {
                if (passwordBox.Password == n)
                {
                    isBarCorrect = true;
                    
                    passList.Remove(n);
                    try
                    {
                        var url = "http://ioc0kernel.s27.wh1.su/swap/useTicket";
                        var content = n;
                        using (WebClient wc = new WebClient())
                        {
                            var data = new NameValueCollection();
                            data["number"] = n;
                            await wc.UploadStringTaskAsync(url, content);
                            await wc.UploadValuesTaskAsync(url, "POST", data);


                        }
                    }
                    catch (Exception e)
                    {
                       Debug.Print(e.ToString());
                    }
                    

                    break;
                }
                else
                {

                    isBarCorrect = false;

                }
            }


        }
        public  async Task<bool> PingHostAsync()
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
            if (pingable = true)
            {
                try
                {
                    var getresponce = await client.GetStringAsync("http://ioc0kernel.s27.wh1.su/swap/getTickets");
                    string[] tickets = getresponce.Split(';');
                    foreach (string ticket in tickets)
                    {
                        passList.Add(ticket);
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return pingable;
           

        }
    }
}
