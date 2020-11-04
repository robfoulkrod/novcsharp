using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module04.Biz;

namespace Module04.Biz.Tests.Fakes
{






    internal class FakeIssueManager : IIssueRepository
    {

        private List<Issue> issues = GenerateIssues();


        public void DeleteById(int id)
        {
            var issue = GetById(id);
            issues.Remove(issue);
        }

        public Issue[] GetAllIssues()
        {
            return issues.ToArray();
        }

        public Issue GetById(int id)
        {
            return issues.First(issues => issues.Id == id);
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
