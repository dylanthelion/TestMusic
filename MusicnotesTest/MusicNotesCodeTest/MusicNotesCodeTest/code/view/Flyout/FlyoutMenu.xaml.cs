using MusicNotesCodeTest.code.viewmodel.Flyout;
using Xamarin.Forms;

namespace MusicNotesCodeTest.code.view.Flyout
{
    public partial class FlyoutMenu : ContentPage
    {
        public ListView Menu => MenuListView;

        public FlyoutMenu(FlyoutMenuViewModel flyoutMenuViewModel)
        {
            InitializeComponent();
            BindingContext = flyoutMenuViewModel;
        }
    }
}
