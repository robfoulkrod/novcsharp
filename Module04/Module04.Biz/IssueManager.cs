using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module04.Biz
{
    public class IssueManager
    {
        public IIssueRepository Repo { get; }

        public IssueManager(IIssueRepository repo)
        {
            Repo = repo;
        }



        public void DeleteIssue(Issue issue)
        {
            if (issue.Status == IssueStatus.Pending) throw new InvalidOperationException("CAnnot delete a pending Issue");

            Repo.DeleteById(issue.Id);

        }

    }
}
