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
         private Order [] ListofoItem;
         private double TotalCost;
         public Order (string ID="",string CustomerName="",string ProviderName="",string Status="",Item [] ListofOItem=null,double TotalCost=0)
           {
            this.ID = ID;
            this.CustomerName=CustomerName;
            this.ProviderName = ProviderName;
            this.Status=Status;
            this.ListofoItem=ListofoItem;
            this.TotalCost=TotalCost;
            
           }
        public void Setall(string ID="",string CustomerName="",string ProviderName="",string Status="",Item [] ListofOItem=null,double TotalCost=0)
        {
            this.ID = ID;
            this.CustomerName=CustomerName;
            this.ProviderName = ProviderName;
            this.Status=Status;
            this.ListofoItem=ListofoItem;
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
        public void AddOrder(string ID , string CustomerName,string ProviderName ,string Status,Order [] ListofoItem,double TotalCost)
        {
            Order o = new Order(ID ,CustomerName,ProviderName,Status,ListofoItem,TotalCost);
            MySystem.OrderArr[MySystem.OrCounter++] = o;
            MySystem.Storefiles();
        }
        public void ViewAllOrders()
        { 
        
           Console.WriteLine("ID : " + ID + "Customer name :" + CustomerName + "Provider name: " + ProviderName + "Status : " +Status +"List of ordered item :" + ListofOItem + "Total Cost :" +TotalCost);
        }

        public string ChangeStatus(string sTO , string sFr)
        { 
           
            sTO = sFr;
           return sTO;
        }
        public Order GetItem(int t)
        {
            return (ListofoItem[t]);
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
