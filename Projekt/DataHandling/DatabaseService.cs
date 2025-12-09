using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;
        private const string dbName = "ProjectDataBase.db";
        public DatabaseService()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);
            _database = new SQLiteAsyncConnection(dbPath);
        }


        // pobiera z bazy wszystkie rekordy z suplementami i zwraca w liscie
        public async Task<List<Suplement>> GetAllSupplements() => await _database.QueryAsync<Suplement>("SELECT * FROM SuplementData");


        // Kod ktory kopiuje baze danych po raz pierwszy
        public static async Task CopyDatabaseIfNeeded()
        {
            string targetPath = Path.Combine(FileSystem.AppDataDirectory, dbName);

            if (!File.Exists(targetPath))
            {
                using Stream inputStream = await FileSystem.OpenAppPackageFileAsync(dbName);
                using FileStream outputStream = File.Create(targetPath);
                await inputStream.CopyToAsync(outputStream);
            }
        }

        // Zmusza do odswierzenia bazy 
        public static async Task ForceFreshDatabase()
        {
            string targetPath = Path.Combine(FileSystem.AppDataDirectory, dbName);

            using Stream inputStream = await FileSystem.OpenAppPackageFileAsync(dbName);
            using FileStream outputStream = File.Create(targetPath);
            await inputStream.CopyToAsync(outputStream);
        }
    }
}