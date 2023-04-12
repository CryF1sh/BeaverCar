using BeaverCar.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTripPage : ContentPage
    {
        public ListTripPage()
        {
            InitializeComponent();
            //bool isApiAvailable = CheckAvailabilityAPI.CheckApiAvailability("http://192.168.43.65:65226");
            //if (isApiAvailable)
            //{
            //    var trips = JsonConvert.DeserializeObject<List<Trip>>((string)Client.GetResponse("Trips"));
            //    BindingContext = trips;
            //}
            //else
            //{
            //    DisplayAlert("Error", "Не удалось подключиться к API", "Ок");
            //}
            var trips = JsonConvert.DeserializeObject<List<Trip>>((string)Client.GetResponse("Trips"));
            //var trips = JsonConvert.DeserializeObject<List<Trip>>((string)Client.GetResponse("Trips"));

            //BindingContext = trips;
        }

        private void BtnCreateTrip_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateTripPage());
        }
    }
}