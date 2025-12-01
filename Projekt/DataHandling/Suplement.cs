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
        public String description { set; get; }
        private int id;

        // konstruktory ktore ustawiaja domyslny opis na "info about" i nazwe
        public Suplement(String name) : this(name, "Info about " + name) { }
        public Suplement(int index) : this(index, "Info about " + SuplementData.list.ElementAt(index).name) { }
        
        // normalne konstruktory
        public Suplement(String name, String description)
        {
            this.id = numberofInstances;
            numberofInstances++;
            this.name = name;
            this.description = description;
        }

        public Suplement(int index, String description)
        {
            if (index >= 0 && index < SuplementData.list.Count && SuplementData.list.Any())
            {
                this.id = numberofInstances;
                numberofInstances++;
                this.name = SuplementData.list.ElementAt(index).name;
                this.description = description;
            }
        }

        public int getId() => id;
    }
}
