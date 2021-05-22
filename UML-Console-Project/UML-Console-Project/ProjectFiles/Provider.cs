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
        public string GetLocation()
        {
            return this.Location;
        }

        public string GetCategory()
        {
            return this.Category;
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
            i1[1].AddItem("", "", 0, 0);
            i1[2].AddItem("", "", 0, 0);
         
            MySystem.ProviderArr[0].Setall("Hot and Cold","Food","Area1",0.68,0.05,i1,100);

            Item[] i2 = new Item[100];



            MySystem.ProviderArr[1] .Setall("MY Bread","Food","Area1",0.75,0.07,i2,200);
            MySystem.ProviderArr[2] ={"Good Recipe","Food","Area2",0.9,0.12,i0[2],300};
            MySystem.ProviderArr[3] ={"Tasty","Food","Area3", 0.73 , 0.06 ,i0[3] ,400};
            MySystem.ProviderArr[4] ={"Stop Here","Market","Area1",0.88,0.1 ,i0[4],500};
            MySystem.ProviderArr[5] ={"Good Mart","Market","Area2",0.95,0.15,i0[5],600};
            MySystem.ProviderArr[6] ={"WMs","Market","Area2",0.82,0.09,i0[6],700};
            MySystem.ProviderArr[7] ={"24Hours","Market","Area3",0.79,0.08,i0[7],800};
            MySystem.ProviderArr[8] ={"C-Market","Market","Area1",0.92,0.14,i0[8],900};
          
        }
        
        

        }
      

}
}
