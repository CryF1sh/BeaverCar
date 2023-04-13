using BeaverCar.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTripPage : ContentPage
    {
        public static Trip _trip;
        public CreateTripPage(Trip trip)
        {
            InitializeComponent();
            _trip = trip;
        }

        private void BtnCreateTrip_Clicked(object sender, EventArgs e)
        {
            //SaveData();
            DisplayAlert("Сообщение", "Заявка создана", "Ок");
        }

        private async void SaveData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Client.Url);

            _trip = BindingContext as Trip;

            string json = JsonConvert.SerializeObject(_trip);
            HttpContent content = new StringContent(json);
                        
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.Content = content;
            request.RequestUri = new Uri(Client.Url + "Trips");
            HttpResponseMessage response = await client.SendAsync(request);
            //string jsonData = @"{""Data"" : ; ""Price"" :  ; ""DriverID"" :  ; ""CountPlace"" :  ; ""StatusID"" : ""2"" ; ""CreaterID"" : ""1"" ; ""StartPointLongitude"" :  ; ""StartPointLatitude"" :  ; ""EndPointLongitude"" :  ; ""EndPointLatitude"" :  ;}";


            //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("Trips", content);
        }
    }
}
