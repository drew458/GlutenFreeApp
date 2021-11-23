using MCtabbed2.Data;
using MCtabbed2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MCtabbed2.ViewModels
{
    class RegioniViewModel : BindableObject
    {
        // vedere https://www.youtube.com/watch?v=71K4PVRLasI

        private ObservableCollection<Regione> listaRegioni;
        public ObservableCollection<Regione> ListaRegioni
        {
            get => listaRegioni;
            set
            {
                listaRegioni = value;
                OnPropertyChanged();
            }
        }

        Regione previouslySelected;
        Regione regioneSelezionata;

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

        public RegioniViewModel()
        {
            ListaRegioni = RegioniData.Regioni;
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

        private void Refresh()
        {
        }
    }
}
