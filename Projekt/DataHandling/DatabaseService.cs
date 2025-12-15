using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;
using static Projekt.DataHandling.DataService.Settings;

namespace Projekt.DataHandling
{
    public class DatabaseService
    {
        //kod ktory obsluguje zapisywanie danych w bazie SQLite
        internal class SQLite
        {
            private SQLiteAsyncConnection _database;
            private const string dbName = "ProjectDataBase.db";  // nazwa bazy danych
            private readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName); // sceiezka na ktorej znaduje sie baza


            public SQLite()
            {
                _database = new SQLiteAsyncConnection(dbPath);
            }


            // pobiera z bazy wszystkie rekordy z suplementami i zwraca w liscie
            public async Task<List<Suplement>> GetAllSupplements() => await _database.QueryAsync<Suplement>("SELECT * FROM SuplementData");


            // Kod ktory kopiuje baze danych po raz pierwszy
            public static async Task CopyDatabaseIfNeeded()
            {
                string targetPath = Path.Combine(FileSystem.AppDataDirectory, dbName); // sciezka
                //sprawdza czy plik istnieje, jeski nie kopiuje baze lokalnie
                if (!File.Exists(targetPath))
                {
                    using Stream inputStream = await FileSystem.OpenAppPackageFileAsync(dbName);
                    using FileStream outputStream = File.Create(targetPath);
                    await inputStream.CopyToAsync(outputStream);
                }
            }

            // Zmusza do skopiowania bazy
            public static async Task ForceFreshDatabase()
            {
                string targetPath = Path.Combine(FileSystem.AppDataDirectory, dbName); // sciezka

                using Stream inputStream = await FileSystem.OpenAppPackageFileAsync(dbName);
                using FileStream outputStream = File.Create(targetPath);
                await inputStream.CopyToAsync(outputStream);
            }
        }




        // kod ktory obslugije zapisywanie danych w pliku json
        internal class JSON
        {
            //klasa ktora obsluguje ustawienia aplikacji
            internal class Settings
            {
                private static string settingsPath = Path.Combine(FileSystem.AppDataDirectory, "settings.json");

                // Save current settings to JSON
                public static async Task SaveSettingsAsync()
                {
                    try
                    {
                        // tworzy instancje, pobiera dane z dataservice
                        var settingsData = new DataService.Settings.SettingsData
                        {
                            NotificationEnabled = DataService.Settings.NotificationEnabled,
                            Language = DataService.Settings.Language,
                            Theme = DataService.Settings.Theme,
                            SearchInfoOnInternet = DataService.Settings.SearchInfoOnInternet
                        };

                        // wpisuje dane instancje do pliku
                        string json = JsonSerializer.Serialize(settingsData, new JsonSerializerOptions { WriteIndented = true });
                        await File.WriteAllTextAsync(settingsPath, json);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to save settings: {ex.Message}"); // wylapie potencjalne bledy
                    }
                }

                // Load settings from JSON
                public static async Task LoadSettingsAsync()
                {
                    if (!File.Exists(settingsPath))
                    {
                        Console.WriteLine("Plik nie istnieje");
                        return;
                    }

                    try
                    {
                        string json = await File.ReadAllTextAsync(settingsPath);
                        var settingsData = JsonSerializer.Deserialize<DataService.Settings.SettingsData>(json);
                        if (settingsData != null)
                        {
                            DataService.Settings.NotificationEnabled = settingsData.NotificationEnabled;
                            DataService.Settings.Language = settingsData.Language;
                            DataService.Settings.Theme = settingsData.Theme;
                            DataService.Settings.SearchInfoOnInternet = settingsData.SearchInfoOnInternet;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to load settings: {ex.Message}"); // wylapie potencjalne bledy
                    }
                }

                public static async Task CopyDatabaseIfNeeded()
                {
                    if (!File.Exists(settingsPath))
                    {
                        var defaultSettings = new SettingsData();
                        string json = JsonSerializer.Serialize(defaultSettings, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(settingsPath, json);

                        await SaveSettingsAsync();
                    }
                }

                public static void ResetSettings()
                {
                    var defaultSettings = new SettingsData();
                    string json = JsonSerializer.Serialize(defaultSettings, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(settingsPath, json);
                }

                public static void QuickLoad() => Task.Run(async () => await DatabaseService.JSON.Settings.LoadSettingsAsync());
                public static void QuickSave() => Task.Run(async () => await DatabaseService.JSON.Settings.SaveSettingsAsync());
            }
            







            internal class Notifications
            {
                private static string notificationsPath = Path.Combine(FileSystem.AppDataDirectory, "notifications.json");

                // Zapisuje listę powiadomień do pliku json
                public static async Task SaveNotificationsAsync()
                {
                    try
                    {
                        // Pobieramy listę powiadomień z DataService
                        var notifications = DataService.Notifications.list.ToList();
                        string json = JsonSerializer.Serialize(notifications, new JsonSerializerOptions { WriteIndented = true });
                        await File.WriteAllTextAsync(notificationsPath, json);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to save notifications: {ex.Message}");
                    }
                }

                // Wczytuje listę powiadomień z pliku json
                public static async Task LoadNotificationsAsync()
                {
                    if (!File.Exists(notificationsPath))
                    {
                        Console.WriteLine("Plik powidomien nie istnieje.");
                        return;
                    }

                    try
                    {
                        string json = await File.ReadAllTextAsync(notificationsPath);
                        var loadedNotifications = JsonSerializer.Deserialize<List<Notif>>(json);

                        if (loadedNotifications != null)
                        {
                            // Aktualizujemy listę w DataService
                            DataService.Notifications.list.Clear();
                            foreach (var notif in loadedNotifications)
                            {
                                DataService.Notifications.list.Add(notif);
                                //Console.WriteLine(notif.suplement.name + "");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to load notifications: {ex.Message}");
                    }
                }

                // Tworzy plik z domyślną pustą listą, jeśli nie istnieje
                public static async Task CopyDatabaseIfNeeded()
                {
                    if (!File.Exists(notificationsPath))
                    {
                        var defaultNotifications = new ObservableCollection<Notif>();
                        string json = JsonSerializer.Serialize(defaultNotifications, new JsonSerializerOptions { WriteIndented = true });
                        await File.WriteAllTextAsync(notificationsPath, json);
                    }
                }

                // Metody szybkiego zapisu/odczytu (opcjonalnie)
                public static void QuickSave() => Task.Run(async () => await SaveNotificationsAsync());
                public static void QuickLoad() => Task.Run(async () => await LoadNotificationsAsync());
            }
        }
    }
}