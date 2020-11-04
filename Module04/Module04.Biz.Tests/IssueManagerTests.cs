using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module04.Biz;

namespace Module04.Biz.Tests
{
    [TestClass]
    public class IssueManagerTests
    {

        [TestMethod]
        public void Manager_will_delete_issue()
        {

            var repo = new Fakes.FakeIssueManager();

            var manager = new IssueManager(repo);
            var issue = repo.GetById(1);
            issue.Status = IssueStatus.Resolved;

            manager.DeleteIssue(issue);

            var allIssues = repo.GetAllIssues();
            var deleted = !allIssues.Contains(issue);

            Assert.IsTrue(deleted);
        }



        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Manager_Will_not_delete_pending_issues()
        {


            var manager = new IssueManager(null);
            Issue i1 = new Issue();
            i1.Status = IssueStatus.Pending;

            manager.DeleteIssue(i1);
            Assert.Fail("Manager allowed the deleting of a pending issue");



        }

    }
}
