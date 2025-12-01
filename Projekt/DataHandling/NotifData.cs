using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace Projekt.DataHandling
{
    public class NotifData
    {
        //private static readonly string _fileName = Path.Combine(FileSystem.AppDataDirectory, "NotifData.json");
        public static ObservableCollection<Notif> list = new();

        public static void AddRandomNotif()
        {
            if (SuplementData.list.Any())
            {
                list.Add(new Notif(new Suplement(new Random().Next(SuplementData.list.Count)), 3, DateTime.Now));
            }
            
        }

        // Copy the JSON file from the package to AppDataDirectory if needed
        //private static async Task CopyIfNotExists()
        //{
        //    if (!File.Exists(_fileName))
        //    {
        //        using var stream = await FileSystem.OpenAppPackageFileAsync("DataHandling/NotifData.json");
        //        using var fileStream = File.Create(_fileName);
        //        await stream.CopyToAsync(fileStream);
        //    }
        //}

        //public static async Task Save()
        //{
        //    await CopyIfNotExists();  // ensure file exists
        //    string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
        //    await File.WriteAllTextAsync(_fileName, json); // writes to writable AppDataDirectory
        //}

        //public static async Task Refresh()
        //{
        //    await CopyIfNotExists();
        //    string json = await File.ReadAllTextAsync(_fileName);
        //    list = JsonSerializer.Deserialize<List<Notif>>(json) ?? new List<Notif>();
        //}
    }
}
