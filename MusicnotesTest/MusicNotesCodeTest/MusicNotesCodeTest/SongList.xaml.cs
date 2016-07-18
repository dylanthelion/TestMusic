using MusicNotesCodeTest.code.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MusicNotesCodeTest
{
    public partial class SongList : ContentPage
    {
        ObservableCollection<Song> songs = new ObservableCollection<Song>();

        public SongList()
        {
            InitializeComponent();
            Load();
            SongView.ItemsSource = songs;
        }

        private void Load()
        {
            Song s = new Song();
            s.title = "Song One";
            Song s2 = new Song();
            s2.title = "Song Two";
            songs.Add(s);
            songs.Add(s2);
        }
    }
}
