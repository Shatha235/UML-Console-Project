using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace UML_Console_Project
{
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
