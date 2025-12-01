using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    public class Suplement
    {
        private static int numberofInstances = 0;

        public String name;
        private int id;
        public Suplement(String name)
        {
            this.id = numberofInstances;
            numberofInstances++;
            this.name = name;
        }

        public Suplement(int index)
        {
            if(index >= 0 && index < SuplementData.list.Count)
            {
                this.name = SuplementData.list.ElementAt(index).name;
            }
        }

        public int getId() => id;
    }
}
