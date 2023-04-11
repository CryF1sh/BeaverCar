using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BeaverCar.Views
{
    public partial class SearchPage : ContentPage
    {
        public double firstLatitude = 0, firstLongitude = 0;
        public SearchPage()
        {
            InitializeComponent();
            FirstMapLocation();
            Position position = new Position(firstLatitude, firstLongitude);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map(mapSpan) { IsShowingUser = true };
            Content = map;
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
                    Geocoder geoCoder = new Geocoder();
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