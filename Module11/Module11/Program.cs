using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xl = Microsoft.Office.Interop.Excel;

namespace Module11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo1();
            Demo2();



        }

        private static void Demo2()
        {
            var app = new xl.Application();
            var book = app.Workbooks.Add();
            var sheet = book.Worksheets.Add();
            sheet.Range["a1"].Value = "Book 1";
            sheet.Range["b1"].Value = 25.8;
            sheet.Range["a2"].Value = "Book 2";
            sheet.Range["b2"].Value = 13.7;

            book.SaveAs(@"c:\class\books.xlsx");
            Console.WriteLine("All done");

            app.Quit();

        }

        private static void Demo1()
        {
            dynamic something;
            if (DateTime.Now.Millisecond % 2 == 0)
            {
                something = "A simple list of characters";
            }
            else
            {
                something = new string[] { "happy", "sneezy", "doc", "grumpy", "angry", "annoyed", "bashful" };
            }

            Console.WriteLine(something.Length);
        }
    }



    class ExcelManager : IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ExcelManager()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
