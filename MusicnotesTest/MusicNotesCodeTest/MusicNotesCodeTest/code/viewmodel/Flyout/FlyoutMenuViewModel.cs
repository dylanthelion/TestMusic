using System.Collections.Generic;
using MusicNotesCodeTest.code.model.Flyout;
using MusicNotesCodeTest.code.view.Folders;
using MusicNotesCodeTest.code.view.Help;
using MusicNotesCodeTest.code.view.Library;
using MusicNotesCodeTest.code.view.SetList;
using MusicNotesCodeTest.code.view.Settings;
using Xamarin.Forms;

namespace MusicNotesCodeTest.code.viewmodel.Flyout
{
    public class FlyoutMenuViewModel
    {
        public List<FlyoutMenuModel> FlyoutMenuItems { get; set; }

        public FlyoutMenuViewModel()
        {
            FlyoutMenuItems = new List<FlyoutMenuModel>()
            {
                new FlyoutMenuModel () {
                    Title = "My Library",
                    IconSource = ImageSource.FromResource("MusicNotesCodeTest.images.mylibrary.png"),
                    TargetType = typeof(LibraryPage)
                },
                new FlyoutMenuModel () {
                    Title = "Folders",
                    IconSource = ImageSource.FromResource("MusicNotesCodeTest.images.folders.png"),
                    TargetType = typeof(FoldersPage)
                },
                new FlyoutMenuModel () {
                    Title = "Set Lists",
                    IconSource = ImageSource.FromResource("MusicNotesCodeTest.images.setlists.png"),
                    TargetType = typeof(SetListPage)
                },
                new FlyoutMenuModel () {
                    Title = "Settings",
                    IconSource = ImageSource.FromResource("MusicNotesCodeTest.images.settings.png"),
                    TargetType = typeof(SettingsPage)
                },
                new FlyoutMenuModel () {
                    Title = "Help",
                    IconSource = ImageSource.FromResource("MusicNotesCodeTest.images.help.png"),
                    TargetType = typeof(HelpPage)
                }
            };
        }
    }
}
