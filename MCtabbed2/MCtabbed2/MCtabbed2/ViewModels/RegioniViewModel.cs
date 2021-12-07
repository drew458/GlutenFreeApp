using MCtabbed2.Data;
using MCtabbed2.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MCtabbed2.ViewModels
{
    public class RegioniViewModel : BaseViewModel
    {
        // vedere https://www.youtube.com/watch?v=71K4PVRLasI

        private Item _selectedItem;
        private ObservableCollection<Regione> listaRegioni;

        public Command<Item> ItemTapped { get; }

        public RegioniViewModel()
        {
            Title = "Regioni";
            ListaRegioni = RegioniData.Regioni;
            ItemTapped = new Command<Item>(OnItemSelected);
        }

        public ObservableCollection<Regione> ListaRegioni
        {
            get => listaRegioni;
            set
            {
                listaRegioni = value;
                OnPropertyChanged();
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private void OnItemSelected(Item value)
        {
            throw new NotImplementedException();
        }

        private Regione previouslySelected;
        private Regione regioneSelezionata;

        public Regione RegioneSelezionata
        {
            get => regioneSelezionata;
            set
            {
                if (value != null)
                {
                    
                    string nomeRegione = value.Nome;
                    NavigaProvincia(nomeRegione);
                    previouslySelected = value;
                    value = null;
                }

                regioneSelezionata = value;
                OnPropertyChanged();
            }
        }

        // TODO: usare async-await
        private void NavigaProvincia(string nomeRegione)
        {
            if (nomeRegione == null)
            {
                return;
            }

            _ = Shell.Current.GoToAsync($"province?nome={nomeRegione}");
        }

        private Command refreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                if (refreshCommand == null)
                {
                    refreshCommand = new Command(Refresh);
                }

                return refreshCommand;
            }
        }

        // TODO: implementare comando refresh
        private void Refresh()
        {
        }
    }
}
