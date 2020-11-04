using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module04.Biz
{
    public class Issue : IComparable
    {

        //Computer Generated Constructor looks like this
        //public Issue()
        //{
        //    Id = default(int); //0
        //    Description = default(string); //null
        //    Status = default(IssueStatus); //0
        //}


        private static int nextId = 1;
        private IssueStatus status;

        public Issue()
        {
            Id = nextId++;  //Don't do this.  It is not safe. Demo code only.
            Create = DateTime.UtcNow;
        }


        public Issue(string description, IssueStatus status) : this()
        {

            Description = description;
            Status = status;
        }


        //prop<tab><tab>
        public int Id { get; set; }
        public string Description { get; set; }

        public IssueStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                if (this.status == IssueStatus.Resolved && value != IssueStatus.Resolved) throw new InvalidOperationException("Cannot change a Resolved status");
                status = value;
            }
        }

        public DateTime Create { get; set; }

        public int CompareTo(object obj)
        {
            var that = (Issue)obj;
            return this.Id - that.Id;
        }

        public string Summarize()
        {
            return $"ID: {Id}\n" +
                $"Description: {Description}\n" +
                $"Status: {Status}\n";
        }


    }
}
