using MusicNotesCodeTest.code.model;
using MusicNotesCodeTest.code.util;
using MusicNotesCodeTest.code.view.Song;
using MusicNotesCodeTest.code.viewmodel.Song;
using Org.XmlPull.V1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Windows.Data.Xml.Dom;
using Xamarin.Forms;

namespace MusicNotesCodeTest.code.view.Library
{
    public partial class LibraryPage : ContentPage
    {
        ObservableCollection<SongModel> songs = new ObservableCollection<SongModel>();
        private SongDB db;
        //public string[] songs;
        public LibraryPage()
        {
            SongDB newDB = MainMasterDetailPage.songDB;
            db = newDB;
            if(db.Songs().Count == 0)
            {
                loadSongsFromFile();
            }
            else
            {
                foreach(SongModel sm in db.Songs())
                {
                    songs.Add(sm);
                }
            }
            InitializeComponent();
            songList.ItemsSource = songs;
            songList.ItemSelected += OnSelection;
            Debug.WriteLine("Populated");
        }

        public void OnSelection (object sender, SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("Did select");
            if(e.SelectedItem == null)
            {
                return;
            }
            Debug.WriteLine("HERP");
            SongModel sm = (SongModel)e.SelectedItem;
            SongViewModel svm = new SongViewModel();
            svm.song = sm;
            SongPage newPage = new SongPage(svm);
            db.IncrementViews(svm.song.id);
            newPage.Title = svm.song.id;
            Navigation.PushAsync(newPage);
        }

        private void loadSongsFromFile()
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
            foreach(SongModel s in query)
            {
                songs.Add(s);
            }
            db.Seed(query);
        }
    }
}
