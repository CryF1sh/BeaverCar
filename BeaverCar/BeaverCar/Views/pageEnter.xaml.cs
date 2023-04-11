using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net;
using BeaverCar.Class;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pageEnter : ContentPage
    {
        List<User> listUsers;
        public pageEnter()
        {
            InitializeComponent();
            var client = new WebClient();
            var responce = client.DownloadString("http://192.168.43.65:65226/api/Users");
            listUsers = JsonConvert.DeserializeObject<List<User>>(responce);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(contrPhone.Text))
            {
                DisplayAlert("Ошибка", "Номер не был введён", "Ok");
                return;
            }
            try
            {
                var sotr = listUsers.FirstOrDefault(p => p.PhoneNumber == contrPhone.Text);
                if (sotr == null)
                    DisplayAlert("Ошибка", "Такого номера нет", "Ок");
                else
                    DisplayAlert("1", "Т2", "Ок");
                    //Navigation.PushAsync();
            }
            catch
            {
                DisplayAlert("Ошибка", "Введён неправельный номер", "Ок");
            }
        }
    }
}