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

    class Offer 
    {
        string ID;
        string ProviderName;
        string ItemID;
        int Quantity;
        int Price;

        public Offer(string ID="",string ProviderName="",string ItemID="",int Quantity=0,int Price=0)
        {
            this.ID = ID;
            this.ProviderName = ProviderName;
            this.ItemID = ItemID;
            this.Quantity = Quantity;
            this.Price = Price;
        }

        public void Setall(string ID = "", string ProviderName = "", string ItemID = "", int Quantity = 0, int Price = 0)
        {
            this.ID = ID;
            this.ProviderName = ProviderName;
            this.ItemID = ItemID;
            this.Quantity = Quantity;
            this.Price = Price;
        }
        public string GetProviderName()
        {
            return ProviderName;
        }

        public double GetCost()
        {
            return Price;
        }

        public string GetID()
        {
            return ID;
        }
        public void View()
        {
            //try to also get the name of the item and print it
            Console.WriteLine("ID: " + ID + "    Provider name: " + ProviderName + "    ItemID: " + ItemID + "  Quantity: " + Quantity + "  Price: " + Price);
        }

        public override string ToString()
        {
            //try to also get the name of the item and print it
            return("ID: " + ID + "    Provider name: " + ProviderName + "    ItemID: " + ItemID + "  Quantity: " + Quantity + "  Price: " + Price);
        }

        static public void AddOffer(string ID , string ProviderName , string ItemID , int Quantity, int Price)
        {
            Offer f = new Offer(ID,ProviderName,ItemID,Quantity,Price);
            MySystem.OfferArr[MySystem.OfCounter++] = f;
            MySystem.Storefiles();
           
        }

        static public void InaitialData()
        {
            MySystem.OfferArr = new Offer[100];
            MySystem.Storefiles();
        }


    }
}
