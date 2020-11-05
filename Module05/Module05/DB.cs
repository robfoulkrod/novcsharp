using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module05
{
    public abstract class DB
    {

        public abstract void SetName(string name);
        public abstract string Name { get; }


        public void DoWork()
        {
            Console.WriteLine($"{Name} is working");

        }


    }

    public class SqlDb : DB
    {

        private string name;

        public override string Name
        {
            get
            {
                return name;
            }
        }

        public override void SetName(string name)
        {
            this.name = name;
        }
    }

}
