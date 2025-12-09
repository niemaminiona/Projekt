using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    [Table("SuplementData")]
    public class Suplement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        // konstruktory ktore ustawiaja domyslny opis na "info about" i nazwe
        public Suplement(String name) : this(name, "Info about " + name) { }
        // konstruktor ktory wybiera po indexie
        public Suplement(int index) : this(index, "Info about " + SuplementData.list.ElementAt(index).name) { }
        
        // normalne konstruktory
        public Suplement(String name, String Description)
        {
            this.name = name;
            this.description = Description;
        }

        // konstruktor ktory wybiera po indexie
        public Suplement(int index, String Description)
        {
            if (index >= 0 && index < SuplementData.list.Count && SuplementData.list.Any())
            {
                this.name = SuplementData.list.ElementAt(index).name;
                this.description = Description;
            }
        }

        // Wymagane dla SQLite
        public Suplement() { }
    }
}
