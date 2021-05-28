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
    class Admin : User
    {


        //I added this function here to organize the code a little more,However,I implemented it since it  belongs to the system originally
        //<jebril>

        static public void Options(int PCounter, Provider[] ProviderArr)
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
                MySystem.LoginAsAdmin();
            }

            else if (choice == 2)
            {
                Console.Clear();
                AddOffer();
                Console.Clear();
                MySystem.LoginAsAdmin();

            }

            else if (choice == 3)
            {
                Console.Clear();
                ViewAllProviders();
                Console.Clear();
                MySystem.LoginAsAdmin();

            }

            else if (choice == 4)
            {
                Console.Clear();
                ViewAllCustomers();
                Console.Clear();
                MySystem.LoginAsAdmin();

            }

            else if (choice == 5)
            {
                Console.Clear();
                ViewAllOrders();
                Console.Clear();
                MySystem.LoginAsAdmin();

            }

            else if (choice == 6)
            {
                Console.Clear();
                ViewAllOffers();
                Console.Clear();
                MySystem.LoginAsAdmin();

            }

            else if (choice == 7)
            {
                Console.Clear();
                Deliver();
                Console.Clear();
                MySystem.LoginAsAdmin();

            }

            else if (choice == 8)
            {
                Console.Clear();
                CancelOffer();
                Console.Clear();
                MySystem.LoginAsAdmin();

            }

            else if (choice == 9)
            {
                Console.Clear();
                MySystem.Logout();
                Console.Clear();
                MySystem.LoginAsAdmin();

            }

            else
            {
                Sh.Msg("You entered a wrong choice,\nplease enter a valid choice from 1-9 to continue...");
                Options(PCounter, ProviderArr);

            }

        }
        static public void AddItem()
        {

            string ID, description, providerName;
            int qty, price;
          
                Console.WriteLine("AddItem");
                Console.WriteLine("Enter item's information");
                Console.WriteLine("ID = ");
                ID = Console.ReadLine();
                Console.WriteLine("Description : ");
                description = Console.ReadLine();
                Console.WriteLine("Price : ");
                price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Quantity : ");
                qty = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter provider's name : ");
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
            Console.WriteLine("AddOffer");
            Console.WriteLine("Enter provider's name : ");
            string providerName = Console.ReadLine();

            proItems= MySystem.GetItemsByProvider(ref i,providerName);

            for (int j = 0; j < i; j++)
                proItems[j].ViewItem();

            Console.WriteLine("Enter new offer's information");
            Console.WriteLine("Offer's ID : ");
            string ID = Console.ReadLine();
            Console.WriteLine("Item ID : ");
            string itemID = Console.ReadLine();
            Console.WriteLine("Quantity of items in the offer : ");
            int Quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Offer price : ");
            double offerPrice = Convert.ToDouble(Console.ReadLine());
            Offer.AddOffer(ID ,providerName, itemID, Quantity, offerPrice);
            Console.WriteLine("Offer was added successfully.");

        }
        
        static public void ViewAllProviders()
        { 
            Console.WriteLine("ViewAllProviders");
            for (int i = 0; i < MySystem.PCounter; i++)
            {
                 MySystem.ProviderArr[i].View();
            }
        }

        static public void ViewAllCustomers()
        {
            Console.WriteLine("ViewAllCustomers");
            for(int i=0;i<MySystem.CCounter;i++)
            {
                MySystem.CustomerArr[i].View();
            }
        }

        static public void ViewAllOrders()
        {
            Console.WriteLine("ViewAllOrders");

            for(int i=0;i<MySystem.OrCounter;i++)
            {
               MySystem.OrderArr[i].ViewAllOrders();
            }
        }

        static public void ViewAllOffers()
        {
            Console.WriteLine("ViewAllOffers");
            for(int i=0;i<MySystem.OfCounter;i++)
            {
                MySystem.OfferArr[i].View();
            }

        }

        static public void Deliver()
        {
            Console.WriteLine("Deliver all paid orders");

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
            Console.WriteLine("Enter offer's ID : ");
            string ID = Console.ReadLine();
            MySystem.CancelOffer(ID);
            MySystem.Storefiles();
        }
        
    }
       
}
