using MusicNotesCodeTest.code.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicNotesCodeTest.code.viewmodel.Song
{
    public class SongViewModel
    {
        public SongModel song { get; set; }
        ObservableCollection<object> values = new ObservableCollection<object>();
        public ObservableCollection<object> GetSongDetails()
        {
            values.Add(new
            {
                Category = "Title",
                Value = song.title
            });
            values.Add(new
            {
                Category = "Artist",
                Value = song.artist
            });
            values.Add(new
            {
                Category = "Key",
                Value = song.key
            });
            values.Add(new
            {
                Category = "Instruments",
                Value = song.instruments
            });
            values.Add(new
            {
                Category = "Pages",
                Value = song.pages.ToString()
            });
            values.Add(new
            {
                Category = "View Count",
                Value = song.views.ToString()
            });

            return values;
        }
    }
}
