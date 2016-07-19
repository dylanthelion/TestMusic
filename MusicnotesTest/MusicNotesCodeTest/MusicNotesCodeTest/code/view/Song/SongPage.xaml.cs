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
            values = songViewModel.GetSongDetails();
            songDetails.ItemsSource = values;
            this.Title = songViewModel.song.id;
        }
    }
}
