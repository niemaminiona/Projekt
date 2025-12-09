using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    public static class DataService
    {
        internal class Suplements
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

            public static int SelectedInfoIndex = 0;
        }

        internal class Notifications
        {
            public static ObservableCollection<Notif> list = new();

            public static void AddRandomNotif()
            {
                if (DataService.Suplements.list.Any())
                {
                    list.Add(new Notif(new Suplement(new Random().Next(DataService.Suplements.list.Count)), 3, DateTime.Now));
                }
            }
        }

        internal class Settings
        {
            public static bool NotificationEnabled = true;
            public static int Language = 0;
            public static int Theme = 0;
            public static bool SearchInfoOnInternet = false;
        }
    }
}
