using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    public static class DataService
    {
        private static DatabaseService.SQLite _databaseSQL = new(); // tworzy polaczenie z baza sql

        // klasa Suplements ////////////////////////
        internal class Suplements
        {
            public static ObservableCollection<Suplement> list = new();
            

            public static async Task LoadSupplements()
            {
                var supplements = await _databaseSQL.GetAllSupplements();
                list.Clear();

                foreach (var sup in supplements)
                {
                    list.Add(sup);
                }
            }


            public static int SelectedInfoIndex = 0;
        }




        // klasa Notifications ////////////////////////
        internal class Notifications
        {
            public static List<Notif> list = new();

            public static async Task LoadNotifications()
            {
                await DatabaseService.JSON.Notifications.LoadNotificationsAsync();
            }

            public static void AddRandomNotif()
            {
                if (DataService.Suplements.list.Any())
                {
                    list.Add(new Notif(new Suplement(new Random().Next(DataService.Suplements.list.Count)), new Random().Next(10), new DateTime(DateTime.Now.Year, DateTime.Now.Month, new Random().Next(20) + 1)));
                }
            }
        }



        // klasa Settings ////////////////////////
        internal class Settings
        {
            public static bool NotificationEnabled { get; set; } = true;
            public static int Language { get; set; } = 0;
            public static int Theme { get; set; } = 0;
            public static bool SearchInfoOnInternet { get; set; } = false;

            // klasa pomocniczna dla databaseService (jesli dodajesz zmienna, dodaj ja w oby miejscach)
            internal class SettingsData
            {
                public bool NotificationEnabled { get; set; }
                public int Language { get; set; }
                public int Theme { get; set; }
                public bool SearchInfoOnInternet { get; set; }
            }
        }
    }
}
