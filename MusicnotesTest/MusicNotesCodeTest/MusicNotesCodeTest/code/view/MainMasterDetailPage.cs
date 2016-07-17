using System;
using MusicNotesCodeTest.code.model.Flyout;
using MusicNotesCodeTest.code.util;
using MusicNotesCodeTest.code.view.Flyout;
using MusicNotesCodeTest.code.viewmodel.Flyout;
using Xamarin.Forms;

namespace MusicNotesCodeTest.code.view
{
    public class MainMasterDetailPage : MasterDetailPage
    {

        private readonly FlyoutMenu _flyMenu;

        public MainMasterDetailPage()
        {
            FlyoutMenuViewModel flyoutMenu = new FlyoutMenuViewModel();
            _flyMenu = new FlyoutMenu(flyoutMenu);
            _flyMenu.Menu.ItemSelected += handleOnMenuItemSelected;
            Master = _flyMenu;

            NavigateTo(flyoutMenu.FlyoutMenuItems[0]);
        }

        void handleOnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NavigateTo(e.SelectedItem as FlyoutMenuModel);
        }

        public void NavigateTo(FlyoutMenuModel flyoutMenuModel)
        {
            if (flyoutMenuModel != null)
            {
                Page displayPage = (Page)Activator.CreateInstance(flyoutMenuModel.TargetType);
                displayPage.Icon = "MusicNotesCodeTest.images.menu.png";
                displayPage.Title = flyoutMenuModel.Title;

                Detail = new NavigationPage(displayPage)
                {
                    BarBackgroundColor = Color.FromHex(HexColors.MedBlueHex),
                    BarTextColor = Color.White
                };

                _flyMenu.Menu.SelectedItem = null;
                IsPresented = false;
            }

        }

    }
}

