using MusicNotesCodeTest.code.viewmodel.Song;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MusicNotesCodeTest.code.view.Song
{
    public partial class SongPage : ContentPage
    {
        ObservableCollection<object> values = new ObservableCollection<object>();
        public SongPage(SongViewModel songViewModel)
        {
            InitializeComponent();
            SetSongDetails(songViewModel);
            songDetails.ItemsSource = values;
            this.Title = songViewModel.song.id;
        }

        public void SetSongDetails(SongViewModel svm)
        {
            values.Add(new 
            {
                Category = "Title",
                Value = svm.song.title
            });
            values.Add(new
            {
                Category = "Artis",
                Value = svm.song.artist
            });
            values.Add(new
            {
                Category = "Key",
                Value = svm.song.key
            });
            values.Add(new
            {
                Category = "Instruments",
                Value = svm.song.instruments
            });
            values.Add(new
            {
                Category = "Pages",
                Value = svm.song.pages.ToString()
            });
            values.Add(new
            {
                Category = "View Count",
                Value = svm.song.views.ToString()
            });
        }
    }
}
