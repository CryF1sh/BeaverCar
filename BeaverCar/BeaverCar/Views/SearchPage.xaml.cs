using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Reflection;

namespace BeaverCar.Views
{
    public partial class SearchPage : ContentPage
    {
        private readonly Geocoder geoCoder = new Geocoder();
        private Polyline polyline = new Polyline();
        private Pin pinRoute1 = new Pin
        {
            Label = "Начало пути"
        };
        private Pin pinRoute2 = new Pin
        {
            Label = "Конец пути"
        };
        public double firstLatitude = 0, firstLongitude = 0;
        public SearchPage()
        {
            InitializeComponent();
            FirstMapLocation();
            Position position = new Position(firstLatitude, firstLongitude);
            //MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);

            myMap.Pins.Add(pinRoute1);
            myMap.Pins.Add(pinRoute2);
            pinRoute1.Position = new Xamarin.Forms.Maps.Position(firstLatitude, firstLongitude);
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(pinRoute1.Position, Xamarin.Forms.Maps.Distance.FromKilometers(0.3)));
        }

        private async void myMap_MapClicked(object sender, MapClickedEventArgs e)
        {
            myMap.MapElements.Remove(polyline);
            pinRoute2.Position=new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            polyline = new Polyline
            {
                StrokeColor = Color.Blue,
                StrokeWidth = 12,
                Geopath =
    {
new Position(firstLatitude, firstLongitude),
        new Position(e.Position.Latitude, e.Position.Longitude)
    }
            };
            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(pinRoute2.Position);
            LabelLocation.Text = possibleAddresses.FirstOrDefault();
            myMap.MapElements.Add(polyline);
        }

        private async void FirstMapLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
                if (location == null)
                    LabelLocation.Text = "No GPS";
                else
                {
                    firstLatitude = location.Latitude;
                    firstLongitude = location.Longitude;
                    Position position = new Position(firstLatitude, firstLongitude);
                    IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                    LabelLocation.Text = possibleAddresses.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Что-то не так:{ex.Message}");
            }
        }
    }
}