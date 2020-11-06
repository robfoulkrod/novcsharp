using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace RightSide
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

            if (!Directory.Exists(dirpath)) Directory.CreateDirectory(dirpath);
        }

        private byte[] key;
        private byte[] iv;

        private string path = Path.Combine(dirpath, "message.txt");


        private void GenerateSymetricKey(object sender, RoutedEventArgs e)
        {
            key = CreateKeyFromPassPhrse(passphraseText.Text);
            iv = CreateIV();

            Display(Convert.ToBase64String(key), "key");
            Display(Convert.ToBase64String(iv), "iv");
        }

        byte[] CreateKeyFromPassPhrse(string phrase)
        {
            //Generate 8 Bytes of random salt
            byte[] salt = new byte[8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);

            var rfc = new Rfc2898DeriveBytes(phrase, salt);
            return rfc.GetBytes(32);
        }

        byte[] CreateIV()
        {
            byte[] iv = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(iv);

            return iv;
        }

        private void EncryptPublicKey(object sender, RoutedEventArgs e)
        {
            var ivPath = Path.Combine(dirpath, "iv.txt");
            var keyPath = Path.Combine(dirpath, "key.txt");

            var xml = File.ReadAllText(Path.Combine(dirpath, "publickey.txt"));

            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xml);

            var data = rsa.Encrypt(key, true);
            File.WriteAllBytes(keyPath, data);
            DisplayFile(keyPath);

            data = rsa.Encrypt(iv, true);
            File.WriteAllBytes(ivPath, data);
            DisplayFile(ivPath);
        }

        private void EncryptKeyButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            var sha = new SHA512Managed();
            var data = Encoding.UTF8.GetBytes(messageTextbox.Text);

            var hash = sha.ComputeHash(data);

            Display(Convert.ToBase64String(hash));
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
