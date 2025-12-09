using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace Projekt.DataHandling
{
    public class NotifData
    {
        public static ObservableCollection<Notif> list = new();

        public static void AddRandomNotif()
        {
            if (SuplementData.list.Any())
            {
                list.Add(new Notif(new Suplement(new Random().Next(SuplementData.list.Count)), 3, DateTime.Now));
            }
            
        }
    }
}
