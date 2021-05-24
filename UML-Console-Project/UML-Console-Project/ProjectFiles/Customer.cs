using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UML_Console_Project;



namespace UML_Console_Project.ProjectFiles
{

    class Customer : User
    {
        
        private double CashCredit;
        Provider provider;


        public Customer(string Name, string Password, double CashCredit)
        {
            this.Name = Name;
            this.Password = Password;
            this.CashCredit = CashCredit;

        }


        void Setall(string Name,string Password,double CashCredit)
        {
            this.Name = Name;
            this.Password = Password;
            this.CashCredit = CashCredit;
        }
        public string GetUsername()
        {
            return Name;
        }

        public string GetPassword()
        {
            return Password;
        }
        public string GetCashCredit()
        { 
            return Convert.ToString (CashCredit) + " JD";
        }

        static public void InaitialData()
        {

            //warning : only call it when you wanna reset provider data

            MySystem.CustomerArr = new Customer[100]; // to reset the array before initiating <jebril>
            Customer c0 = new Customer("ali", "11", 100);
            MySystem.CustomerArr[0] = c0;

            Customer c1 = new Customer("omar", "22", 75);
            MySystem.CustomerArr[1] = c1;

            Customer c2 = new Customer("maha", "33", 50);
            MySystem.CustomerArr[2] = c2;

            Customer c3 = new Customer("anas", "44", 80);
            MySystem.CustomerArr[3] = c3;

            Customer c4 = new Customer("reem", "55", 120);
            MySystem.CustomerArr[4] = c4;
           
            MySystem.Storefiles();
        }



        //I added this function here to organize the code a little more,However,I implemented it since it  belongs to the system originally
        //<jebril>

        public void Options()
        {
            int choice;
            Console.WriteLine("[1] Place new order");
            Console.WriteLine("[2] View my orders");
            Console.WriteLine("[3] Pay for order");
            Console.WriteLine("[4] Post a review for a provider");
            Console.WriteLine("[5] Logut\n");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if(choice ==1)
            {
                Console.Clear();
                PlaceNewOrder();
            }

            else if (choice == 2)
            {
                Console.Clear();
                VeiwMyOrders();
            }

            else if (choice == 3)
            {
                Console.Clear();
                PayForOrder();
            }

            else if (choice == 4)
            {
                Console.Clear();
                PostAReview();
            }

            else if (choice == 5)
            {
                Console.Clear();
                MySystem.Logout();
            }

            else 
            {
                Sh.Msg("You entered a wrong choice,\nplease enter a valid choice from 1-5 to continue...");
                Options();
            }
        }
        public void Read_loc_Cat(string Location,string Category)
        { 
            MySystem.ProviderArr=new Provider[100] ;
            MySystem.Loadfiles();
            for (int i=0; i <MySystem.PCounter;i++)
            { 
                
               if(Location== MySystem.ProviderArr[i].GetLocation() && Category==MySystem.ProviderArr[i].GetCategory())
                    Console.WriteLine(MySystem.ProviderArr[i]);
              
             }
        }
        
        public void ReadItem (string name)
        {  
            Item [] ItemArr=new Item[100];
            MySystem.ProviderArr=new Provider[100] ;
            MySystem.Loadfiles();
            for (int i=0; i <MySystem.PCounter;i++)
            { 
               if (MySystem.ProviderArr[i].GetName()==name)
                    showItem();
             }
        }
        public void showItem()
        { 
            Item [] ItemArr=new Item[100];
            MySystem.ProviderArr=new Provider[100] ;
            MySystem.Loadfiles();
            for (int i=0; i <MySystem.PCounter;i++)
            { 
               ItemArr[i]=MySystem.ProviderArr[i].GetListOfItems();
            }
            for (int c=0; c<ItemArr.Length;c++)
            { 
                Console.WriteLine(ItemArr[c]);
            }
        }
       /* public double calculateTotalCost(string name,string ID,int Quantity) //This function is temporery until we know ID offer
        { 
                // ex : l1 : 4
                //  quntity updated ,  price * Quantity=4*4=16 jd 
            // Delivery cost= delivery rate*the cost of the ordered items.( price * Quantity)
            // Total cost = price * Quantity + Delivery cost  .... cashcredit update
            double deliveryRate;
            Item [] item = new Item [100];
            MySystem.ProviderArr=new Provider[100];
            MySystem.Loadfiles();
            for (int i=0; i < MySystem.PCounter; i++ )
            { if (MySystem.ProviderArr[i].GetName==name)
                    deliveryRate=MySystem.ProviderArr[i].CalculateDeliveryRate();  
            }
            for (int t=0 ; t < MySystem.PCounter;t++ )
            {

            }
        }*/

                

        public void PlaceNewOrder()
        {

            Console.WriteLine("Enter which of this it is current location (Area1 or Area2 or Area3 ):");
            string Location = Console.ReadLine();
            Console.WriteLine("Enter  the category of the provider please: ");
            string Category = Console.ReadLine();
            Read_loc_Cat(Location,Category);
            Console.WriteLine("Enter the provider name please: ");
            string NameP = Console.ReadLine();
            ReadItem(NameP);
            Console.WriteLine("Enter ID of the item please: ");
            string IdItem = Console.ReadLine();
            Console.WriteLine("Enter the quantity that you want:  ");
            int quantityItem =Convert.ToInt32( Console.ReadLine());
            // he can enter the IDs of the offers he wants to buy
            calculateTotalCost(NameP,IdItem,quantityItem);


        }


        public void VeiwMyOrders()
        {
            //testing
            Console.WriteLine("VeiwMyOrders");
        }

        public void PayForOrder()
        {
            //testing
            Console.WriteLine("PayForOrder");
        }

        public void PostAReview()
        {
            //testing
            Console.WriteLine("PostAReview");
        }

        public void setProvider(Provider p)
        {
            provider = p;
        }


    }
}