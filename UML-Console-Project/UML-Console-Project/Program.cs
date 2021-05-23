using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UML_Console_Project.ProjectFiles;

namespace UML_Console_Project
{
    class MySystem
    {
        static public Provider[] ProviderArr = new Provider[100];
        static public Customer[] CustomerArr = new Customer[100];
        static public Order[] OrderArr = new Order[100];
        static public Offer[] OfferArr = new Offer[100];

        static public int PCounter = 0;
        static public int CCounter = 0;
        static public int OrCounter = 0;
        static public int OfCounter = 0;



        static public void Storefiles()
        {
            FileStream Pfile, Cfile, Offile, Orfile;
            BinaryFormatter bf = new BinaryFormatter();

            Pfile = new FileStream("ProviderFile.txt", FileMode.Create, FileAccess.Write);
            Cfile = new FileStream("CustomerFile.txt", FileMode.Create, FileAccess.Write);
            Orfile = new FileStream("OrderFile.txt", FileMode.Create, FileAccess.Write);
            Offile = new FileStream("Order.txt", FileMode.Create, FileAccess.Write);


            //Provider
            for (int i = 0; i < PCounter; i++)
            {
                bf.Serialize(Pfile, ProviderArr);
            }
            Pfile.Close();


            //Customer
            for (int i = 0; i < CCounter; i++)
            {
                bf.Serialize(Cfile, CustomerArr);
            }
            Cfile.Close();


            //Order
            for (int i = 0; i < OrCounter; i++)
            {
                bf.Serialize(Orfile, OrderArr);
            }
            Orfile.Close();


            //Offer
            for (int i = 0; i < OfCounter; i++)
            {
                bf.Serialize(Offile, OfferArr);

            }
            Offile.Close();

        }


        static public void Loadfiles()
        {
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
                Cfile = new FileStream("Customer.txt", FileMode.Open, FileAccess.Read);
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
                Orfile = new FileStream("Order.txt", FileMode.Open, FileAccess.Read);
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
                Offile = new FileStream("Offer.txt", FileMode.Open, FileAccess.Read);
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



        public void Login()
        {

        }

        public void LoginAsAdmin()
        {
        }

        public void LoginAsCustomer()
        {

        }

        public void Logout()
        {}

        
    }


    class Program
    {
        static void Main(string[] args)
        {
            //"how to clear console + freeze "
            /*Console.WriteLine("hi");
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("hi, again");
            Thread.Sleep(5000);*/

        

        }
    }
}
