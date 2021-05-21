using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace UML_Console_Project.ProjectFiles
{
    [Serializable]
    class Customer : User
    {
        private string Name;
        private int Password;
        private string CashCredit;
        Provider provider;

        Customer(string Name, int Password, string CashCredit)
        {
            this.Name = Name;
            this.Password = Password;
            this.CashCredit = CashCredit;

        }

        public void ReadProvider(string location, string category)
        {
            Provider[] pArr = new Provider[6];
            int i = 0;
            provider.read(pArr);
            foreach (Provider pr in pArr)
            {
                if (pr.GetLocation() == location || pr.GetCategory() == category)
                {
                }


            }



        }



        public void PlaceNewOrder()
        {
            Console.WriteLine("Enter which of this it is current location (Area1 or Area2 or Area3 ):");
            string Location = Console.ReadLine();
            Console.WriteLine("Enter  the category of the provider please: ");
            string Category = Console.ReadLine();







        }

        public void VeiwMyOrders()
        {
        }

        public void PayForOrder()
        {
        }

        public void PostAReview()
        {
        }

        public void setProvider(Provider p)
        {
            provider = p;
        }


    }
}