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
using System.Net;
using System.IO;

namespace Module08
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var uri = uriText.Text;
            uri = EnhancedUri(uri);

            try
            {
                var request = WebRequest.Create(uri) as HttpWebRequest;
                var response = request.GetResponse() as HttpWebResponse;

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    displayBox.Text = content;
                }
            }
            catch (WebException ex)
            {

                displayBox.Text = ex.ToString();
            }


        }

        private string EnhancedUri(string uri)
        {
            if (!uri.StartsWith("https://"))
            {
                uri = "https://" + uri;
            }

            if (!uri.EndsWith("/humans.txt"))
            {
                uri += "/humans.txt";
            }

            return uri;
        }
    }
}
