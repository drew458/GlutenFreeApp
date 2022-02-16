using GlutenFreeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlutenFreeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        readonly LoginViewModel _viewmodel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = _viewmodel = new LoginViewModel();
        }
    }
}