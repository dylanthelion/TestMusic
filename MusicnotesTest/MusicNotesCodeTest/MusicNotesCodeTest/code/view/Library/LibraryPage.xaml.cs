using MusicNotesCodeTest.code.model;
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
        //public string[] songs;
        public LibraryPage()
        {
            InitializeComponent();
            loadSongs();
            loadSongsFromFile();
            songList.ItemsSource = songs;
            Debug.WriteLine("Populated");
        }

        void OnSelection (object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }
            Debug.WriteLine("HERP");
            DisplayAlert("Select: ", e.SelectedItem.ToString(), "OK");
        }

        private void loadSongs()
        {
            SongModel s = new SongModel();
            s.title = "Song One";
            SongModel s2 = new SongModel();
            s2.title = "Song Two";
            songs = new ObservableCollection<SongModel>() { s, s2 };
            Debug.WriteLine("Songs loaded");
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
        }
    }
}
