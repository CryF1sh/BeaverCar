using BeaverCar.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BeaverCar.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}