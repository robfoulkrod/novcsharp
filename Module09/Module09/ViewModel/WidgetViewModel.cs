using Module09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module09.ViewModel
{
    public class WidgetViewModel
    {
        public WidgetViewModel()
        {
            Widgets = new List<Widget> {
            
                new Widget{ Name="Sam", Height=30, Width=40, Color="yellow"},
                new Widget{ Name="Joe", Height=30, Width=40, Color="red"},
                new Widget{ Name="Bert", Height=30, Width=40, Color="orange"},
                new Widget{ Name="Alie", Height=30, Width=40, Color="green"},
                new Widget{ Name="Carl", Height=30, Width=40, Color="blue"},
                new Widget{ Name="Janice", Height=30, Width=40, Color="purple"},
            
            };

            Current = Widgets.First();



        }


        public List<Widget> Widgets { get; set; }

        public Widget Current { get; set; }


    }
}
