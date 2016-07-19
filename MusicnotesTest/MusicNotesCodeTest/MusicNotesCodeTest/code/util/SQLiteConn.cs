using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicNotesCodeTest.code.util
{
    public interface SQLiteConn
    {
        SQLiteConnection GetConn();
    }
}
