using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module09.Models
{
    public class Widget
    {

        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Color { get; set; }



        public override string ToString()
        {
            return Name;
        }

    }
}
