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

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTripPage : ContentPage
    {
        private string posString;
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
                Position pos1 = new Position(Convert.ToDouble(trip.StartPointLatitude), Convert.ToDouble(trip.StartPointLongitude));
                IEnumerable<string> possibleAddresses1 = await geoCoder.GetAddressesForPositionAsync(pos1);
                trip.StritBegin = possibleAddresses1.FirstOrDefault();
                //Для точки прибытия
                Position pos2 = new Position(Convert.ToDouble(trip.EndPointLatitude), Convert.ToDouble(trip.EndPointLongitude));
                IEnumerable<string> possibleAddresses2 = await geoCoder.GetAddressesForPositionAsync(pos2);
                trip.StritEnd = possibleAddresses2.FirstOrDefault();           
            }
            ListTrip.ItemsSource = trips;
        }

        private void BtnCreateTrip_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateTripPage());
        }
    }
}