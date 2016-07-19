using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicNotesCodeTest.code.model
{
    class SongModel
    {
        public string id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string key { get; set; }
        public string instruments { get; set; }
        public int pages { get; set; }
        public int views { get; set; }
        public string longDescription
        {
            get
            {
                return String.Format("Artist: {0} | View Count: {1} | Pages: {2}", this.artist, this.views.ToString(), this.pages);
            }
        }
    }
}
