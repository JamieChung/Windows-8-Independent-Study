using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FlashlightColors.Resources;
using System.Windows.Media;

namespace FlashlightColors
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            var color = Colors.White;
            var button = (Button)sender;

            switch (button.Name)
            {
                case "WhiteButton":
                    color = Colors.White;
                    break;

                case "BlueButton":
                    color = Colors.Blue;
                    break;

                case "RedButton":
                    color = Colors.Red;
                    break;

                case "OrangeButton":
                    color = Colors.Orange;
                    break;
            }

            Flashlight.Fill = new SolidColorBrush(color);
        }

        //Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem;

            // Blue
            appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarColorBlueText);
            appBarMenuItem.Click += appBarMenuItem_Click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

            // White
            appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarColorWhiteText);
            appBarMenuItem.Click += appBarMenuItem_Click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

            // Red
            appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarColorRedText);
            appBarMenuItem.Click += appBarMenuItem_Click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

            // Orange
            appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarColorOrangeText);
            appBarMenuItem.Click += appBarMenuItem_Click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

        }

        void appBarMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = (ApplicationBarMenuItem)sender;
            var color = Colors.White;

            // We use the .Text attribute instead of .Name because that is what
            // ApplicationBarMenuItem supports
            switch (menuItem.Text)
            {
                // Notice that we cannot use the AppResources.AppBarColorWhiteText
                // This is because C# requires that switch statements use static constant strings
                // Our strings using AppResources are not static by nature.
                case "White":
                    color = Colors.White;
                    break;

                case "Blue":
                    color = Colors.Blue;
                    break;

                case "Red":
                    color = Colors.Red;
                    break;

                case "Orange":
                    color = Colors.Orange;
                    break;
            }

            Flashlight.Fill = new SolidColorBrush(color);
        }
    }
}