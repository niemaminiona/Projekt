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
        public static ObservableCollection<Suplement> list = new();
        private static DatabaseService _db = new DatabaseService();

        public static async Task LoadSupplements()
        {
            Console.WriteLine("Before sql question <1--------------");
            var supplements = await _db.GetAllSupplements();
            if (!supplements.Any())
            {
                Console.WriteLine("The list is empty <2---------------------------------");
            }
            else
            {
                Console.WriteLine("Something is in list: ");
                Console.WriteLine(supplements);
            }
                list.Clear();

            foreach (var sup in supplements)
            {
                list.Add(sup);
            }
        }

        //{
        //    new Suplement("Ashwaganda"),
        //    new Suplement("Melatonin"),
        //    new Suplement("Zinc"),
        //    new Suplement("Iron"),
        //    new Suplement("Vitamin D3"),
        //    new Suplement("Vitamin B12"),
        //    new Suplement("Potassium"),
        //    new Suplement("Protein"),
        //};
        public static int SelectedInfoIndex = 0;
    }
}
