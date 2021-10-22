using MC_tabbed.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MC_tabbed.Views
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