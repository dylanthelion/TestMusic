using MusicNotesCodeTest.code.model;
using MusicNotesCodeTest.code.util;
using MusicNotesCodeTest.code.view;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicNotesCodeTest.code.viewmodel.Library
{
    public class LibraryViewModel
    {
        public ObservableCollection<SongModel> songs = new ObservableCollection<SongModel>();
        private SongDB db;

        public LibraryViewModel()
        {
            loadSongs();
        }

        public void loadSongs()
        {
            SongDB newDB = MainMasterDetailPage.songDB;
            db = newDB;
            if (songs.Count > 0)
            {
                songs = new ObservableCollection<SongModel>();
                return;
            }
            if (db.Songs().Count == 0)
            {
                db.loadSongsFromFile();
            }
            foreach (SongModel sm in db.Songs())
            {
                songs.Add(sm);
            }
        }

        public ObservableCollection<SongModel> GetSongs()
        {
            return songs;
        }

        public void IncrementViews(string id)
        {
            foreach (SongModel song in songs)
            {
                if(song.id == id)
                {
                    song.views++;
                    break;
                }
            }
            db.IncrementViews(id);
            
        }
    }
}
