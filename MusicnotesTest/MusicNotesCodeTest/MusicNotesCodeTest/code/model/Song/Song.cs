using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicNotesCodeTest.code.model
{
    class Song
    {
        public string id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string key { get; set; }
        public string instruments { get; set; }
        public int pages { get; set; }
    }
}
