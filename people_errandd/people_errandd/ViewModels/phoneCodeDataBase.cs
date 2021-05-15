using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using people_errandd.Models;
using System.Threading.Tasks;

namespace people_errandd.ViewModels
{
    public class phoneCodeDataBase
    {
        readonly SQLiteAsyncConnection _database;
        public phoneCodeDataBase(string dbPath)
        {
            //若不存在則 自動建立資料庫的寫法
            //若已經存在則自動載入 資料庫
            _database = new SQLiteAsyncConnection(dbPath);
            //CreateTableAsync在不存在此資料表的時候就會建立
            //已存在的時候則是什麼都不做
            //Wait()強制等待這行指令執行完畢
            _database.CreateTableAsync<work>().Wait();
        }

        //public Task<List<item>> GetNotesAsync()
        //{
        //    //ToListAsync再次強調，非同步執行在app的重要性
        //    return _database.Table<item>().ToListAsync();
        //}
        //public Task<work> GetNoteAsync(int id)
        //{

        //    //return _database.QueryAsync<item>("SELECT MAX(ID) FROM [item]");
        ////    return _database.Table<work>()
        ////                    .Where(i => i.ID == id)
        ////                    //記得用async版本的FirstOrDefaultAsync()
        ////                    //寫app的非同步很重要
        ////                    .FirstOrDefaultAsync();
        ////}
        ////public Task<int> GetMaxId()
        ////{
         
        //}
        public Task<int> SaveNoteAsync(work work)
        {
            return _database.InsertAsync(work);
        }


    }
}
