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
    public partial class TripViewPage : ContentPage
    {
        public TripViewPage()
        {
            InitializeComponent();

            //BindingContext = ; Здесь нужно дать объект поездки
        }

        private void BtnOnRegister_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnReturn_Clicked(object sender, EventArgs e)
        {

        }
    }
}