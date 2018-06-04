using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Task2_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private async void BtnGetJSON_ClickAsync(object sender, RoutedEventArgs e)
        {

            string requestPage = "https://jsonplaceholder.typicode.com/posts/1/comments";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(requestPage))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                lblJSONfromHTTP.Content = result;
            }
        }

        private void btnGetJSON_Click(object sender, RoutedEventArgs e)
        {
            /*
            string requestPage = "https://jsonplaceholder.typicode.com/posts/1/comments";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.(requestPage))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                lblJSONfromHTTP.Content = result;
            }
            */
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblJSONfromHTTP.Content = "";
        }
    }
}
