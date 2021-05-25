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
         private Item [] ListfoItem;
         private double TotalCost;
         public Order (string ID="",string CustomerName="",string ProviderName="",string Status="",Item [] ListfoItem = null,double TotalCost=0)
           {
            this.ID = ID;
            this.CustomerName=CustomerName;
            this.ProviderName = ProviderName;
            this.Status=Status;
            this.ListfoItem = ListfoItem;
            this.TotalCost=TotalCost;
            
           }
        public void Setall(string ID="",string CustomerName="",string ProviderName="",string Status="",Item [] ListfoItem = null,double TotalCost=0)
        {
            this.ID = ID;
            this.CustomerName=CustomerName;
            this.ProviderName = ProviderName;
            this.Status=Status;
            this.ListfoItem = ListfoItem;
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
        public void ViewAllOrders()
        { 
        
           Console.WriteLine("ID : " + ID + "Customer name :" + CustomerName + "Provider name: " + ProviderName + "Status : " +Status +"List of ordered item :" + ListfoItem + "Total Cost :" +TotalCost);
        }

        static public string ChangeStatus(string sTO , string sFr)
        { 
           
            sTO = sFr;
           return sTO;
        }
        public Item GetItem(int t)
        {
            return (ListfoItem[t]);
        }
      
        static public void InaitialData()
        {
            MySystem.OrderArr = new Order[100];
            MySystem.Storefiles();
        }

        static public void AddItem(Item item)
        {

        }
        
        


    }
}
