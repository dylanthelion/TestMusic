using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicNotesCodeTest.code.model.Flyout
{
    public class FlyoutMenuModel
    {
        public string Title { get; set; }
        public ImageSource IconSource { get; set; }
        public Type TargetType { get; set; }
    }
}
