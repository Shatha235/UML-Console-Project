using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Console_Project;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UML_Console_Project.ProjectFiles;


namespace UML_Console_Project.ProjectFiles
{
    class Admin 
    {
        static private string Username = "admin";
        static private string Password = "00";

        static public string GetUsername()
        {
            return Username;
        }
        static public string GetPassword()
        {
            return Password;
        }


        static public void Options()
        {
            int choice;
            Console.WriteLine("[1] Add new item for a specific provider");
            Console.WriteLine("[2] Present new offer");
            Console.WriteLine("[3] View all providers");
            Console.WriteLine("[4] View all customersr");
            Console.WriteLine("[5] View all orders");
            Console.WriteLine("[6] View all offers");
            Console.WriteLine("[7] Deliver all paid orders");
            Console.WriteLine("[8] Cancel offer");
            Console.WriteLine("[9] Logut\n");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Clear();
                AddItem();
                Console.Clear();
                Options();
            }

            else if (choice == 2)
            {
                Console.Clear();
                AddOffer();
                Console.Clear();
                Options();

            }

            else if (choice == 3)
            {
                Console.Clear();
                ViewAllProviders();
                Console.Write("if you finished reading please press Enter : ");
                string s = Console.ReadLine();
                Console.Clear();
                Options();

            }

            else if (choice == 4)
            {
                Console.Clear();
                ViewAllCustomers();
                Console.Write("if you finished reading please press Enter : ");
                string s = Console.ReadLine();
                Console.Clear();
                Options();


            }

            else if (choice == 5)
            {
                Console.Clear();
                ViewAllOrders();
                Console.Write("if you finished reading please press Enter : ");
                string s = Console.ReadLine();
                Console.Clear();
                Options();


            }

            else if (choice == 6)
            {
                Console.Clear();
                ViewAllOffers();
                Console.Write("if you finished reading please press Enter : ");
                string s = Console.ReadLine();
                Console.Clear();
                Options();

            }

            else if (choice == 7)
            {
                Console.Clear();
                Deliver();
                Console.Clear();
                Options();

            }

            else if (choice == 8)
            {
                Console.Clear();
                CancelOffer();
                Console.Clear();
                Options();

            }

            else if (choice == 9)
            {
                Console.Clear();
                MySystem.Logout();
                

            }

            else
            {
                Sh.Msg("You entered a wrong choice,\nplease enter a valid choice from 1-9 to continue...");
                Options();

            }

        }
        static public void AddItem()
        {

            string ID, description, providerName;
            double price;
            int qty;
          
                
                Console.WriteLine("Enter item's information");
                Console.Write("ID : ");
                ID = Console.ReadLine();
                Console.Write("Description : ");
                description = Console.ReadLine();
                Console.Write("Price : ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Quantity : ");
                qty = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter provider's name : ");
                providerName = Console.ReadLine();

            for (int i = 0; i < MySystem.PCounter; i++)
            { 
                if (providerName == MySystem.ProviderArr[i].GetName())
                {

                    MySystem.ProviderArr[i].AddItem(ID, description, price, qty);
                    Console.WriteLine("Item was added successfully.");
                    break;
                }
             }

            MySystem.Storefiles();
        }
    

        static public void AddOffer()
        {
            int i = 0;
            Item[] proItems = new Item[100];
            
            Console.Write("Enter provider's name : ");
            string providerName = Console.ReadLine();

            proItems= MySystem.GetItemsByProvider(ref i,providerName);

            for (int j = 0; j < i; j++)
                proItems[j].ViewItem();

            Console.WriteLine("Enter new offer's information\n");
            Console.Write("Offer's ID : ");
            string ID = Console.ReadLine();
            Console.Write("Item ID : ");
            string itemID = Console.ReadLine();
            Console.Write("Quantity of items in the offer : ");
            int Quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Offer price : ");
            double offerPrice = Convert.ToDouble(Console.ReadLine());
            Offer.AddOffer(ID ,providerName, itemID, Quantity, offerPrice);
            Console.WriteLine("Offer was added successfully.");
            MySystem.Storefiles();
        }
        
        static public void ViewAllProviders()
        { 
            for (int i = 0; i < MySystem.PCounter; i++)
            {
                 MySystem.ProviderArr[i].View();
                Console.WriteLine("\n\n");
            }
        }

        static public void ViewAllCustomers()
        {
            for(int i=0;i<MySystem.CCounter;i++)
            {
                MySystem.CustomerArr[i].View();
                Console.WriteLine("\n\n");
            }
        }

        static public void ViewAllOrders()
        {
            for(int i=0;i<MySystem.OrCounter;i++)
            {
               MySystem.OrderArr[i].View();
                Console.WriteLine("\n\n");

            }
        }

        static public void ViewAllOffers()
        {
            
            for(int i=0;i<1;i++)
            {
                MySystem.OfferArr[i].View();
                Console.WriteLine("\n\n");

            }

        }

        static public void Deliver()
        {
            for (int i = 0; i < MySystem.OrCounter; i++)
            {
                if (MySystem.OrderArr[i].GetStatus() == "paid")
                {
                    MySystem.OrderArr[i].SetStatus("delivered");
                }
                
            }
            MySystem.Storefiles();

        }

        static public void CancelOffer()
        {
            Console.WriteLine("CancelOffer");
            ViewAllOffers();
            Console.Write("Enter offer's ID : ");
            string ID = Console.ReadLine();
            MySystem.CancelOffer(ID);
            MySystem.Storefiles();
        }
        
    }
       
}
