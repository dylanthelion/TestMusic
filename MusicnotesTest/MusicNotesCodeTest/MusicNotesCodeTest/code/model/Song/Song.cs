using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicNotesCodeTest.code.model
{
    public class SongModel : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int SQLiteID { get; set; }
        public string id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string key { get; set; }
        public string instruments { get; set; }
        public int pages { get; set; }
        private int Views;
        public int views {
            get { return Views; }
            set
            {
                if(Views != value)
                {
                    Views = value;
                    OnPropertyChanged(this, "longDescription");
                }
            }
        }
        public string longDescription
        {
            get
            {
                return String.Format("Artist: {0} | View Count: {1} | Pages: {2}", this.artist, this.views.ToString(), this.pages);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(object sender, string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
