namespace Lands.Backend.Models
{
    using Lands.Domain;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<User> Users { get; set; }
    }
}