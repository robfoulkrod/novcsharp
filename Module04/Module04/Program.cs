using Module04.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module04
{
    class Program
    {
        static void Main(string[] args)
        {


            Demo2();

            //Demo1();
        }

        private static void Demo1()
        {
            string s1 = "up";

            string s2;
            s2 = s1;

            //s1 = "down";
            //for (int i = 0; i < 100; i++)
            //{
            //    s1 += "!";
            //}
            StringBuilder sb = new StringBuilder();
            sb.Append("down");
            for (int i = 0; i < 100; i++)
            {
                sb.Append("!");
            }
            s1 = sb.ToString();


            Console.WriteLine(s2);



            var i1 = new Issue
            {
                Id = 1,
                Description = "Printer on fire",
                Status = IssueStatus.Pending
            };

            Console.WriteLine(i1.Summarize()); ;
        }

        private static void Demo2()
        {

            List<int> wholeNumbers = new List<int>();
            wholeNumbers.Add(12);
            //wholeNumbers.Add(12.1);

            List<string> names = new List<string>();

            List<Issue> problems = GenerateIssues();

            //1)
            List<Issue> oddIssues = new List<Issue>();
            foreach (var issue in problems)
            {
                if(issue.Id % 2 == 1)
                {
                    oddIssues.Add(issue);

                }
            }

            //2) Now with LINQ

            var odddIssues = from p in problems
                             where p.Id % 2 == 1
                             orderby p.Id
                             select p;


            
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
            };
        }
    }
}
