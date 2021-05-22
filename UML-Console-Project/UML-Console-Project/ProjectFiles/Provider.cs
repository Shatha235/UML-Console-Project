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
        private float Review;
        private int DeliveryRate;
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
        
        
        public void read(Provider []p)
        {
            FileStream f2 = new FileStream("ProviderFile.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            int t = 0;
            while (f2.Position < f2.Length)
            {
                
                p[t] = (Provider)formatter.Deserialize(f2);
                t++;
            }
        }

        public void InaitialData()
        { 
            Item [] i0= new Item[4];
            i0[0]=
            MySystem.p[0] ={"Hot and Cold","Food","Area1",0.68,0.05, ,100};
            MySystem.p[1] ={"MY Bread","Food","Area1",0.75,0.07, ,200};
            MySystem.p[2] ={"Good Recipe","Food","Area2",0.9,0.12, ,300};
            MySystem.p[3] ={"Tasty","Food","Area3",0.73,0.06, ,400};
            MySystem.p[4] ={"Stop Here","Market","Area1",0.88,0.1, ,500};
            MySystem.p[5] ={"Good Mart","Market","Area2",0.95,0.15, ,600};
            MySystem.p[6] ={"WMs","Market","Area2",0.82,0.09, ,700};
            MySystem.p[7] ={"24Hours","Market","Area3",0.79,0.08, ,80 0};
            MySystem.p[8] ={"C-Market","Market","Area1",0.92,0.14, ,900};
        }
        
           
            
 
        
        

}
}
