using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace people_errandd.Models
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database(string dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<RecordModels>().Wait();
        }

        public Task<List<RecordModels>> GetRecordsAsync()
        {
            return _database.Table<RecordModels>().ToListAsync();
        }
        public Task<int> SaveRecordAsync(RecordModels records)
        {
            return _database.InsertAsync(records);
        }
    }
}
