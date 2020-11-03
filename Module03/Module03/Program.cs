using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;

namespace Module03
{
    class Program
    {

        static ArrayList fileNames = new ArrayList();


        static void Main(string[] args)
        {

            //Demo1();
            //Demo2();
            //Demo3();
            Demo4();
        }

        private static void Demo4()
        {
            //Event
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"c:\temp";
            fsw.Created += FileNotification;
            fsw.Created += AddToLog;

            fsw.Deleted += FileNotification;

            fsw.EnableRaisingEvents = true;


            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();

            //This is technically bad, no multithreading protection
            Console.WriteLine("These are the names of the files that have been added");
            foreach(string name in fileNames)
            {
                Console.WriteLine(name);
            }


        }


        static void AddToLog(object sender, FileSystemEventArgs e)
        {
            fileNames.Add(e.Name);
        }


        private static void FileNotification(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("Processing " + e.FullPath);
            //System.Threading.Thread.Sleep(5000);
            Console.WriteLine($"Looks like {e.Name} was {e.ChangeType} ?");
        }

        private static void Demo3()
        {

            string[] names = new string[3];
            names[0] = "Dave";
            names[1] = "Gavan";
            names[2] = "Marcy";

            var n = names[0];


            Array.Resize(ref names, 4);
            //---------------------
            ArrayList al = new ArrayList();
            al.Add("Martin");
            al.Add("Patrick");
            al.Add("Scott");
            al.Add("Thomas");
            // time passes

            al.Add("Yves");

            var name = al[0];


        }

        private static void Demo2()
        {

            var l1 = new Location();
            
            l1.Building = "123";
            l1.Floor = 1;
            l1.Room = 12;

            //Initializer
            var l2 = new Location { Building = "a1", Floor = 1, Room = 2 };
            Console.WriteLine(l1.Display());
            Console.WriteLine(l2.Display());

        }

        enum Status
        {
            Open, //0
            Closed, //1
            Review = 99 //99
        }


        struct Location
        {

            public Location(string building, int floor, int room)
            {

                //In structs (and structs only)
                // you must assign a value for EVERY field
                this.building = building;
                this.Floor = floor;
                this.room = room;
                this.createTimeStamp = DateTime.UtcNow;
            }


            //Fields - data, state
            private string building;
            //private int floor;
            private int room;
            private DateTime createTimeStamp;


            //Expose a readonly CreateTimeStamp
            public DateTime CreateTimeStamp
            {
                get
                {
                    return createTimeStamp;
                }
            }


            public string Building
            {
                get { return building; }
                set { building = value; }
            }

            //Automatic Property
            public int Floor { get; set; } //Built the field AND the property in 1 line

            public int Room
            {
                get
                {
                    return room;
                }
                set //l1.Room = 25;
                {
                    if(value <= 0 || value >= 101)
                    {
                        //This is NOT a valid Room number in our world
                        throw new ArgumentException("All room number are between 1 and 100");
                    }

                    this.room = value;
                }
            }

            public string Display()
            {
                return $"#{Building} - Floor {Floor}, Room {Room}";
            }

        }
        //Record - Readonly Struct (C# 9.0 pending later this month??)


        private static void Demo1()
        {
            Status s = (Status)99;

            if (s == Status.Open)
            {
                Console.WriteLine("Current Status is open");
            }
            else
            {
                Console.WriteLine("Current Status is closed.");
            }

            Console.WriteLine("Status as a string: " + s);

        }
    }
}
