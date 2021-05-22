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
            string I1,I2,I3,I4,I5,I6,I7,I8,I9,I10;

            Item [] i0= new item[100];
            i0[0] ={I1,I2,I5};
            i0[1] ={I2,I3,I4,I5};
            i0[2] ={I1,I2,I3,I4,I5};
            i0[3] ={I1,I2,I3,I5};
            i0[4] ={I6,I7,I8,I9,I10};
            i0[5] ={I6,I7,I8,I9,I10};
            i0[6] ={I6,I8,I9,I10};
            i0[7] ={I6,I7,I8,I9};
            i0[8] ={I6,I7,I8,I9,I10};
            //i0[9] ={ AddItem(I1),AddItem(I2),AddItem(I3)} if it's correct we applay this to all items above
            MySystem.p[0] ={"Hot and Cold","Food","Area1",0.68,0.05,i0[0],100};
            MySystem.p[1] ={"MY Bread","Food","Area1",0.75,0.07,i0[1],200};
            MySystem.p[2] ={"Good Recipe","Food","Area2",0.9,0.12,i0[2],300};
            MySystem.p[3] ={"Tasty","Food","Area3", 0.73 , 0.06 ,i0[3] ,400};
            MySystem.p[4] ={"Stop Here","Market","Area1",0.88,0.1 ,i0[4],500};
            MySystem.p[5] ={"Good Mart","Market","Area2",0.95,0.15,i0[5],600};
            MySystem.p[6] ={"WMs","Market","Area2",0.82,0.09,i0[6],700};
            MySystem.p[7] ={"24Hours","Market","Area3",0.79,0.08,i0[7],800};
            MySystem.p[8] ={"C-Market","Market","Area1",0.92,0.14,i0[8],900};
        }
        
        public void AddItem(string ID)
        {    
           Item []t=new Item[10];
            t[0] ={"I1","Juice",4,10 };
            t[1] ={"I2" ,"Sandwich",8,30};
            t[2]={"I3" ,"Sweet",15,20};
            t[3]={"I4" ,"Steak",20,15};
            t[4]={"I5" ,"Salad",5,25};
            t[5]={"I6" ,"Hand wash",3,50};
            t[6]={"I7" ,"Spices",6,35};
            t[7]={"I8" ,"Tissues",10,70};
            t[8]={"I9" ,"Oil",7,30};
            t[9]={"I10" ,"Sanitizer",2,100};
             for(int i=0; i<10;1++)
            { 
               if(t[i].GetID==this.ID)
                  //test if it is correct (string I +int(i+1)=t[i]);
                  ID=t[i];
            }

        }
      

}
}
