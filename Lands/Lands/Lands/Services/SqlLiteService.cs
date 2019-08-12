namespace Lands.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Lands.Helpers;
    using Lands.Interfaces;
    using Lands.Interfaces.SqlLite;
    using Lands.Models;
    using SQLite;
    using SQLiteNetExtensionsAsync.Extensions;
    using Xamarin.Forms;

    public class SqlLiteService : ISqlLiteService
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private SQLiteAsyncConnection _sqlCon;

        //public DataAccess()
        //{
        //    //DependencyService indica como se debe comportar tanto en android como en IOS
        //    var config = DependencyService.Get<IConfig>();
        //    var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Lands.db3");
        //    this.connection = new SQLiteConnection(
        //        config.Platform,
        //        Path.Combine(config.DirectoryDB, "Lands.db3"));
        //    //this.connection = new SQLiteConnection(databasePath);
        //    //connection.CreateTable<UserLocal>();
        //}

        public SqlLiteService()
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            _sqlCon = new SQLiteAsyncConnection(databasePath);

            CreateDatabaseAsync();
        }

        public async void CreateDatabaseAsync()
        {
            await _sqlCon.CreateTableAsync<UserLocal>(CreateFlags.None).ConfigureAwait(false);
        }

        public async Task DeleteAsync<T>(T item)
        {
            await _sqlCon.DeleteAsync(item);
        }

        public async Task<T> Find<T>(int pk, bool WithChildren) where T : new()
        {
            var value = _sqlCon.Table<T>().FirstOrDefaultAsync(m => m.GetHashCode() == pk);
            if (WithChildren)
            {
                return await _sqlCon.FindWithChildrenAsync<T>(value, WithChildren);
            }
            else
            {
                return await value;
            }
        }

        public async Task<T> First<T>(bool WithChildren)  where T : new()
        {
            if (WithChildren)
            {
                var values =  await _sqlCon.GetAllWithChildrenAsync<T>();
                return values.FirstOrDefault();
            }
            else
            {
                return await _sqlCon.Table<T>().FirstOrDefaultAsync();
            }
        }

        public async Task<List<T>> GetAll<T>(bool WithChildren) where T : new()
        {
            if (WithChildren)
            {
                return await _sqlCon.GetAllWithChildrenAsync<T>();
            }
            else
            {
                return await _sqlCon.Table<T>().ToListAsync();
            }
        }

        public async Task Insert<T>(T item)
        {
            await this._sqlCon.InsertAsync(item);
        }

        public async Task Update<T>(T item)
        {
           await this._sqlCon.UpdateAsync(item);
        }
    }
}
