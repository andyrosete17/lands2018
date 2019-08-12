using Lands.Droid.Implementations.SqlLite;
using Lands.Interfaces.SqlLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace Lands.Droid.Implementations.SqlLite
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppSettings.DatabaseName);
        }
    }
}