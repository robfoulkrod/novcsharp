using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Module06
{
    class Program
    {

        const string basePath = @"c:\class";


        static void Main(string[] args)
        {
            //Demo1();
            //Demo2();
            Demo3();


        }

        private static void Demo3()
        {
            var book = new Book()
            {
                Author = "Steve McConnell",
                Title = "Code Complete",
                PublishDate = DateTime.Parse("1/1/2004"),
                Pages = 885
            };

            var output = JsonConvert.SerializeObject(book);
            Console.WriteLine(output);

            var readBook = JsonConvert.DeserializeObject<Book>(output);

            Console.WriteLine($"Title: {readBook.Title}");
            Console.WriteLine($"Page: {readBook.Pages}");
            Console.WriteLine($"Author: {readBook.Author}");
            Console.WriteLine($"Pub: {readBook.PublishDate:d}");
        }

        private static void Demo2()
        {
            var book = new Book()
            {
                Author = "Steve McConnell",
                Title = "Code Complete",
                PublishDate = DateTime.Parse("1/1/2004"),
                Pages = 885
            };

            var fullPath = Path.Combine(basePath, "book.bin.txt");
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, book);
            }

            //open the text file if the windows default editor
            //System.Diagnostics.Process.Start(fullPath);


            using (var stream = new FileStream(fullPath, FileMode.Open))
            {

                var formatter = new BinaryFormatter();


                //C# Conversation - two ways to cast an object to another type
                var readBook = (Book)formatter.Deserialize(stream); //Fails with a exception
                var readBook2 = formatter.Deserialize(stream) as Book; //Fails by returning null

                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Page: {book.Pages}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Pub: {book.PublishDate:d}");
            }

        }

        private static void Demo1()
        {
            var fullPath = Path.Combine(basePath, "reasons.txt");

            string[] content = {
                "Works on my machine",
                "Is it turned on?",
                "Reboot",
                "Clear your cache",
                "Clear your cache with ctrl + f5",
                "It is working as designed",
                "Is there arror trapping?"
            };


            //FileStream stream = null;
            //StreamWriter writer =null;


            //try
            //{

            //    stream = new FileStream(fullPath, FileMode.Create);
            //    writer = new StreamWriter(stream);

            //    for (int i = 0; i < content.Length; i++)
            //    {
            //        writer.WriteLine($"{i + 1}\t{content[i]}");
            //    }

            //}
            //finally
            //{

            //    if (writer != null) writer.Close();
            //    if (stream != null) stream.Close();

            //}

            using (var stream = new FileStream(fullPath, FileMode.Create))
            using (var writer = new StreamWriter(stream))
            {

                for (int i = 0; i < content.Length; i++)
                {
                    writer.WriteLine($"{i + 1}\t{content[i]}");
                }

            }

            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();

            //write is over
            using (var stream = new FileStream(fullPath, FileMode.Open))
            using (var reader = new StreamReader(stream))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var split = line.Split('\t');
                    if (split.Length > 1)
                    {
                        Console.WriteLine(split[1]);
                    }
                }



            }
        }
    }

    [Serializable]
    class Book
    {
        private int pages;

        public int Pages
        {
            get { return pages; }
            set { pages = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private DateTime publishDate;

        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }



    }


}
