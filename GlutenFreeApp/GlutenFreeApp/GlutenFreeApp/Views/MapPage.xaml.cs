using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GlutenFreeApp.ViewModels;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;

namespace GlutenFreeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            BindingContext = new MapViewModel();
        }

        async void Pin_InfoWindowClicked(object sender, PinClickedEventArgs e)
        {
            e.HideInfoWindow = true;
            string pinName = ((Pin)sender).Label;
            string pinAddress = ((Pin)sender).Address;
            await Shell.Current.GoToAsync($"{nameof(RestaurantPage)}?{nameof(RestaurantViewModel.Nome)}={pinName}&" +
                $"{nameof(RestaurantViewModel.Indirizzo)}={pinAddress}");
        }
    }
}