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

        private void Button_Clicked(object sender, EventArgs e)
        {
            client = new HttpClient();
            listUsers = JsonConvert.DeserializeObject<List<User>>((string)(Client.GetResponse("Users")));
            //if (string.IsNullOrEmpty(contrPhone.Text))
            //{
            //    DisplayAlert("Ошибка", "Номер не был введён", "Ok");
            //    return;
            //}
            //try
            //{
            //    var users = listUsers.FirstOrDefault(p => p.PhoneNumber == contrPhone.Text);
            //    if (sotr == null)
            //        DisplayAlert("Ошибка", "Такого номера нет", "Ок");
            //    else
                    //Navigation.PushAsync(new UserTypeSelectionPage(users));
            //}
            //catch
            //{
            //    DisplayAlert("Ошибка", "Введён неправельный номер", "Ок");
            //}
        }
    }
}