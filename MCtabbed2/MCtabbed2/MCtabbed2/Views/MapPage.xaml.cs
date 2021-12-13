using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MCtabbed2.ViewModels;

namespace MCtabbed2.Views
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