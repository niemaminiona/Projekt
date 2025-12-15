using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    public class Notif
    {
        private static int numberofInstances = 0;

        public int Id;
        public Suplement suplement;
        public int amount;
        public DateTime date;
        public Boolean toggled;

        public Notif(Suplement suplement, int amount, DateTime date, Boolean toggled = true)
        {
            this.Id = numberofInstances;
            this.suplement = suplement;
            this.amount = amount;
            this.date = date;
            this.toggled = toggled;
            numberofInstances++;
        }

        // Konstruktor potrzebny do deserializacji JSON
        public Notif() { }
    }    
}
