using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;

using BeaverCar.Class;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pageEnter : ContentPage
    {
        List<User> listUsers;
        HttpClient client;
        public pageEnter()
        {
            InitializeComponent();            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            client = new HttpClient();
            listUsers = JsonConvert.DeserializeObject<List<User>>((string)(Client.GetResponse("Users")));
            if (string.IsNullOrEmpty(contrPhone.Text))
            {
                await DisplayAlert("Ошибка", "Номер не был введён", "Ok");
                return;
            }
            try
            {
                var users = listUsers.FirstOrDefault(p => p.PhoneNumber == contrPhone.Text);
                if (users == null)
                    await DisplayAlert("Ошибка", "Такого номера нет", "Ок");
                else
                    VhodSys(users);
            }
            catch
            {
                await DisplayAlert("Ошибка", "Введён неправельный номер", "Ок");
            }
        }

        private void VhodSys(User users)
        {
            Navigation.PushAsync(new AppShell(users));     
        }
    }
}