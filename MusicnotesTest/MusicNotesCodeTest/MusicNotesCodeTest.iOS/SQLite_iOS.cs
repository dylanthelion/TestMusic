using MusicNotesCodeTest.code.util;
using MusicNotesCodeTest.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace MusicNotesCodeTest.iOS
{
    public class SQLite_iOS : SQLiteConn
    {
        public SQLite.Net.SQLiteConnection GetConn()
        {
            var filename = "Songs.db3";
            var docDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var library = Path.Combine(docDir, "..", "Library");
            var fullPath = Path.Combine(library, filename);
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            return new SQLite.Net.SQLiteConnection(platform, fullPath);
        }
    }
}
