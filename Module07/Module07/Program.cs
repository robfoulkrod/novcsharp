using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace Module07
{
    class Program
    {
        static void Main(string[] args)
        {

            var ctx = new NWContext();

            ctx.Database.Log = (m) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(m);
                Console.ResetColor();
            };


            var beverages = from p in ctx.Products
                            where p.CategoryID == 1
                            orderby p.Price descending
                            select p;

            foreach (var b in beverages)
            {
                Console.WriteLine($"{b.ProductName} - {b.Price:c}");

            }


            Console.WriteLine("Lookup by key");
            var product = ctx.Products.Find(34);



            Console.WriteLine("About to edit a product");
            var name = "Sasquatch Ale";

            var ale = (from p in ctx.Products
                       where p.ProductName == name
                       select p).First();

            ale.Price = 17;


            var newProduct = new Product
            {
                ProductName = "Basic Coffee",
                CategoryID = 1,
                Price = 1,
                SupplierID = 3
            };


            ctx.Products.Add(newProduct);


            if (newProduct.IsAwesome)
            {

                ctx.SaveChanges();
            }



            Console.WriteLine("Call a stored procedure");
            var history = ctx.CustOrderHist("ALFKI");


        }
    }
}
