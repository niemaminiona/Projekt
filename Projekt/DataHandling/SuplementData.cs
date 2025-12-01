using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    internal class SuplementData
    {
        public static ObservableCollection<Suplement> list = new()
        {
            new Suplement("Magnessium"),
            new Suplement("Creatine"),
            new Suplement("Omega 3"),
            new Suplement("Colagen"),
            new Suplement("Ashwaganda"),
            new Suplement("Melatonin")
        };

    }
}
