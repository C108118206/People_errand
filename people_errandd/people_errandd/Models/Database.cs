﻿using System;
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
            _database.CreateTableAsync<WorkRecordModels>().Wait();
            _database.CreateTableAsync<DayOffRecordModels>().Wait();
            _database.CreateTableAsync<GoOutRecordModels>().Wait();
        }

        public Task<List<WorkRecordModels>> GetWorkRecordsAsync()
        {
            return _database.Table<WorkRecordModels>().ToListAsync();
        }       
        public Task<int> SaveRecordAsync(WorkRecordModels records)
        {
            return _database.InsertAsync(records);
        }
        public Task<List<DayOffRecordModels>> GetDayOffRecordsAsync()
        {
            return _database.Table<DayOffRecordModels>().ToListAsync();
        }
        public Task<int> SaveRecordAsync(DayOffRecordModels records)
        {
            return _database.InsertAsync(records);
        }
        public Task<List<GoOutRecordModels>> GetGoOutRecordsAsync()
        {
            return _database.Table<GoOutRecordModels>().ToListAsync();
        }
        public Task<int> SaveRecordAsync(GoOutRecordModels records)
        {
            return _database.InsertAsync(records);
        }
    }
}
