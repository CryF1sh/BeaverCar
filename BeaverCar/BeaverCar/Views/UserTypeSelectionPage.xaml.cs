using BeaverCar.Class;
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
    public partial class UserTypeSelectionPage : ContentPage
    {
        User _user;
        bool role;
        public UserTypeSelectionPage(User users)
        {
            InitializeComponent();
            _user = users;
        }

        private void btnDriver_Clicked(object sender, EventArgs e)
        {
            role = true;
            new AppShell(role);
        }

        private void btnPass_Clicked(object sender, EventArgs e)
        {
            role = false;
            new AppShell(role);
        }
    }
}