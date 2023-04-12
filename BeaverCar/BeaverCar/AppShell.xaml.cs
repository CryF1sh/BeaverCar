using BeaverCar.Class;
using BeaverCar.ViewModels;
using BeaverCar.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BeaverCar
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell(bool role, User user)
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
