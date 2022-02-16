using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GlutenFreeApp.ViewModels;

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
    }
}