using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module04.Biz;

namespace Module04.Biz.Tests
{
    [TestClass]
    public class IssueTesting
    {
        [TestMethod]
        public void Cannot_change_a_resolved_status()
        {
            //Arrange
            Issue i1 = new Issue();
            i1.Status = IssueStatus.Resolved;

            //act
            try
            {
                i1.Status = IssueStatus.Pending;
                Assert.Fail("InvalidOperationException was not thrown");
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true); //This is a good place
            }


        }

        [TestMethod]
        public void Exception_is_not_thrown_when_setting_resolved_twice()
        {
            //Arrange
            Issue i1 = new Issue();
            i1.Status = IssueStatus.Resolved;

            //act

            i1.Status = IssueStatus.Resolved;

  

        }





    }
}
