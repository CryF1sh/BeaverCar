using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BeaverCar.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map();
            Content = map;
        }
    }
}