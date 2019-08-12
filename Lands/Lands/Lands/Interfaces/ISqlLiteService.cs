namespace Lands.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISqlLiteService
    {
        Task<List<T>> GetAll<T>(bool WithChildren) where T : new();
        Task Insert<T>(T item);
        Task DeleteAsync<T>(T item);
        Task Update<T>(T item);
        Task<T> First<T>(bool WithChildren) where T : new();
        Task<T> Find<T>(int pk, bool WithChildren) where T : new();
    }
}
