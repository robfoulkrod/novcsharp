using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module01.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            int year = 2020;
            int littleNumber = 50;

            int answer = year / littleNumber;
            var answer2 = year / littleNumber;


            string message;
            message = "Hello from C# in the year " + year;




            //The dark place
            Console.WriteLine(message);

            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();



            //Strong Typing
            short peopleCount = 300; //short +- 32k
            int biggerCount = short.MaxValue;
            biggerCount++;

            checked
            {

                //biggerCount = peopleCount;
                peopleCount = (short)biggerCount;
            }


            string userAge = "56.000";
            int age = Convert.ToInt32(userAge);
            int age2 = int.Parse(userAge);

        }
    }

}
