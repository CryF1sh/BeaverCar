using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pageEnter : ContentPage
    {
        public pageEnter()
        {
            InitializeComponent();
            var client = new WebClient();
            //var responce = client.DownloadString("http://192.168.1.161:61306/api/Sotrudnics");
            //прописать нужный класс на основе джсон заброса из апи сервиса ladno = JsonConvert.DeserializeObject<List<Sotrudnic>>(responce);
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
                //var sotr = ladno.FirstOrDefault(p => p.VhodCode == Int32.Parse(contrPhone.Text));
                //if (sotr == null)
                //    DisplayAlert("Ошибка", "Такого номера нет", "Ок");
                //else
                    // некст страница после входа Navigation.PushAsync();
            }
            catch
            {
                DisplayAlert("Ошибка", "Введён неправельный номер", "Ок");
            }
        }
    }
}