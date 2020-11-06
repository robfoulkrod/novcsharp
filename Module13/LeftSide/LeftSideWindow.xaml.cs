using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Windows;

namespace LeftSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string dirpath = "c:\\crypto";

        public MainWindow()
        {
            InitializeComponent();
        }


        private byte[] key;
        private byte[] iv;

        private string path = Path.Combine(dirpath, "message.txt");



        //Create Public private Key
        //Store Public for Everyone
        //Store private for me
        private void GeneratePublicPrivateKey(object sender, RoutedEventArgs e)
        {

            //1) Key Container
            //2) Algo for pub/pri
            var keyPath = Path.Combine(dirpath, "publickey.txt");

            var csp = new CspParameters(); // Store and retrieve key
            csp.KeyContainerName = "demoKeys";

            //Generating public private key
            var rsa = new RSACryptoServiceProvider(csp);
            rsa.PersistKeyInCsp = true;

            var xml = rsa.ToXmlString(includePrivateParameters: false);


            File.WriteAllText(keyPath, xml);
            DisplayFile(keyPath);

        }

        private void DecryptSymetricKey(object sender, RoutedEventArgs e)
        {
            var ivPath = Path.Combine(dirpath, "iv.txt");
            var keyPath = Path.Combine(dirpath, "key.txt");
            var csp = new CspParameters();
            csp.KeyContainerName = "demoKeys";

            var rsa = new RSACryptoServiceProvider(csp);

            var data = File.ReadAllBytes(keyPath);
            key = rsa.Decrypt(data, true);

            data = File.ReadAllBytes(ivPath);
            iv = rsa.Decrypt(data, true);


            Display(Convert.ToBase64String(key), "key");
            Display(Convert.ToBase64String(iv), "iv");


        }


        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            //1) location stream
            var fs = new FileStream(path, FileMode.Open);

            //2) chose algo
            var algo = Aes.Create();

            //3) create encryptor
            var decryptor = algo.CreateDecryptor(key, iv);


            //4) create crypto Stream
            var cryptoStream = new CryptoStream(fs, decryptor, CryptoStreamMode.Read);

            //5) create writer
            var reader = new StreamReader(cryptoStream);

            //6) Write to file
            messageTextbox.Text = reader.ReadToEnd();

            reader.Close();
        }

        private void WriteButton_Click(object sender, RoutedEventArgs e)
        {
            //1) location stream
            var fs = new FileStream(path, FileMode.Create);

            //2) chose algo
            var algo = Aes.Create();

            //3) create encryptor
            var encryptor = algo.CreateEncryptor(key, iv);

            //4) create crypto Stream
            var cryptoStream = new CryptoStream(fs, encryptor, CryptoStreamMode.Write);

            //5) create writer
            var writer = new StreamWriter(cryptoStream);

            //6) Write to file
            writer.Write(messageTextbox.Text);

            writer.Close();
            DisplayFile(path);
        }


        void Display(string message, string title = "")
        {
            Debug.WriteLine(title);
            Debug.WriteLine(message);
            Debug.WriteLine("");

            MessageBox.Show(message, title);
        }

        void DisplayFile(string path)
        {
            Debug.WriteLine(path);
            Debug.WriteLine(File.ReadAllText(path));
            Debug.WriteLine("");


        }


    }
}
