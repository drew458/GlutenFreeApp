using GlutenFree.Models;
using GlutenFree.Resx;
using GlutenFree.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GlutenFree.ViewModels
{
    public class RegioniViewModel : BaseViewModel
    {
        // vedere https://www.youtube.com/watch?v=71K4PVRLasI

        private Regione _regioneSelezionata;
        
        public ObservableCollection<Regione> ListaRegioni { get; }

        public Command<Regione> RegioneTapped { get; }
        public Command LoadRegioniCommand { get; }

        public RegioniViewModel()
        {
            Title = AppResources.StringRegions;
            ListaRegioni = new ObservableCollection<Regione>();
            
            LoadRegioniCommand = new Command(async () => await ExecuteLoadRegioniCommand());
            RegioneTapped = new Command<Regione>(OnRegioneSelezionata);
        }

        async Task ExecuteLoadRegioniCommand()
        {
            IsBusy = true;

            try
            {
                ListaRegioni.Clear();
                var regioni = await DataStore.GetItemsAsync(true);
                foreach(var regione in regioni)
                {
                    ListaRegioni.Add(regione);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            RegioneSelezionata = null;
        }

        public Regione RegioneSelezionata
        {
            get => _regioneSelezionata;
            set
            {
                SetProperty(ref _regioneSelezionata, value);
                OnRegioneSelezionata(value);
            }
        }

        async void OnRegioneSelezionata(Regione regione)
        {
            if (regione == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(ProvincePage)}?{nameof(ProvinceViewModel.Nome)}={regione.Nome}");
        }
    }
}
