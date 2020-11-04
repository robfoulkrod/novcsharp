using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module04.Biz
{
    public interface IIssueRepository
    {

        Issue[] GetAllIssues();
        Issue GetById(int id);
        //and more
        void DeleteById(int id);

    }
}
