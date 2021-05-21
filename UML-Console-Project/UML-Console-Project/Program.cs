using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UML_Console_Project.ProjectFiles;

namespace UML_Console_Project
{
    class MySystem
    {
        static public Provider[] p = new Provider[100];

        static public void storefiles() { }
        static public void loadfiles() { }



        public void Login()
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //"how to clear console + freeze "
            Console.WriteLine("hi");
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("hi, again");
            Thread.Sleep(5000);
        }
    }
}
