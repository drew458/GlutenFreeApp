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
        // vedere https://www.youtube.com/watch?v=QvOxaRlIOPQ

        private ObservableCollection<Regione> listaRegioni;
        public ObservableCollection<Regione> ListaRegioni
        {
            get => listaRegioni;
            set
            {
                if (value == listaRegioni)
                {
                    return;
                }
                listaRegioni = value;
                OnPropertyChanged();
            }
        }

        public Regione RegioneSelezionata { get; set; }

        public ICommand RegioniSelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    string nomeRegione = RegioneSelezionata.Nome;
                    await Shell.Current.GoToAsync($"province?nome={nomeRegione}");
                });
            }
        }

        public RegioniViewModel()
        {
            ListaRegioni = RegioniData.Regioni;
        }
    }
}
