using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Console_Project;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UML_Console_Project.ProjectFiles
{
    class Order
    {
        static public void InaitialData()
        {
            MySystem.OrderArr = new Order[100];
            MySystem.Storefiles();
        }
    }
}
