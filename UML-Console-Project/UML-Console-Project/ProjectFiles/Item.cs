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
    [Serializable]
    class Item
    {    
        public string ID;
        public string Description;
        public int Price;
        public int Quantity;

        public  Item(string ID ="", string Description ="",int price=0, int Quantity=0)
        { 
            this.ID=ID;
            this.Description=Description;
            this.Price=price;
            this.Quantity=Quantity;
        }
        public int GetQuantity()
        {
            return Quantity;
        }
        public void SetQuantity(int Quantity)
        {
            this.Quantity = Quantity;
        }

        

        public string GetID()
        { 
           return this.ID;
        }
       

        public override string ToString()
        {
            return " ID: "+this.ID+" Description: "+this.Description+" Price: "+this.Price+" Quantity: "+this.Quantity;
        }

        public void ViewItem()
        {
            Console.WriteLine(" ID:  " + this.ID + "  Description:  " + this.Description + "  Price:  " + this.Price + "  Quantity: " + this.Quantity);
        }

        public static Item initateItem(string ID,string Description,int Price,int Quantity)
        {
            Item it=new Item();
            it.ID = ID;
            it.Description = Description;
            it.Price = Price;
            it.Quantity = Quantity;
            return it;


        }

        
    }
}
