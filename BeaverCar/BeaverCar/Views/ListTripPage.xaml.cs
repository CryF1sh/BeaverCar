using BeaverCar.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTripPage : ContentPage
    {
        private readonly Geocoder geoCoder = new Geocoder();
        public ListTripPage()
        {
            InitializeComponent();
            var trips = JsonConvert.DeserializeObject<List<Trip>>((string)Client.GetResponse("Trips"));
            PerevodPossishn(trips);
        }

        private async void PerevodPossishn(List<Trip> trips)
        {
            foreach (Trip trip in trips)
            {
                //Для точки отправки
                var possibleAddresses = await Geocoding.GetPlacemarksAsync(Convert.ToDouble(trip.StartPointLatitude), Convert.ToDouble(trip.StartPointLongitude));
                Placemark placemark = possibleAddresses.FirstOrDefault();
                trip.StritBegin = placemark.CountryName + " " + placemark.AdminArea + " " + placemark.Locality + " " + placemark.Thoroughfare + " " + placemark.SubThoroughfare;
               
                //Для точки прибытия
                possibleAddresses = await Geocoding.GetPlacemarksAsync(Convert.ToDouble(trip.EndPointLatitude), Convert.ToDouble(trip.EndPointLongitude));
                placemark = possibleAddresses.FirstOrDefault();
                trip.StritEnd = placemark.CountryName + " " + placemark.AdminArea + " " + placemark.Locality + " " + placemark.Thoroughfare + " " + placemark.SubThoroughfare;
            }
            ListTrip.ItemsSource = trips;
        }

        private void BtnCreateTrip_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateTripPage());
            
        }
    }
}