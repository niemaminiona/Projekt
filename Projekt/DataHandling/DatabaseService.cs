using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DataHandling
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;
        public DatabaseService()
        {
            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "supplements.db");
                _database = new SQLiteAsyncConnection(dbPath);

                // Create tables if they don't exist
                await _database.CreateTableAsync<Suplement>();
                //await _database.CreateTableAsync<Notif>();
            }
        }
    }
}
