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
            var supplements = await _db.GetAllSupplements();
            list.Clear();

            foreach (var sup in supplements)
            {
                list.Add(sup);
            }
        }

        //{
        //    new Suplement("Magnessium", ""),
        //    new Suplement("Creatine", "Creatine is a naturally occurring compound found in muscles and some foods (like meat and fish) that helps produce energy during high-intensity, short-duration activities. It boosts strength, power, and exercise performance by replenishing ATP, the body’s energy currency. Creatine also supports muscle growth, recovery, and brain function, making it popular as a supplement for athletes and fitness enthusiasts."),
        //    new Suplement("Omega 3", "Omega-3 fatty acids are essential polyunsaturated fats found in fatty fish, flaxseeds, chia seeds, and walnuts. They support heart and brain health, reduce inflammation, improve blood lipid levels, and promote healthy vision and joint function. Omega-3s are vital for overall health, especially cardiovascular and cognitive well-being."),
        //    new Suplement("Colagen", "Collagen is the most abundant protein in the body, forming the structural framework of skin, bones, tendons, ligaments, and cartilage. It provides strength, elasticity, and support to tissues, promotes healthy joints, and helps maintain skin firmness. Collagen production naturally declines with age, making supplementation beneficial for skin and joint health."),
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
