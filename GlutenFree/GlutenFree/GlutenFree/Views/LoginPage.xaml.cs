using GlutenFree.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlutenFree.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel _viewmodel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = _viewmodel = new LoginViewModel();
        }        
    }
}