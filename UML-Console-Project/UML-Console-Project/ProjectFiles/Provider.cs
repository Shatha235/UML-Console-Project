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
        private Item[] ListOfItems;
        private int Income;
        public int ItemCounter=0;

        public Provider(string Name = "", string Category = "", string Location = "", double Review = 0.0, double DeliveryRate = 0.0, Item[] ListOfItems=null, int Income=0)
        {
            this.Name = Name;
            this.Category = Category;
            this.Location = Location;
            this.Review = Review;
            this.DeliveryRate = DeliveryRate;
            this.ListOfItems = ListOfItems;
            this.Income = Income;

        }

        public void Setall(string Name, string Category, string Location, double Review, double DeliveryRate, Item[] ListOfItems, int Income)
        {
            this.Name = Name;
            this.Category = Category;
            this.Location = Location;
            this.Review = Review;
            this.DeliveryRate = DeliveryRate;
            this.ListOfItems = ListOfItems;
            this.Income = Income;

        }

        //prints

        public void View()
        {
            Console.WriteLine("Name: " + Name + "    Category: " + Category + "    Location: " + Location + "    Review: " + Convert.ToString(100*Review) + "%" + "    DeliveryRate: " + Convert.ToString(100 *DeliveryRate) + "%" + "    Income: " + Income) ;
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


        //functions
        

       
        public void  SetNewReview(double r)
        {
          double Average;
          Average = (r + this.Review)/2;
            
            Review= Average * 100.0;
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
            i1[0]= Item.initateItem("I1", "Juice", 4, 10);  
            i1[1]=Item.initateItem("I2", "Sandwich ",8, 30);
            i1[2] = Item.initateItem("I5", "Salad", 5,25);
            Provider p0 = new Provider("Hot and Cold", "Food", "Area1", 0.68, 0.05, i1, 100);
            p0.ItemCounter = 3;
            MySystem.ProviderArr[0]=p0;

            Item[] i2 = new Item[100];
            i2[0] = Item.initateItem("I2","Sandwich",8,30);
            i2[1] = Item.initateItem("I3", "Sweet", 15, 20);
            i2[2] = Item.initateItem("I4", "Steak", 20, 15 );
            i2[3] = Item.initateItem("I5" ,"Salad" ,5, 25);
            Provider p1 = new Provider("MY Bread", "Food", "Area1", 0.75, 0.07, i2, 200);
            MySystem.ProviderArr[1]=p1;
            p1.ItemCounter = 4;


            Item[] i3 = new Item[100];
            
            i3[0] = Item.initateItem("I1", "Juice", 4, 10);
            i3[1] = Item.initateItem("I2", "Sandwich ",8, 30);
            i3[2] = Item.initateItem("I3", "Sweet", 15, 20);
            i3[3] = Item.initateItem("I4", "Steak", 20, 15 );
            i3[4] = Item.initateItem("I5" ,"Salad" ,5, 25);
            Provider p2 = new Provider("Good Recipe", "Food", "Area2", 0.9, 0.12, i3, 300);
            MySystem.ProviderArr[2]=p2;
            p2.ItemCounter = 5;

            Item[] i4 = new Item[100];
            i4[0] = Item.initateItem("I1", "Juice", 4, 10);
            i4[1] = Item.initateItem("I2", "Sandwich ",8, 30);
            i4[2] = Item.initateItem("I3", "Sweet", 15, 20);
            i4[3] = Item.initateItem("I5" ,"Salad" ,5, 25);
            Provider p3 = new Provider("Tasty", "Food", "Area3", 0.73, 0.06, i4, 400);
            MySystem.ProviderArr[3]=p3;
            p3.ItemCounter = 4;

            Item[] i5 = new Item[100];
            i5[0] = Item.initateItem("I6" ,"Hand wash", 3, 50);
            i5[1] = Item.initateItem("I7" ,"Spices" ,6 ,35);
            i5[2] = Item.initateItem("I8" ,"Tissues", 10, 70);
            i5[3] = Item.initateItem("I9","Oil", 7 ,30);
            i5[4] = Item.initateItem("I10","Sanitizer" ,2,100);
            Provider p4 = new Provider("Stop Here", "Market", "Area1", 0.88, 0.1, i5, 500);
            MySystem.ProviderArr[4]=p4;
            p4.ItemCounter = 5;

            Item[] i6 = new Item[100];
            i6[0] = Item.initateItem("I6" ,"Hand wash", 3, 50);
            i6[1] = Item.initateItem("I7" ,"Spices" ,6 ,35);
            i6[2] = Item.initateItem("I8" ,"Tissues", 10, 70);
            i6[3] = Item.initateItem("I9","Oil", 7 ,30);
            i6[4] = Item.initateItem("I10","Sanitizer" ,2,100);
            Provider p5 = new Provider("Good Mart", "Market", "Area2", 0.95, 0.15, i6, 600);
            MySystem.ProviderArr[5]=p5;
            p5.ItemCounter = 5;

            Item[] i7 = new Item[100];
            i7[0] = Item.initateItem("I6" ,"Hand wash", 3, 50);
            i7[1] = Item.initateItem("I8" ,"Tissues", 10, 70);
            i7[2] = Item.initateItem("I9","Oil", 7 ,30);
            i7[3] = Item.initateItem("I10", "Sanitizer", 2, 100);
            Provider p6 = new Provider("WMs", "Market", "Area2", 0.82, 0.09, i7, 700);
            MySystem.ProviderArr[6]=p6;
            p6.ItemCounter = 4;

            Item[] i8= new Item[100];
            i8[0] = Item.initateItem("I6" ,"Hand wash", 3, 50);
            i8[1] = Item.initateItem("I7" ,"Spices" ,6 ,35);
            i8[2] = Item.initateItem("I8" ,"Tissues", 10, 70);
            i8[3] = Item.initateItem("I9","Oil", 7 ,30);
            Provider p7 = new Provider("24Hours", "Market", "Area3", 0.79, 0.08, i8, 800);
            MySystem.ProviderArr[7] = p7;
            p7.ItemCounter = 4;

            Item[] i9 = new Item[100];
            i9[0] = Item.initateItem("I6" ,"Hand wash", 3, 50);
            i9[1] = Item.initateItem("I7" ,"Spices" ,6 ,35);
            i9[2] = Item.initateItem("I8" ,"Tissues", 10, 70);
            i9[3] = Item.initateItem("I9","Oil", 7 ,30);
            i9[4] = Item.initateItem("I10","Sanitizer" ,2,100);
            Provider p8 = new Provider("C-Market", "Market", "Area1", 0.92, 0.14, i9, 900);
            MySystem.ProviderArr[8]=p8;
            p8.ItemCounter = 5;

            MySystem.PCounter = 9;
            MySystem.Storefiles();
           


        }

        
        }
      

}

