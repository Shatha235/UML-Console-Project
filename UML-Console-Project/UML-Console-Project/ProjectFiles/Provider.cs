using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UML_Console_Project;

namespace UML_Console_Project.ProjectFiles
{
    [Serializable]
    class Provider
    {
        
        private string Name;
        private string Category;
        private string Location;
        private double Review;
        private double DeliveryRate;
        private Item[] ListOfItems=new Item[100];
        private int Income;
        public int ItemCounter=0;

        public Provider(string Name = "", string Category = "", string Location = "", double Review = 0.0, double DeliveryRate = 0.0, Item[] ListOfItems=null, int Income=0)
        {
            this.Name = Name;
            this.Category = Category;
            this.Location = Location;
            this.Review = Review;
            this.DeliveryRate = DeliveryRate;
            this.ListOfItems = new Item[100];
            for (int i = 0; i < ItemCounter; i++)
                this.ListOfItems[i] = ListOfItems[i];
            this.Income = Income;

        }

        public Provider(Provider P)
        {
            this.Name = P.Name;
            this.Category = P.Category;
            this.Location = P.Location;
            this.Review = P.Review;
            this.DeliveryRate = P.DeliveryRate;
            this.ListOfItems = new Item[100];
            for (int i = 0; i < ItemCounter; i++)
                this.ListOfItems[i] = P.ListOfItems[i];
            this.Income = P.Income;

        }

        public void Setall(string Name, string Category, string Location, double Review, double DeliveryRate, Item[] ListOfItems, int Income)
        {
            this.Name = Name;
            this.Category = Category;
            this.Location = Location;
            this.Review = Review;
            this.DeliveryRate = DeliveryRate;
            this.ListOfItems = new Item[100];
            for (int i = 0; i < ItemCounter; i++)
                this.ListOfItems[i] = ListOfItems[i];
            this.Income = Income;

        }
        public void setIncome(int income)
        { 
            this.Income=income;

        }
       

        //prints

        public void View()
        {
            Item[] Allitems = new Item[100];
            int i = 0;
            Console.WriteLine("Name: " + Name + "    Category: " + Category + "    Location: " + Location + "    Review: " + Convert.ToString(100 * Review) + "%" + "    DeliveryRate: " + Convert.ToString(100 * DeliveryRate) + "%"+ "    Income: " + Income + "\n Items:  ");
            for (; i < ItemCounter; i++)
            {

                Console.WriteLine(ListOfItems[i]);
                
            }
        }

        public override string ToString()
        {
          
            return ("Name: " + Name + "    Category: " + Category + "    Location: " + Location + "    Review: " + Convert.ToString(100 * Review) + "%" + "    DeliveryRate: " + Convert.ToString(100 * DeliveryRate) + "%" + "    Income: " + Income);
        }

        //gets
        public string GetName()
        { 
            return this.Name;
        }
        
       
       
        public string GetLocation()
        {
            return this.Location;
        }

        public string GetCategory()
        {
            return this.Category;
        }

        public Item GetItem(int i)
        {
            return (ListOfItems[i]);
        }
        public double GetDeliveryRate()
        {
            return DeliveryRate;
        }

        public int getItemIndex(string id)
        {
            int index=0;
            for (int i = 0; i < ItemCounter; i++)
                if (ListOfItems[i].GetID() == id)
                {
                    index = i;
                    break;
                }
            
            return index;
        }
        public void SetItemQuantity(int index,int Q)
        {
            ListOfItems[index].SetQuantity(Q);
        }
        public int GetIncome()
        { 
            return this.Income;
        }
        

        //functions
        

       
        public void  SetNewReview(double r)
        {
          double Average;
          Average = (r + this.Review)/2;
            
            Review= Average;
        }

        public void AddItem(string ID, string Description, int Price, int Quantity)
        {
            ListOfItems[ItemCounter++] = new Item( ID,  Description,  Price,  Quantity);
        }

        
        
        
        
        static public void InaitialData()
        {

            //warning : only call it when you wanna reset provider data

           

            MySystem.ProviderArr = new Provider[100]; // to reset the array before initiating <jebril>
            Item [] i1= new Item[100];
            i1[0]= new Item("I1", "Juice", 4, 10);  
            i1[1]=new Item("I2", "Sandwich ",8, 30);
            i1[2] = new Item("I5", "Salad", 5,25);
            Provider p0 = new Provider("Hot and Cold", "Food", "Area1", 0.68, 0.05, i1, 100);
            MySystem.ProviderArr[0]=new Provider(p0);
            p0.ItemCounter = 3;

            Item[] i2 = new Item[100];
            i2[0] = new Item("I2","Sandwich",8,30);
            i2[1] = new Item("I3", "Sweet", 15, 20);
            i2[2] = new Item("I4", "Steak", 20, 15 );
            i2[3] = new Item("I5" ,"Salad" ,5, 25);
            Provider p1 = new Provider("MY Bread", "Food", "Area1", 0.75, 0.07, i2, 200);
            MySystem.ProviderArr[1]=new Provider(p1);
            p1.ItemCounter = 4;


            Item[] i3 = new Item[100];
            
            i3[0] = new Item("I1", "Juice", 4, 10);
            i3[1] =new Item("I2", "Sandwich ",8, 30);
            i3[2] = new Item("I3", "Sweet", 15, 20);
            i3[3] = new Item("I4", "Steak", 20, 15 );
            i3[4] = new Item("I5" ,"Salad" ,5, 25);
            Provider p2 = new Provider("Good Recipe", "Food", "Area2", 0.9, 0.12, i3, 300);
            MySystem.ProviderArr[2]=new Provider(p2);
            p2.ItemCounter = 5;

            Item[] i4 = new Item[100];
            i4[0] = new Item("I1", "Juice", 4, 10);
            i4[1] = new Item("I2", "Sandwich ",8, 30);
            i4[2] = new Item("I3", "Sweet", 15, 20);
            i4[3] = new Item("I5" ,"Salad" ,5, 25);
            Provider p3 = new Provider("Tasty", "Food", "Area3", 0.73, 0.06, i4, 400);
            MySystem.ProviderArr[3] = new Provider(p3);
            p3.ItemCounter = 4;

            Item[] i5 = new Item[100];
            i5[0] = new Item("I6" ,"Hand wash", 3, 50);
            i5[1] = new Item("I7" ,"Spices" ,6 ,35);
            i5[2] = new Item("I8" ,"Tissues", 10, 70);
            i5[3] = new Item("I9","Oil", 7 ,30);
            i5[4] = new Item("I10","Sanitizer" ,2,100);
            Provider p4 = new Provider("Stop Here", "Market", "Area1", 0.88, 0.1, i5, 500);
            MySystem.ProviderArr[4]=new Provider(p4);
            p4.ItemCounter = 5;

            Item[] i6 = new Item[100];
            i6[0] = new Item("I6" ,"Hand wash", 3, 50);
            i6[1] = new Item("I7" ,"Spices" ,6 ,35);
            i6[2] = new Item("I8" ,"Tissues", 10, 70);
            i6[3] = new Item("I9","Oil", 7 ,30);
            i6[4] = new Item("I10","Sanitizer" ,2,100);
            Provider p5 = new Provider("Good Mart", "Market", "Area2", 0.95, 0.15, i6, 600);
            MySystem.ProviderArr[5]=new Provider(p5);
            p5.ItemCounter = 5;

            Item[] i7 = new Item[100];
            i7[0] = new Item("I6" ,"Hand wash", 3, 50);
            i7[1] = new Item("I8" ,"Tissues", 10, 70);
            i7[2] = new Item("I9","Oil", 7 ,30);
            i7[3] = new Item("I10", "Sanitizer", 2, 100);
            Provider p6 = new Provider("WMs", "Market", "Area2", 0.82, 0.09, i7, 700);
            MySystem.ProviderArr[6]=new Provider(p6);
            p6.ItemCounter = 4;

            Item[] i8= new Item[100];
            i8[0] = new Item("I6" ,"Hand wash", 3, 50);
            i8[1] = new Item("I7" ,"Spices" ,6 ,35);
            i8[2] = new Item("I8" ,"Tissues", 10, 70);
            i8[3] = new Item("I9","Oil", 7 ,30);
            Provider p7 = new Provider("24Hours", "Market", "Area3", 0.79, 0.08, i8, 800);
            MySystem.ProviderArr[7] = new Provider(p7);
            p7.ItemCounter = 4;

            Item[] i9 = new Item[100];
            i9[0] = new Item("I6" ,"Hand wash", 3, 50);
            i9[1] = new Item("I7" ,"Spices" ,6 ,35);
            i9[2] = new Item("I8" ,"Tissues", 10, 70);
            i9[3] = new Item("I9","Oil", 7 ,30);
            i9[4] = new Item("I10","Sanitizer" ,2,100);
            Provider p8 = new Provider("C-Market", "Market", "Area1", 0.92, 0.14, i9, 900);
            MySystem.ProviderArr[8]=new Provider(p8);
            p8.ItemCounter = 5;

            MySystem.PCounter = 9;
            MySystem.Storefiles();
           


        }

        
        }
}

