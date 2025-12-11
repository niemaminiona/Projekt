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
        private static DatabaseService _database = new();



        // klasa Suplements ////////////////////////
        internal class Suplements
        {
            public static ObservableCollection<Suplement> list = new();
            

            public static async Task LoadSupplements()
            {
                var supplements = await _database.GetAllSupplements();
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
            private static ObservableCollection<Notif> _list = new();

            public static ObservableCollection<Notif> list
            {
                get
                {
                    Console.WriteLine("downloads list from database");
                    return _list;
                }
                set
                {
                    _list = value;
                }
            }

            static Notifications()
            {
                _list.CollectionChanged += (s, e) =>
                {
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            var added = (Notif)e.NewItems[0]!;
                            Console.WriteLine($"Dodano: {added.suplement.name}, indeks: {e.NewStartingIndex}");
                            // tu twój kod dla dodawania
                            break;

                        case NotifyCollectionChangedAction.Remove:
                            var removed = (Notif)e.OldItems[0]!;
                            Console.WriteLine($"Usunięto: {removed.suplement.name}, indeks: {e.OldStartingIndex}");
                            // tu twój kod dla usuwania
                            break;
                    }
                };
            }

            public static void AddRandomNotif()
            {
                if (DataService.Suplements.list.Any())
                {
                    list.Add(new Notif(new Suplement(new Random().Next(DataService.Suplements.list.Count)), 3, DateTime.Now));
                }
            }
        }



        // klasa Settings ////////////////////////
        internal class Settings
        {
            public static bool NotificationEnabled = true;
            public static int Language = 0;
            public static int Theme = 0;
            public static bool SearchInfoOnInternet = false;

            [Table("AppSettings")]
            public class SettingsModel
            {
                [PrimaryKey]
                public int Id { get; set; } = 1; // Always 1 for single settings record

                public bool NotificationEnabled { get; set; } = true;
                public int Language { get; set; } = 0;
                public int Theme { get; set; } = 0;
                public bool SearchInfoOnInternet { get; set; } = false;
            }
        }
    }
}
