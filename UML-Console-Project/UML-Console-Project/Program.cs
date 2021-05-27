using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UML_Console_Project.ProjectFiles;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UML_Console_Project
{
    class MySystem
    {

        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GetConsoleWindow();
        public static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public const int HIDE = 0;
        public const int MAXIMIZE = 3;
        public const int MINIMIZE = 6;
        public const int RESTORE = 9;


        static public Provider[] ProviderArr = new Provider[100];
        static public Customer[] CustomerArr = new Customer[100];
        static public Order[] OrderArr = new Order[100];
        static public Offer[] OfferArr = new Offer[100];

        static public int PCounter;
        static public int CCounter;
        static public int OrCounter;
        static public int OfCounter;


        static public Offer[] GetOffersByProvider(ref int j, string ProviderName) //j returns number of offers so we can use it in the loop in admin/customer
        {
            j = 0;
            Offer[] o = new Offer[100];
            for (int i = 0; i < OfCounter; i++)
            {
                if (OfferArr[i].GetProviderName() == ProviderName)
                    o[j++] = new Offer(OfferArr[i]);
            }

            return o;
        }
        /*static public Item ChangeAndReturnItem(string Pname,string ID,int Quantity)
        {
            int i = 0;
            for (; i < PCounter; i++)
            {
                if (ProviderArr[i].GetName() == Pname)
                    break;
            }
            for(int s=0;s<ProviderArr[i].ItemCounter;s++)
            if(ProviderArr[i].GetItem(s).GetID()==ID)
                {
                    Order.AddItem(ProviderArr[i].GetItem(s));
                }

        }*/
        static public Item[] GetItemsByProvider(ref int j, string ProviderName) //j returns number of items so we can use it in the loop in admin/customer
        {
            
            Item[] I = new Item[100];
            int i = 0;
            for (; i < PCounter; i++)
            {
                if (ProviderArr[i].GetName() == ProviderName)
                    break;
            }
            for(int k=0;k<ProviderArr[i].ItemCounter;k++)
            {
                
                I[k]= new Item(ProviderArr[i].GetItem(k));
            }


            j = ProviderArr[i].ItemCounter;
            return I;
        }

        static public Order[] GetOrdersByCustomer(ref int j, string CustomerName) //j returns number of orders so we can use it in the loop in admin/customer
        {
            j = 0;
            Order[] d = new Order[100];
            for (int i = 0; i < OrCounter; i++)
            {
                if (OrderArr[i].GetCustomerName() == CustomerName)
                    d[j++] =new Order( OrderArr[i]);
            }

            return d;
        }

        static public void CancelOffer(string ID)
        { int i = 0;
            for(;i<OfCounter;i++)
                if (OfferArr[i].GetID() == ID)
                    break;

            for (int j = i; j < OfCounter - 1; j++)
                OfferArr[j] = OfferArr[j + 1];

            OfCounter--;
                
        }

        static public void ChangeItemQuantity(string Pname,string ID,int Q)
        {

            int i = 0;
            for (; i < PCounter; i++)
            {
                if (ProviderArr[i].GetName() == Pname)
                    break;
            }
            ProviderArr[i].SetItemQuantity(ProviderArr[i].getItemIndex(ID), Q);
        }

        public static double GetProviderDeliveryRate(string Pname)
        {
            int i = 0;
            for (; i < PCounter; i++)
            {
                if (ProviderArr[i].GetName() == Pname)
                    break;
            }
            return ProviderArr[i].GetDeliveryRate();
        }

        static public void Storefiles()
        {
            
            FileStream Pfile, Cfile, Offile, Orfile;
            BinaryFormatter bf = new BinaryFormatter();

            Pfile = new FileStream("ProviderFile.txt", FileMode.Create, FileAccess.Write);
            Cfile = new FileStream("CustomerFile.txt", FileMode.Create, FileAccess.Write);
            Orfile = new FileStream("OrderFile.txt", FileMode.Create, FileAccess.Write);
            Offile = new FileStream("OfferFile.txt", FileMode.Create, FileAccess.Write);


            //Provider
            for (int i = 0; i < PCounter; i++)
            {
                bf.Serialize(Pfile, ProviderArr[i]);
            }
            Pfile.Close();


            //Customer
            for (int i = 0; i < CCounter; i++)
            {
                bf.Serialize(Cfile, CustomerArr[i]);
            }
            Cfile.Close();


            //Order
            for (int i = 0; i < OrCounter; i++)
            {
                bf.Serialize(Orfile, OrderArr[i]);
            }
            Orfile.Close();


            //Offer
            for (int i = 0; i < OfCounter; i++)
            {
                bf.Serialize(Offile, OfferArr[i]);

            }
            Offile.Close();

        }


        static public void Loadfiles()
        {
            ProviderArr = new Provider[100];
            CustomerArr = new Customer[100];
            OrderArr = new Order[100];
            OfferArr = new Offer[100];
            FileStream Pfile, Cfile, Offile, Orfile;
            BinaryFormatter bf = new BinaryFormatter();

            //provider
            if (File.Exists("ProviderFile.txt"))
            {
                Pfile = new FileStream("ProviderFile.txt", FileMode.Open, FileAccess.Read);
                PCounter = 0;
                while (Pfile.Position < Pfile.Length)
                {
                    ProviderArr[PCounter] = (Provider)bf.Deserialize(Pfile);
                    PCounter++;
                }

            }

            else
            {
                Pfile = new FileStream("ProviderFile.txt", FileMode.Create);
                Console.WriteLine("provider data file Created ");
            }

            Pfile.Close();


            //Customer
            if (File.Exists("CustomerFile.txt"))
            {
                Cfile = new FileStream("CustomerFile.txt", FileMode.Open, FileAccess.Read);
                CCounter = 0;
                while (Cfile.Position < Cfile.Length)
                {
                    CustomerArr[CCounter] = (Customer)bf.Deserialize(Cfile);
                    CCounter++;
                }

            }

            else
            {
                Cfile = new FileStream("CustomerFile.txt", FileMode.Create);
                Console.WriteLine("Customer data file Created ");
            }

            Cfile.Close();



            //Order
            if (File.Exists("OrderFile.txt"))
            {
                Orfile = new FileStream("OrderFile.txt", FileMode.Open, FileAccess.Read);
                OrCounter = 0;
                while (Orfile.Position < Orfile.Length)
                {
                    OrderArr[OrCounter] = (Order)bf.Deserialize(Orfile);
                    OrCounter++;
                }

            }

            else
            {
                Orfile = new FileStream("OrderFile.txt", FileMode.Create);
                Console.WriteLine("Order data file Created ");
            }

            Orfile.Close();


            //Offer
            if (File.Exists("OfferFile.txt"))
            {
                Offile = new FileStream("OfferFile.txt", FileMode.Open, FileAccess.Read);
                OfCounter = 0;
                while (Offile.Position < Offile.Length)
                {
                    OfferArr[OfCounter] = (Offer)bf.Deserialize(Offile);
                    OfCounter++;
                }

            }

            else
            {
                Offile = new FileStream("OfferFile.txt", FileMode.Create);
                Console.WriteLine("Offer data file Created ");
            }

            Offile.Close();

        }



        static public void Login()
        {
            int choice;
            Console.WriteLine("[1] Login as administrator");
            Console.WriteLine("[2] Login as customer");
            Console.WriteLine("[3] Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if(choice==1)
            {
                Console.Clear();
                LoginAsAdmin();
            }

            else if(choice==2)
            {
                Console.Clear();
                LoginAsCustomer();
            }

            else if(choice==3)
            {
                Console.Clear();
                Exit();
                
            }

            else
            {
                Sh.Msg("You entered a wrong choice,\nplease enter a valid choice from 1-3 to continue...");
                Login();
                
            }
            
        }

        static public void LoginAsAdmin()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("\nEnter passwrod: ");
            string password= Console.ReadLine();
            if (username == "admin" && password == "00")
            {
                Console.Clear();
                Admin.Options(PCounter, ProviderArr);
            }
            else
            {
                Sh.Msg("You entered unvalid login info,\nplease enter valid username and password to continue...");
                LoginAsAdmin();
            }


        }

        static public void LoginAsCustomer()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("\nEnter passwrod: ");
            string password = Console.ReadLine();
            if (username == CustomerArr[0].GetUsername() && password == CustomerArr[0].GetPassword())
            {
                Console.Clear();
                (CustomerArr[0]).Options();
            }

            else if (username == CustomerArr[1].GetUsername() && password == CustomerArr[1].GetPassword())
            {
                Console.Clear();
                (CustomerArr[1]).Options();
            }

            else if (username == CustomerArr[2].GetUsername() && password == CustomerArr[2].GetPassword())
            {
                Console.Clear();
                (CustomerArr[2]).Options();
            }

            else if (username == CustomerArr[3].GetUsername() && password == CustomerArr[3].GetPassword())
            {
                Console.Clear();
                (CustomerArr[3]).Options();
            }

            else if (username == CustomerArr[4].GetUsername() && password == CustomerArr[4].GetPassword())
            {
                Console.Clear();
                (CustomerArr[4]).Options();
            }

            else
            {
                Sh.Msg("You entered unvalid login info,\nplease enter valid username and password to continue...");
                LoginAsCustomer();
            }
        }

        static public void Logout()
        {
            Login();
        }

        static public void Exit()
        {
            Console.Beep(400,750);
        }


        static public void Reset()
        {
            Provider.InaitialData();
            Customer.InaitialData();
            Offer.InaitialData();
            Order.InaitialData();
        }

    }

    
    class Program
    {
        static void Main(string[] args)
        {

            Admin admin = new Admin();

            //opening console in fullscreen
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            MySystem.ShowWindow(MySystem.ThisConsole, MySystem.MAXIMIZE);
            //console color
                 Console.ForegroundColor = ConsoleColor.Green;


            //Warning : only call if you wanna reset All the databases
            //**********************
            //MySystem.Reset();
            //**********************]
            MySystem.Loadfiles();
            MySystem.Login();



        }
    }
}
