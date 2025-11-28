using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    public class Data
    {
        public static List<Notif> GetListTest(){
            List<Notif> list = new();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Notif(new Suplement("Magnesium"), 1, new DateTime(2025, 8, 25), new Random().Next(2) == 0));
            }
            return list;
        }
    }
}
