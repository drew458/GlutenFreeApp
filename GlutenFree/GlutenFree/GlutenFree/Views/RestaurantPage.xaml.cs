using GlutenFreeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlutenFreeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantPage : ContentPage
    {
        RestaurantViewModel _viewModel;

        public RestaurantPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RestaurantViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}