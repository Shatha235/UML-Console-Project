//sh class : Jebril Mejdalawi


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Threading;

namespace UML_Console_Project
{
    class Sh
    {
        public static void Msg(string s)
        {
            Console.Beep(500, 750);
            Console.WriteLine("\n***Warning message***\n\n"+"["+s+"]\n\n**********************************************\n\n");
            Console.WriteLine("this message will disappear after 5 seconds and you will be able to enter the data again");
            Thread.Sleep(5000);
            Console.Clear();
            
        }
    }
}
