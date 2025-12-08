using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            _database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DataHandling","ProjectDataBase.db"));
        }

        // Just one method - gets all data from SuplementData table
        public async Task<List<Suplement>> GetAllSupplements()
        {
            // Use raw SQL to get data from SuplementData table
            var supplements = await _database.QueryAsync<Suplement>("SELECT * FROM SuplementData");
            return supplements;
        }
    }
}