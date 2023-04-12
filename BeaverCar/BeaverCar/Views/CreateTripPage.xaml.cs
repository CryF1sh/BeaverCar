using BeaverCar.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTripPage : ContentPage
    {
        public CreateTripPage(Trip trip)
        {
            InitializeComponent();
        }

        private void BtnCreateTrip_Clicked(object sender, EventArgs e)
        {
            //var client = new HttpClient();
            //client.BaseAddress = new Uri(Client.Url);

            //Trip exTrip = BindingContext as Trip;

            //string json = JsonConvert.SerializeObject(exTrip);

            //string jsonData = @"{""Data"" : ; ""Price"" :  ; ""DriverID"" :  ; ""CountPlace"" :  ; ""StatusID"" : ""2"" ; ""CreaterID"" : ""1"" ; ""StartPointLongitude"" :  ; ""StartPointLatitude"" :  ; ""EndPointLongitude"" :  ; ""EndPointLatitude"" :  ;}";
            

            //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("Trips", content);
        }
    }
}
