using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using toouch.Resources;
using System.IO.IsolatedStorage;

namespace toouch
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            if (!IsolatedStorageSettings.ApplicationSettings.Contains("anahtar"))
            {
                IsolatedStorageSettings.ApplicationSettings.Add("anahtar", 0);
                IsolatedStorageSettings.ApplicationSettings["anahtar"] = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri oyn = new Uri("/oyn.xaml", UriKind.Relative);
            NavigationService.Navigate(oyn);
        }

        private void tb_skor_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("anahtar"))
            {
                int skor = (int)IsolatedStorageSettings.ApplicationSettings["anahtar"];
                tb_skor.Text = "Score: " + skor.ToString();
            }  
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}