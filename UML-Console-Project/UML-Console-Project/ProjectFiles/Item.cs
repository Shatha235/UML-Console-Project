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
    class Item
    {    
        private string ID;
        private string Description;
        private int price;
        private int Quantity;

        public void Item(string ID , string Description ,int price, int Quantity)
        { 
            this.ID=ID;
            this.Description=Description;
            this.price=price;
            this.Quantity=Quantity;
        }
        public string GetID()
        { 
           return this.ID;
        }

    }
}
