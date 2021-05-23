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
        public string ID;
        public string Description;
        public int Price;
        public int Quantity;

        public  Item(string ID , string Description ,int price, int Quantity)
        { 
            this.ID=ID;
            this.Description=Description;
            this.Price=price;
            this.Quantity=Quantity;
        }

        public Item()
        {
            this.ID = "";
            this.Description = "";
            this.Price = 0;
            this.Quantity = 0;
        }

        public string GetID()
        { 
           return this.ID;
        }

        public static Item AddItem(string ID,string Description,int Price,int Quantity)
        {
            Item it=new Item();
            it.ID = ID;
            it.Description = Description;
            it.Price = Price;
            it.Quantity = Quantity;
            return it;


        }

        public void printItem()
        { 
            Console.WriteLine("ID is:" + this.ID);
            Console.WriteLine("The Description is:" + this.Description);
            Console.WriteLine("The Price is:" + this.Price);
            Console.WriteLine("The Quantity is:" + this.Quantity);
        }
    }
}
