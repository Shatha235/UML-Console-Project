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
    class Order
    {    
         private string ID;
         private string CustomerName;
         private string ProviderName;
         private string Status;
        private Item [] ListOfItems=new Item[100];
        public int ItemCounter = 0;
        private double TotalCost;
         public Order (string ID="",string CustomerName="",string ProviderName="",string Status="",Item [] ListOfItems = null,double TotalCost=0.0)
           {
            this.ID = ID;
            this.CustomerName=CustomerName;
            this.ProviderName = ProviderName;
            this.Status=Status;
            this.ListOfItems = new Item[100];
            for (int i =0; i<ItemCounter;i++)
            this.ListOfItems[i] = ListOfItems[i];

            this.TotalCost=TotalCost;
            
           }


        public Order(Order O)
        {
            this.ID = O.ID;
            this.CustomerName = O.CustomerName;
            this.ProviderName = O.ProviderName;
            this.Status = O.Status;
            this.ListOfItems = new Item[100];
            for (int i = 0; i < ItemCounter; i++)
                this.ListOfItems[i] = O.ListOfItems[i];
            this.TotalCost = O.TotalCost;

        }
        public void Setall(string ID="",string CustomerName="",string ProviderName="",string Status="",Item [] ListOfItems = null,double TotalCost=0.0)
        {
            this.ID = ID;
            this.CustomerName=CustomerName;
            this.ProviderName = ProviderName;
            this.Status=Status;
            this.ListOfItems = new Item[100];
            for (int i = 0; i < ItemCounter; i++)
                this.ListOfItems[i] = ListOfItems[i];
            this.TotalCost=TotalCost;
        }

        public void SetOrderInfo(string ID,string CustomerName,string ProviderName,string Status,double TotalCost)
        {
            this.ID = ID;
            this.CustomerName=CustomerName;
            this.ProviderName = ProviderName;
            this.Status=Status;
           
            this.TotalCost=TotalCost;
        }
        public string GetID()
        {
            return ID;
        }
        public double GetTotalCost()
        { 
            return TotalCost;
        }
        public string GetCustomerName()
        {
            return CustomerName;
        }
        public void SetCustomerName(string CustomerName)
        {
             this.CustomerName=CustomerName;
        }
        public string GetProviderName()
        {
            return ProviderName;
        }
        public string GetStatus()
        {
            return Status;
        }
        public void SetStatus(string Status) 
        {
           this.Status=Status;
        }
        public void AddOrder(string ID , string CustomerName,string ProviderName ,string Status,Item [] ListofoItem,double TotalCost)
        {
            Order o = new Order(ID ,CustomerName,ProviderName,Status,ListofoItem,TotalCost);
            MySystem.OrderArr[MySystem.OrCounter++] = o;
            MySystem.Storefiles();
        }
        public void View()
        { 
        
           Console.WriteLine("ID : " + ID + "     Customer name :" + CustomerName + "     Provider name: " + ProviderName + "     Status : " + Status  + "     Total Cost :" + TotalCost);
            Console.WriteLine("\nList of ordered item:  \n");
            for(int i=0;i<ItemCounter;i++)
            {
                ListOfItems[i].ViewItem();
            }
        }

      
        public Item GetItem(int t)
        {
            return (ListOfItems[t]);
        }
      
        static public void InaitialData()
        {
            MySystem.OrderArr = new Order[100];


            MySystem.Storefiles();
        }

         public void AddItem(Item item)
        {
            ListOfItems[ItemCounter++] = new Item(item);
        }
        
        


    }
}
