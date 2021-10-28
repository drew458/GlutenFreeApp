using System.Linq;
using MCtabbed2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCtabbed2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegioniPage : ContentPage
    {
        public RegioniPage()
        {
            InitializeComponent();
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nomeRegione = (e.CurrentSelection.FirstOrDefault() as Regione).Nome;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"regionidetails?name={nomeRegione}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/cats/catdetails?name={catName}");
        }
    }
}