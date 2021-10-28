using MCtabbed2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCtabbed2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProvincePage : ContentPage
    {
        public ProvincePage()
        {
            InitializeComponent();

            BindingContext = new ProvinceViewModel();
        }
    }
}