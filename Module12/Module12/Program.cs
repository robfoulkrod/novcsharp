using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Module12
{
    class Program
    {
        static void Main(string[] args)
        {

            var books = Book.GetBooks();

            //PrintBooks(books);


            PrintList(books);

        }


        private static void PrintList<T>(List<T> items)
        {
            //2 ways to get type
            //1) obj.GetType()
            //var obj = items.First();
            //var t = obj.GetType();
            //2) typeof function
            var type = typeof(T);
            //using IEnumerable<PropertyInfo> instead of array of PropertyInfo for flexibility
            IEnumerable<PropertyInfo> allProperties = type.GetProperties();


            var propsToPrint = from p in allProperties
                               where !p.GetCustomAttributes<HideAttribute>().Any()
                               select p;


            PrintHeaders(propsToPrint);
            PrintContent(propsToPrint, items);

        }
        private static void PrintHeaders(IEnumerable<PropertyInfo> allProperties)
        {
            foreach (var prop in allProperties)
            {
                Console.Write($"{prop.Name}\t");
            }
            Console.WriteLine();
        }


        private static void PrintContent<T>(IEnumerable<PropertyInfo> allProperties, List<T> items)
        {
            foreach (var item in items)
            {
                foreach (var prop in allProperties)
                {
                    Console.Write($"{prop.GetValue(item)}\t");
                }
                Console.WriteLine();
            }
        }

        [Obsolete("Use the new PrintList<T> method", error:true)]
        private static void PrintBooks(List<Book> books)
        {
            Console.WriteLine("Title\tAuthor\tPages\tPublished");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}\t{book.Author}\t{book.Pages}\t{book.Published}");
            }
        }
    }


    class Book
    {
        public String Title { get; set; }
        [Hide]
        public string Author { get; set; }
        public int Pages { get; set; }

        [Hide]
        public DateTime Published { get; set; }


        public static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book{Title="Dracula", Author="Bram Stoker", Pages=400, Published=DateTime.Today.AddDays(-6000)},
                new Book{Title="Green Eggs and Ham", Author="Dr. Seuss ", Pages=400, Published=DateTime.Today.AddDays(-6000)},
                new Book{Title="Onefish two fis red fish", Author="Dr. Seuss ", Pages=400, Published=DateTime.Today.AddDays(-6000)},
                new Book{Title="Outliers", Author="Malcolm Gladwell", Pages=400, Published=DateTime.Today.AddDays(-6000)},
                new Book{Title="A Game of Thrones", Author="George RR Martin", Pages=400, Published=DateTime.Today.AddDays(-6000)},
            };
        }


    }

    [AttributeUsage(AttributeTargets.Property)]
    class HideAttribute : Attribute
    {

    }

}
