using GlutenFree.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlutenFree.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantPage : ContentPage
    {
        readonly RestaurantViewModel _viewModel;

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