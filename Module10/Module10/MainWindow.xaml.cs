using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace Module10
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

            startButton.IsEnabled = false;

            Task t = new Task(()=> HighCPUActivity(10));
            
            t.Start();


            t.ContinueWith(previousTask => {

                //Dispatcher
                Dispatcher.BeginInvoke(new Action(() => startButton.IsEnabled = true));
            
            });

        }


        private void HighCPUActivity(int startValue)
        {
            for (int i = startValue; i >= 0; i--)
            {
                Log(i.ToString());
                UpdateCounter(i.ToString());
                //countdownTextBlock.Text = i.ToString();
                Thread.Sleep(1000);
            }
            Log("Blastoff!!");
            UpdateCounter("Blastoff!!");
            //countdownTextBlock.Text = "Blastoff!!";
        }


        private void HighCPUActivity()
        {
            for (int i = 10; i >= 0; i--)
            {
                Log(i.ToString());
                UpdateCounter(i.ToString());
                //countdownTextBlock.Text = i.ToString();
                Thread.Sleep(1000);
            }
            Log("Blastoff!!");
            UpdateCounter("Blastoff!!");
            //countdownTextBlock.Text = "Blastoff!!";
        }




        void UpdateCounter(string message)
        {
            //this.CheckAccess
            //this.VerifyAccess
            if (this.CheckAccess())
            {
                countdownTextBlock.Text = message;
            }
            else
            {
                //Ask the main thread to do the update
                Dispatcher.BeginInvoke(new Action(() => { countdownTextBlock.Text = message; }));
            }
        }



        delegate void LogHandler(string message);



        void Demo2()
        {
            LogHandler h1 = new LogHandler(Log);
            LogHandler h2 = new LogHandler(Popup);

            Action<string> h3 = new Action<string>(Log);


            h1.Invoke("hey");
            h2.Invoke("there");

            //or, more simply

            h1("hey");
            h2("there");
        }

        //Action = void functions (subs)
        //delegate void Action();
        //delegate void Action<T>(T paramter);
        //delegate void Action<T1, T2>(T1 parameter1, T2 parameter2);
        // up to 16 parameters

        //Func for returning values
        //delegate T Func<T>();
        //delegate TReturn Func<T1, TReturn>(T1 parameter);
        //delegate TReturn Func<T1, T2, TReturn>(T1 parameter1, T2 parameter2);
        //up to 16 parameters

        void Demo3()
        {

            Process[] procs = Process.GetProcesses();


            //lambda expression

            var bp = procs.Where(p => p.WorkingSet64 > 1_000_000_000);


            var bigProcesses = procs.Where(IsBigProcess);


            //local functions
            bool IsBigProcess(Process proc)
            {
                return proc.WorkingSet64 > 1000000000;
            }
        }






        public void Log(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }

        public void Popup(string message)
        {
            MessageBox.Show(message);
        }

        private async void callServiceButton_Click(object sender, RoutedEventArgs e)
        {

            var uri = new Uri("https://netflix.com/humans.txt");
            var client = new HttpClient();
            client.BaseAddress =uri;

            countdownTextBlock.Text = "Starting";
            var response = await client.GetAsync("");

            countdownTextBlock.Text = "Recieved First byte";
            var content = await response.Content.ReadAsStringAsync();

            readoutTextBlock.Text = content;

            FileStream fs = new FileStream("", FileMode.Open);
            StreamReader reader = new StreamReader(fs);
   

        }



        //Actions anf Funcs and Delegates

        //Function Pointers
    }
}
