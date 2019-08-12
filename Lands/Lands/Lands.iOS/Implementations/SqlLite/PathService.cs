using Lands.iOS.Implementations.SqlLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace Lands.iOS.Implementations.SqlLite
{
    using Lands.Interfaces.SqlLite;
    using System;
    using System.IO;
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, AppSettings.DatabaseName);
        }
    }
}