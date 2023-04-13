using BeaverCar.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripViewPage : ContentPage
    {
        public TripViewPage(Trip trip)
        {
            InitializeComponent();
            //var trip1 = JsonConvert.DeserializeObject<Trip>((string)Client.GetResponse("Trips"));
            BindingContext = trip;
        }

        private void BtnOnRegister_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Сообщение", "Вы зарегистрированы", "Ок");
        }
            
    }
}