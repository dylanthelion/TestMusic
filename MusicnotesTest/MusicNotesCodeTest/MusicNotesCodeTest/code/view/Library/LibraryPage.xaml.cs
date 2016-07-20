using MusicNotesCodeTest.code.model;
using MusicNotesCodeTest.code.util;
using MusicNotesCodeTest.code.view.Song;
using MusicNotesCodeTest.code.viewmodel.Library;
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
        LibraryViewModel viewModel = new LibraryViewModel();
        public LibraryPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
            songList.ItemsSource = viewModel.songs;
            songList.ItemSelected += OnSelection;
        }

        public void OnSelection (object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }
            SongModel sm = (SongModel)e.SelectedItem;
            sm.views++;
            viewModel.IncrementViews(sm.id);
            viewModel.loadSongs();

            SongViewModel svm = new SongViewModel();
            svm.song = sm;
            SongPage newPage = new SongPage(svm);
            newPage.Title = svm.song.id;
            
            Navigation.PushAsync(newPage);
        }
    }
}
