using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    partial class Product
    {
        public bool IsAwesome
        {
            get
            {
                return this.Price < 10;
            }
        }
    }
}
