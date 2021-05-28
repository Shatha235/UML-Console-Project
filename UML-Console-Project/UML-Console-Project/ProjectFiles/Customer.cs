using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UML_Console_Project;



namespace UML_Console_Project.ProjectFiles
{
    [Serializable]
    class Customer : User
    {
        private double CashCredit;
 
        public Customer(string Name="", string Password="", double CashCredit=0.0)
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
        public double GetCashCredit()
        { 
            return CashCredit;
        }

        public void View()
        {
            
            Console.WriteLine("Name: " + Name + "    Password " + Password+ "    CashCredit: " + CashCredit);
        }

        public override string ToString()
        {
            
            return "Name: " + Name + "    Password " + Password + "    CashCredit: " + CashCredit;
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
            MySystem.CCounter = 5;

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

        //1 fixed it's name was : Read_loc_Cat
        public void ViewProviders(string Location,string Category)
        { 
            
            for (int i=0; i <MySystem.PCounter;i++)
            { 
                
               if (MySystem.ProviderArr[i].GetLocation() == Location && MySystem.ProviderArr[i].GetCategory() == Category)
                    Console.WriteLine(MySystem.ProviderArr[i].GetName());
              
             }
        }
        public double CachCrediteUpdate(double totalCost)
        { 
            return this.CashCredit-totalCost;
        }
        public int IncomeUpdate(int income ,double totalCost)
        { 
            income= income + (int) totalCost; 
            return income;
        }
        
       
     

        //2

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

                
        //5
        public void PlaceNewOrder()
        {

            Console.WriteLine("Enter your current location (Area1 or Area2 or Area3 ):");
            string Location = Console.ReadLine();
            Console.WriteLine("Enter  the category of the provider please: ");
            string Category = Console.ReadLine();
            ViewProviders(Location,Category);
            Console.WriteLine("Enter the provider name please: ");
            string NameP = Console.ReadLine();
            int j=0;
            Item[] I = new Item[100];

               I= MySystem.GetItemsByProvider(ref j , NameP);

            for (int i = 0; i < j; i++)
            {
                I[i].ViewItem();
            }
            //GetOffersByProvider 

            int choice;
            bool f = true;

            do
            {
                Console.Clear();
                Console.WriteLine("[1] Add an item to the order");
                Console.WriteLine("[2] Add an offer to the order");
                Console.WriteLine("[3] Finished Adding to the order");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("\n\nPlaase Enter the ID and the Quantity of the item you want to add");
                    Console.Write("ID: ");
                    string ID = Console.ReadLine();
                    Console.Write("Quantity: ");
                    int Quantity = Convert.ToInt32(Console.ReadLine());
                    //function in items class , takes ID and Quantity, to decrease quantity and add item to list of items in order object
                    //cost counter
                    for (int l=0;l<j;l++)
                    {

                    }
                }

                else if (choice == 2)
                {


                }
                else if (choice == 3)
                    f = false;
               

                
            } while (f==true);

            Console.WriteLine("Enter the ID of the item please: ");
            string IdItem = Console.ReadLine();
            Console.WriteLine("Enter the quantity that you want:  ");
            int quantityItem =Convert.ToInt32( Console.ReadLine());

            Console.WriteLine("Enter the quantity that you want:  ");
            int OfferID = Convert.ToInt32(Console.ReadLine());

            // he can enter the IDs of the offers he wants to buy
            //calculateTotalCost(NameP,IdItem,quantityItem);


        }


        public void VeiwMyOrders()
        {
            //testing
            //Console.WriteLine("VeiwMyOrders");
            Order [] order =new Order [100];
            int j=0;
            string Cname = this.GetUsername();
            order = MySystem.GetOrdersByCustomer(ref j,Cname);
            for (int i=0 ; i<j;i++)
                order[i].ViewAllOrders();
        }

        public void PayForOrder()
        {
            //testing
            //Console.WriteLine("PayForOrder");
            
            int i =0;
            for (;i<MySystem.OrCounter;i++)
            { 
                if (MySystem.OrderArr[i].GetStatus()=="not paid")
                    MySystem.OrderArr[i].ViewAllOrders();
            }
            Console.WriteLine("Enter Order ID please: ");
            string ID = Console.ReadLine();
            int c=0;
            for (; c<MySystem.OfCounter; c++)
            { 
               if(MySystem.OrderArr[c].GetID()==ID)
                { 
                    MySystem.OrderArr[c].SetStatus("paid");
                }

            }
            double TotalCost = MySystem.OrderArr[c].GetTotalCost();
            CachCrediteUpdate(TotalCost);
            string Pname = MySystem.OrderArr[c].GetProviderName();
            for (int r=0 ; r<MySystem.PCounter; r++)
            { 
                if (MySystem.ProviderArr[r].GetName()==Pname)
                   { 
                      int INC= MySystem.ProviderArr[r].GetIncome() ;
                      IncomeUpdate(INC,TotalCost);
                   }
            }
            MySystem.Storefiles();
        }

        public void PostAReview()
        {
            int i =0;
            for (;i<MySystem.OrCounter;i++)
            { 
                if (MySystem.OrderArr[i].GetStatus()=="delivered")
                    MySystem.OrderArr[i].ViewAllOrders();
            }
            Console.WriteLine("Enter Order ID please: ");
            string ID = Console.ReadLine();
            Console.WriteLine("Enter the Review value please: ");
            double review = Convert.ToDouble(Console.ReadLine());
            int j =0;
            for (; j<MySystem.OrCounter;j++)
            { 
                if (MySystem.OrderArr[j].GetID()==ID)
                { 
                      string name=MySystem.OrderArr[j].GetProviderName();
                }

            }
            int t=0;
            for (; t<MySystem.PCounter;t++)
            { 
                if (MySystem.ProviderArr[t].GetName()==Name)
                    MySystem.ProviderArr[t].SetNewReview(review);
            }
            MySystem.Storefiles();
        }

        


    }
}