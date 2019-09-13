using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Foundation;
using SakkeFutbol.Data;
using SakkeFutbol.iOS.Data;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_IOS))]

namespace SakkeFutbol.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {
        public SQLite_IOS() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "SakkeDB.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}