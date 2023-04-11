using BeaverCar.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var trips = JsonConvert.DeserializeObject<List<Trip>>((string)Client.GetResponse("Trips"));
            BindingContext = trips;
        }

        private void BtnCreateTrip_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateTripPage());
        }
    }
}