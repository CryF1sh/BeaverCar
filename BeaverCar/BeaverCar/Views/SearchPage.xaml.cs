using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Reflection;
using System.Security.Cryptography;
using BeaverCar.Class;

namespace BeaverCar.Views
{
    public partial class SearchPage : ContentPage
    {
        private readonly Geocoder geoCoder = new Geocoder();
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
            myMap.Pins.Add(pinRoute1);
            myMap.Pins.Add(pinRoute2);
            pinRoute1.Position = new Xamarin.Forms.Maps.Position(firstLatitude, firstLongitude); 
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(pinRoute1.Position, Xamarin.Forms.Maps.Distance.FromKilometers(0.3)));
        }

        private async void myMap_MapClicked(object sender, MapClickedEventArgs e)
        {
            pinRoute2.Position=new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            var possibleAddresses = await Geocoding.GetPlacemarksAsync(pinRoute1.Position.Latitude, pinRoute1.Position.Longitude);
            Placemark placemark = possibleAddresses.FirstOrDefault();
            Destination.Text = placemark.AdminArea + " " + placemark.Locality + " " + placemark.Thoroughfare + " " + placemark.SubThoroughfare;
            
            possibleAddresses = await Geocoding.GetPlacemarksAsync(pinRoute2.Position.Latitude, pinRoute2.Position.Longitude);
            placemark = possibleAddresses.FirstOrDefault();
            Origin.Text = placemark.AdminArea + " " + placemark.Locality + " " + placemark.Thoroughfare + " " + placemark.SubThoroughfare;
            locationLabel.Text = placemark.AdminArea + " " + placemark.Locality + " " + placemark.Thoroughfare + " " + placemark.SubThoroughfare;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                double pos1Lat=0, pos1Long=0, pos2Lat=0, pos2Long=0;
                int error = 0;
                var destinationaddress = Destination.Text;
                var locations = await Geocoding.GetLocationsAsync(destinationaddress);
                var location = locations?.FirstOrDefault();
                if (location == null)
                {
                    error++;
                }
                else
                {
                    pos1Lat = location.Latitude;
                    pos1Long = location.Longitude;
                }
                var originaddress = Origin.Text;
                locations = await Geocoding.GetLocationsAsync(originaddress);
                location = locations?.FirstOrDefault();
            if (location == null)
            {
                    error++;
            }
            else
                {
                    pos2Lat = location.Latitude;
                    pos2Long = location.Longitude;
                }
            if(error == 0)
                {
                    Trip trip = new Trip();
                    trip.StartPointLatitude=Convert.ToString(pos1Lat);
                    trip.StartPointLongitude=Convert.ToString(pos1Long);
                    trip.EndPointLatitude=Convert.ToString(pos2Lat);
                    trip.EndPointLongitude = Convert.ToString(pos2Long);
                    trip.StritBegin = destinationaddress;
                    trip.StritEnd = originaddress;
                    await Navigation.PushAsync(new CreateTripPage(trip));
                    //originaddress
                }
            else
                    await DisplayAlert("Ошибка!", "Неправильный адрес", "ОК");
            }
            catch
            {
            }
        }

        private void Origin_Completed(object sender, EventArgs e)
        {
            if (Origin.Text != "" & Destination.Text != "")
            {
                Device.BeginInvokeOnMainThread(() => AddDrive.IsVisible=true);
            }
            else
                Device.BeginInvokeOnMainThread(() => AddDrive.IsVisible = false);
        }

        private void Destination_Completed(object sender, EventArgs e)
        {
            if (Origin.Text != "" & Destination.Text != "")
            {
                AddDrive.IsVisible = true;
            }
            else
                AddDrive.IsVisible =false;
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
                {
                    locationLabel.Text = "No GPS";
                }
                else
                {
                    firstLatitude = location.Latitude;
                    firstLongitude = location.Longitude;
                    var possibleAddresses = await Geocoding.GetPlacemarksAsync(firstLatitude, firstLongitude);
                    Placemark placemark = possibleAddresses.FirstOrDefault();
                    string pos = placemark.AdminArea + " " + placemark.Locality + " " + placemark.Thoroughfare + " " + placemark.SubThoroughfare;/*possibleAddresses.FirstOrDefault()*/
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Что-то не так:{ex.Message}");
            }
        }
    }
}