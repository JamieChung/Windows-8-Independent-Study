using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MapApp.Resources;

using Microsoft.Phone.Maps.Controls;
using System.Device.Location; // Provides the GeoCoordinate class.
using Windows.Devices.Geolocation; //Provides the Geocoordinate class.
using System.Windows.Media;
using System.Windows.Shapes;

namespace MapApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();

            ShowDeviceLocation();
        }

        private async void ShowDeviceLocation()
        {
            // Get current location from device
            Geolocator deviceLocator = new Geolocator();
            
            // Sends an asynchronous request to get the device locationn
            Geoposition devicePosition = await deviceLocator.GetGeopositionAsync();

            // Converts the Geocoordinate from the device position to a GeoCoordinate
            // Uses the helper class we just created: CoordinateConverter
            GeoCoordinate deviceCoordinate = CoordinateConverter.ConvertGeocoordinate(devicePosition.Coordinate);

            // Create a small circle to mark the current location.
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Blue);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 50;

            // Create a MapOverlay to contain the circle.
            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = deviceCoordinate;

            // Create a MapLayer to contain the MapOverlay.
            MapLayer myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);

            // Add the MapLayer to the Map.
            MapView.Layers.Add(myLocationLayer);

            // Center the map and zoom in to map level 13 
            MapView.Center = deviceCoordinate;
            MapView.ZoomLevel = 13;

        }


        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem;

            appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBar_ZoomIn);
            appBarMenuItem.Click += ZoomIn_click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

            appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBar_ZoomOut);
            appBarMenuItem.Click += ZoomOut_click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

            appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBar_AerialView);
            appBarMenuItem.Click += AerialView_click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

            appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBar_RoadView);
            appBarMenuItem.Click += RoadView_click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        void ZoomIn_click(object sender, EventArgs e)
        {
            double zoom;
            zoom = MapView.ZoomLevel;
            MapView.ZoomLevel = ++zoom;
        }

        void ZoomOut_click(object sender, EventArgs e)
        {
            double zoom;
            zoom = MapView.ZoomLevel;
            MapView.ZoomLevel = --zoom;
        }

        void AerialView_click(object sender, EventArgs e)
        {
            MapView.CartographicMode = MapCartographicMode.Aerial;
        }

        void RoadView_click(object sender, EventArgs e)
        {
            MapView.CartographicMode = MapCartographicMode.Road;
        }
    }
}