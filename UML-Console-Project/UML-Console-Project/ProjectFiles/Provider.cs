using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UML_Console_Project.ProjectFiles
{
    class Provider
    {
        //hi islam
        //this is shatha's work she was trying to understand some concept 
        //feel free to delete it or change it 
        //but try to get shatha updated about the way you wanna change it or rewrite it
        //<jebril>

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

        /*void AddInitialData()
        {
            MySystem.c[0]={ };
            MySystem.storefiles();
        }
        */

}
}
