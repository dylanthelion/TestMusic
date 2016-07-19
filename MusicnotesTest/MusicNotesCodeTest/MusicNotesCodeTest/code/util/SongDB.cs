using MusicNotesCodeTest.code.model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace MusicNotesCodeTest.code.util
{
    public class SongDB
    {
        private SQLiteConnection conn;

        public SongDB()
        {
            conn = DependencyService.Get<SQLiteConn>().GetConn();
            conn.CreateTable<SongModel>();
        }

        public List<SongModel> Songs()
        {
            return (from check in conn.Table<SongModel>()
                    select check).ToList();
        }

        public SongModel GetBy(string id)
        {
            return (from check in conn.Table<SongModel>()
                    where check.id == id
                    select check).FirstOrDefault();
        }

        public void IncrementViews(string id)
        {
            SongModel old = (from check in conn.Table<SongModel>()
                             where check.id == id
                             select check).FirstOrDefault();
            old.views++;
            conn.Update(old);
        }

        public void Seed(List<SongModel> songs)
        {
            foreach(SongModel sm in songs)
            {
                conn.Insert(sm);
            }
        }

        public void loadSongsFromFile()
        {
            XDocument songsFromFile = XDocument.Load("songs.xml");
            var query = songsFromFile.Descendants("songs").Descendants("song").Select(x => new SongModel
            {
                id = (string)x.Element("id"),
                title = (string)x.Element("title"),
                artist = (string)x.Element("artist"),
                key = (string)x.Element("key"),
                instruments = (string)x.Element("instruments"),
                pages = (int)x.Element("pages"),
                views = 0
            }).ToList();
            Seed(query);
        }
    }
}
