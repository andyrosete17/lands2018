namespace Lands.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataService
    {
        private readonly SqlLiteService sqlLiteService;
        public DataService()
        {
            this.sqlLiteService = new SqlLiteService();
        }
        public async Task<bool> DeleteAll<T>() where T : new()
        {
            try
            {
                var oldRecords = this.sqlLiteService.GetAll<T>(false) as IEnumerable<T>;
                if (oldRecords != null)
                {
                    foreach (var oldRecord in oldRecords)
                    {
                        await this.sqlLiteService.DeleteAsync(oldRecord);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        public async Task<T> DeleteAllAndInsert<T>(T model) where T : new()
        {
            try
            {
                var oldRecords = this.sqlLiteService.GetAll<T>(false) as IEnumerable<T>;
                if (oldRecords != null)
                {
                    foreach (var oldRecord in oldRecords)
                    {
                        await this.sqlLiteService.DeleteAsync(oldRecord);
                    }
                }
                await this.sqlLiteService.Insert(model);

                return model;

            }
            catch (Exception ex)
            {
                ex.ToString();
                return model;
            }
        }

        public async Task<T> InsertOrUpdate<T>(T model) where T : new()
        {
            try
            {
                var oldRecord = await this.sqlLiteService.Find<T>(model.GetHashCode(), false);
                if (oldRecord != null)
                {
                    await this.sqlLiteService.Update(model);
                }
                else
                {
                    await this.sqlLiteService.Insert(model);
                }

                return model;

            }
            catch (Exception ex)
            {
                ex.ToString();
                return model;
            }
        }

        public async Task<T> Insert<T>(T model)
        {
            await this.sqlLiteService.Insert(model);
            return model;
        }

        public async Task<T> Find<T>(int pk, bool withChildren) where T : new()
        {
            return await this.sqlLiteService.Find<T>(pk, withChildren);
        }

        public async Task<T> First<T>(bool withChildren) where T : new()
        {
            var oldRecords = await this.sqlLiteService.GetAll<T>(withChildren) as IEnumerable<T>;
            return oldRecords.FirstOrDefault();
        }

        public async Task<List<T>> Get<T>(bool withChildren) where T : new()
        {
            var oldRecords = await this.sqlLiteService.GetAll<T>(withChildren) as IEnumerable<T>;
            return oldRecords.ToList();
        }

        public async void Update<T>(T model)
        {
            await this.sqlLiteService.Update(model);
        }

        public async void Delete<T>(T model)
        {
            await this.sqlLiteService.DeleteAsync(model);
        }

        public async void Save<T>(List<T> list) where T : new()
        {
            foreach (var record in list)
            {
                await InsertOrUpdate(record);
            }
        }
    }
}
