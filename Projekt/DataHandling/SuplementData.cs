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
            new Suplement("Magnessium", "Some type test of description"),
            new Suplement("Creatine"),
            new Suplement("Omega 3"),
            new Suplement("Colagen"),
            new Suplement("Ashwaganda"),
            new Suplement("Melatonin"),
            new Suplement("Zinc"),
            new Suplement("Iron"),
            new Suplement("Vitamin D3"),
            new Suplement("Vitamin B12"),
            new Suplement("Potassium"),
            new Suplement("Protein"),
        };
        public static int SelectedInfoIndex = 0;
    }
}
