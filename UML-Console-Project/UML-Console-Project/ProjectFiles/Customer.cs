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
    class Customer 
    {
        private string Name;
        private string Password;
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
                Console.Clear();
                Options();
            }

            else if (choice == 2)
            {
                Console.Clear();
                VeiwMyOrders();
                Console.Write("If you finished reading, please press Enter : ");
                string s = Console.ReadLine();
                Console.Clear();
                Options();


            }

            else if (choice == 3)
            {
                Console.Clear();
                PayForOrder();
                Console.Clear();
                Options();

            }

            else if (choice == 4)
            {
                Console.Clear();
                PostAReview();
                Console.Clear();
                Options();

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

        
        public void ViewAvailableProviders(string Location,string Category)
        { 
            
            for (int i=0; i <MySystem.PCounter;i++)
            { 
                
               if (MySystem.ProviderArr[i].GetLocation() == Location && MySystem.ProviderArr[i].GetCategory() == Category)
                    Console.WriteLine(MySystem.ProviderArr[i]);
              
             }
        }
        public void CachCrediteUpdate(double totalCost)
        { 
            this.CashCredit-= totalCost;
        }
        
        
       
        public void PlaceNewOrder()
        {

            Console.WriteLine("Enter your current location (Area1 or Area2 or Area3) :");
            string Location = Console.ReadLine();
            Console.WriteLine("Enter  the category of the provider please (Market or Food) : ");
            string Category = Console.ReadLine();
            ViewAvailableProviders(Location,Category);
            Console.WriteLine("Enter the provider name please :");
            string Pname = Console.ReadLine();
            
            int j=0;
            Item[] I = MySystem.GetItemsByProvider(ref j, Pname);
            
            for (int i=0;i<j;i++)
            {
                I[i].ViewItem();
               
            }
            
            int k = 0;
            Offer []O = MySystem.GetOffersByProvider(ref k, Pname);
            for (int i = 0; i < k; i++)
            {
                O[i].View();
            }
            
            Order Ord = new Order();
            double CostCounter = MySystem.GetProviderDeliveryRate(Pname);
            int choice;
            bool f = true;
            do
            {
                Console.Clear();
               for (int i=0;i<j ;i++)
            {
                I[i].ViewItem();
            }

                Console.WriteLine("[1] Add an item to the order");
                Console.WriteLine("[2] Add an offer to the order");
                Console.WriteLine("[3] Finished Adding to the order");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());


                if (choice == 1)
                {
                    Console.WriteLine("\n\nPlease Enter the ID and the Quantity of the item you want to add");
                    Console.Write("ID: ");
                    string ID = Console.ReadLine();
                    Console.Write("Quantity: ");
                    int Quantity = Convert.ToInt32(Console.ReadLine());
                    
                    for (int i=0;i<j;i++)
                    {
                        if (I[i].GetID() == ID)
                        {
                            MySystem.ChangeItemQuantity(Pname, ID, Quantity);
                            CostCounter += (double)Quantity * I[i].GetPrice();
                            
                            Ord.AddItem(I[i]);
                            break;                        
                        }

                    }
                }

                else if (choice == 2)
                {

                    Console.WriteLine("\n\nPlease Enter the ID of the Offer you want to add");
                    Console.Write("Offer's ID: ");
                    string ID = Console.ReadLine();
                    
                    
                
                    for (int i = 0; i < k; i++)
                    {
                        if (O[i].GetID() == ID)
                        {
                            MySystem.ChangeItemQuantity(Pname, ID, O[i].GetQuantity());
                            CostCounter +=  O[i].GetCost();
                            Ord.AddItem(I[i]);
                            break;

                        }

                    }

                }
                else if (choice == 3)
                    f = false;

            } while (f==true);

            Console.WriteLine("Enter A Unique ID for the Order please: ");
            string OrderID = Console.ReadLine();
            
           Ord.SetOrderInfo(OrderID,this.Name,Pname,"not paid",CostCounter);
            MySystem.OrderArr[MySystem.OrCounter++]=Ord;

            MySystem.Storefiles();
        }


        public void VeiwMyOrders()
        {
            for (int i=0 ; i<MySystem.OrCounter;i++)
                if(MySystem.OrderArr[i].GetCustomerName()== this.GetUsername())
                MySystem.OrderArr[i].View();
        }
       
        
        public void PayForOrder()
        {
            
            
            
            

            for (int j=0;j<MySystem.OrCounter;j++)
            { 
                if (MySystem.OrderArr[j].GetCustomerName()==this.Name &&MySystem.OrderArr[j].GetStatus()=="not paid")
                    MySystem.OrderArr[j].View();
            }

            Console.Write("Enter the ID of the order you want to pay for please: ");
            string ID = Console.ReadLine();

            int c=0;
            for (; c<MySystem.OrCounter; c++)
            { 
               if(MySystem.OrderArr[c].GetID()==ID)
                { 
                    MySystem.OrderArr[c].SetStatus("paid");
                    break;
                }

            }

            double TotalCost = MySystem.OrderArr[c].GetTotalCost();
            CachCrediteUpdate(TotalCost);

            string Pname = MySystem.OrderArr[c].GetProviderName();
            for (int r=0 ; r<MySystem.PCounter; r++)
            { 
                if (MySystem.ProviderArr[r].GetName()==Pname)
                   {
                    MySystem.ProviderArr[r].IncomeUpdate(TotalCost); 
                     
                   }
            }
            MySystem.Storefiles();
        }

        public void PostAReview()
        {
           

            for (int k = 0; k < MySystem.OrCounter; k++)
            {
                if (MySystem.OrderArr[k].GetCustomerName() == this.Name && MySystem.OrderArr[k].GetStatus() == "delivered")
                    MySystem.OrderArr[k].View();
            }


            Console.Write("Enter the ID of the order you want to post a review for please: ");
            string ID = Console.ReadLine();

            Console.Write("Enter the Review value please: ");
            double review = Convert.ToDouble(Console.ReadLine());

            string Pname="";
            int j = 0;

            for (; j<MySystem.OrCounter;j++)
            { 
                if (MySystem.OrderArr[j].GetID()==ID)
                { 
                       Pname=MySystem.OrderArr[j].GetProviderName();
                }

            }
            int t=0;
            for (; t<MySystem.PCounter;t++)
            { 
                if (MySystem.ProviderArr[t].GetName()==Pname)
                    MySystem.ProviderArr[t].SetNewReview(review);
            }

          
            MySystem.Storefiles();
        }

        


    }
}