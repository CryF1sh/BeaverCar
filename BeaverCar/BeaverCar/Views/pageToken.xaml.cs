using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeaverCar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pageToken : ContentPage
    {
        public pageToken(HttpClient client)
        {
            InitializeComponent();
        }
    }
}