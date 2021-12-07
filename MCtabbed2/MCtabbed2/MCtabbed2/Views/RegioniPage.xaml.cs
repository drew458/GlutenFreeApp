using MCtabbed2.ViewModels;
using Xamarin.Forms;

namespace MCtabbed2.Views
{
    public partial class RegioniPage : ContentPage
    {
        RegioniViewModel _viewModel;

        public RegioniPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RegioniViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        /* async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nomeRegione = (e.CurrentSelection.FirstOrDefault() as Regione).Nome;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"province?nome={nomeRegione}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/cats/catdetails?name={catName}");
        } */
    }
}