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
    class Provider
    {
        
        private string Name;
        private string Category;
        private string Location;
        private double Review;
        private double DeliveryRate;
        private Item[] ListOfItems;
        private int Income;

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
        public string GetDeliveryRate()
        { 
            return this.DeliveryRate;
        }
        public void Setall(string Name,string Category,string Location,double Review,double DeliveryRate,Item[] ListOfItems, int Income) 
        {
            this.Name = Name;
            this.Category = Category;
            this.Location = Location;
            this.Review = Review;
            this.DeliveryRate = DeliveryRate;
            this.ListOfItems = ListOfItems;
            this.Income = Income;
            
        }
        
        
        public void InaitialData()
        {

            Item [] i1= new Item[100];
            i1[0].AddItem("I1", "Juice", 4, 10);
            i1[1].AddItem("I2", "Sandwich ",8, 30);
            i1[2].AddItem("I5", "Salad", 5,25);
            MySystem.ProviderArr[0].Setall("Hot and Cold","Food","Area1",0.68,0.05,i1,100);

            Item[] i2 = new Item[100];
            i2[0].AddItem("I2","Sandwich",8,30);
            i2[1].AddItem("I3", "Sweet", 15, 20);
            i2[2].AddItem("I4", "Steak", 20, 15 );
            i2[3].AddItem("I5" ,"Salad" ,5, 25);
            MySystem.ProviderArr[1].Setall("MY Bread","Food","Area1",0.75,0.07,i2,200);

            Item[] i3 = new Item[100];
            i3[0].AddItem("I1", "Juice", 4, 10);
            i3[1].AddItem("I2", "Sandwich ",8, 30);
            i3[2].AddItem("I3", "Sweet", 15, 20);
            i3[3].AddItem("I4", "Steak", 20, 15 );
            i3[4].AddItem("I5" ,"Salad" ,5, 25);
            MySystem.ProviderArr[2].Setall("Good Recipe","Food","Area2",0.9,0.12,i3,300);

            Item[] i4 = new Item[100];
            i4[0].AddItem("I1", "Juice", 4, 10);
            i4[1].AddItem("I2", "Sandwich ",8, 30);
            i4[2].AddItem("I3", "Sweet", 15, 20);
            i4[3].AddItem("I5" ,"Salad" ,5, 25);
            MySystem.ProviderArr[3].Setall("Tasty","Food","Area3", 0.73 , 0.06 ,i4 ,400);

            Item[] i5 = new Item[100];
            i5[0].AddItem("I6" ,"Hand wash", 3, 50);
            i5[1].AddItem("I7" ,"Spices" ,6 ,35);
            i5[2].AddItem("I8" ,"Tissues", 10, 70);
            i5[3].AddItem("I9","Oil", 7 ,30);
            i5[4].AddItem("I10","Sanitizer" ,2,100);
            MySystem.ProviderArr[4].Setall("Stop Here","Market","Area1",0.88,0.1 ,i5,500);

            Item[] i6 = new Item[100];
            i6[0].AddItem("I6" ,"Hand wash", 3, 50);
            i6[1].AddItem("I7" ,"Spices" ,6 ,35);
            i6[2].AddItem("I8" ,"Tissues", 10, 70);
            i6[3].AddItem("I9","Oil", 7 ,30);
            i6[4].AddItem("I10","Sanitizer" ,2,100);
            MySystem.ProviderArr[5].Setall("Good Mart","Market","Area2",0.95,0.15,i6,600);

            Item[] i7 = new Item[100];
            i7[0].AddItem("I6" ,"Hand wash", 3, 50);
            i7[2].AddItem("I8" ,"Tissues", 10, 70);
            i7[3].AddItem("I9","Oil", 7 ,30);
            i7[4].AddItem("I10","Sanitizer" ,2,100);
            MySystem.ProviderArr[6].Setall("WMs","Market","Area2",0.82,0.09,i7,700);

            Item[] i8= new Item[100];
            i8[0].AddItem("I6" ,"Hand wash", 3, 50);
            i8[1].AddItem("I7" ,"Spices" ,6 ,35);
            i8[2].AddItem("I8" ,"Tissues", 10, 70);
            i8[3].AddItem("I9","Oil", 7 ,30);
            MySystem.ProviderArr[7].Setall("24Hours","Market","Area3",0.79,0.08,i8,800);

            Item[] i9 = new Item[100];
            i9[0].AddItem("I6" ,"Hand wash", 3, 50);
            i9[1].AddItem("I7" ,"Spices" ,6 ,35);
            i9[2].AddItem("I8" ,"Tissues", 10, 70);
            i9[3].AddItem("I9","Oil", 7 ,30);
            i9[4].AddItem("I10","Sanitizer" ,2,100);
            MySystem.ProviderArr[8].Setall("C-Market","Market","Area1",0.92,0.14,i9,900);
            MySystem.Storefiles();
        }
        
        public void PrintProvider()
        { 
            MySystem.Loadfiles();
            for(int i=0;i<MySystem.ProviderArr.Length();i++)
            { 
               Console.WriteLine(MySystem.ProviderArr[i]);
            }
        }
        }
      

}
}
