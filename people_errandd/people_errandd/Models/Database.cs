using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace people_errandd.Models
{
    class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database(string dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<Records>().Wait();
        }

        public Task<List<Records>> GetRecordsAsync()
        {
            return _database.Table<Records>().ToListAsync();
        }
        public Task<int> SaveRecordAsync(Records records)
        {
            return _database.InsertAsync(records);
        }
    }
}
