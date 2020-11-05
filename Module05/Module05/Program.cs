using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module05.EntensionMethods;

namespace Module05
{

    //Creating Extension Method
    //1) Create a Static class (name is not importnat)
    //2) Create a static method
    //     a) with the name of the method you want
    //     b) taking in the class you want to extend as the first paramters
    //3) put the keyword 'this' in front of the first parameter



    class Program
    {
        static void Main(string[] args)
        {
            //Demo1();
            Demo2();
        }

        private static void Demo2()
        {

            Console.Write("Enter your email address: ");
            var address = Console.ReadLine();

            if (address.IsEmail())
            //if (StringUtillity.IsEmail(address))
            {
                Console.WriteLine("Thank you for your information");
            }
            else
            {
                Console.WriteLine("That is not an address");
            }



        }

        private static void Demo1()
        {
            var issues = GenerateIssues();
            foreach (var issue in issues)
            {
                Print(issue);
            }
        }

        private static void Print(Issue issue)
        {
            Console.WriteLine();
            Console.WriteLine(issue.Summarize()); //Polymorphism

            Console.WriteLine("-------------------------------------");
        }

        private static List<Issue> GenerateIssues()
        {
            return new List<Issue>
            {
                new Issue {Id=1, Description ="Print on fire", Status=IssueStatus.Open},
                new Issue {Id=2, Description ="Bad managers", Status=IssueStatus.Open},
                new Issue {Id=3, Description ="Bad tools", Status=IssueStatus.Open},
                new Issue {Id=4, Description ="Fractious colleagues", Status=IssueStatus.Open},
                new Issue {Id=5, Description ="Power outage", Status=IssueStatus.Open},
                new Issue {Id=6, Description ="IT Issues", Status=IssueStatus.Resolved},
                new SoftwareIssue {Id=7, Description ="Invoices won't print", Status=IssueStatus.Resolved, ApplicationName="BooksRUs", OS="Windows" },
                new SoftwareIssue {Id=8, Description ="Blue Screen", Status=IssueStatus.Open, ApplicationName="Windows", OS="Windows" },
                new SoftwareIssue {Id=9, Description ="Bug Swarm", Status=IssueStatus.Pending, ApplicationName="MurderHornet", OS="Linux" },

            };
        }
    }


    //String is sealed, so this is not allowed
    //class BetterString : String
    //{

    //}
}
