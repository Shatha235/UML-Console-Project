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
            }

            else if (choice == 2)
            {
                Console.Clear();
                AddOffer();
            }

            else if (choice == 3)
            {
                Console.Clear();
                ViewAllProviders();
            }

            else if (choice == 4)
            {
                Console.Clear();
                ViewAllCustomers();
            }

            else if (choice == 5)
            {
                Console.Clear();
                ViewAllOrders();
            }

            else if (choice == 6)
            {
                Console.Clear();
                ViewAllOffers();
            }

            else if (choice == 7)
            {
                Console.Clear();
                Deliver();
            }

            else if (choice == 8)
            {
                Console.Clear();
                CancelOffer();
            }

            else if (choice == 9)
            {
                Console.Clear();
                MySystem.Logout();
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
            bool flag = false;

            while (!flag)
            {
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
                for (int i = 0; i <MySystem.PCounter; i++)
                {
                    if (providerName == MySystem.ProviderArr[i].GetName())
                    {
                        flag = true;
                        MySystem.ProviderArr[i].AddItem(ID, description, price, qty);
                        Console.WriteLine("Item was added successfully");
                        break;
                    }
                }

            }
              if (!flag)
                {
                    Console.Clear();
                    Sh.Msg("Provider entered does not exist");
               }
                

            
      
        }
    

        static public void AddOffer()
        {
            Console.WriteLine("AddOffer");
            Console.WriteLine("Enter provider's name : ");
            string providerName = Console.ReadLine();
            for(int i=0;i<MySystem.PCounter;i++)
            {

            }
        }

        static public void ViewAllProviders()
        {
            Console.WriteLine("ViewAllProviders");

        }

        static public void ViewAllCustomers()
        {
            Console.WriteLine("ViewAllCustomers");

        }

        static public void ViewAllOrders()
        {
            Console.WriteLine("ViewAllOrders");

        }

        static public void ViewAllOffers()
        {
            Console.WriteLine("ViewAllOffers");

        }

        static public void Deliver()
        {
            Console.WriteLine("Deliver");

        }

        static public void CancelOffer()
        {
            Console.WriteLine("CancelOffer");

        }

    }
}
