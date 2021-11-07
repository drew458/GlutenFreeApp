using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MCtabbed2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MCtabbed2.Controls
{
    // implementato vedendo:
    // https://github.com/xamarin/xamarin-forms-samples/tree/main/UserInterface/Xaminals
    public class RegioniSearchHandler : SearchHandler
    {
        public IList<Regione> Regioni { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Regioni
                    .Where(regione => regione.Nome.ToLower().Contains(newValue.ToLower()))
                    .ToList<Regione>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            // Let the animation complete
            await Task.Delay(1000);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"{GetNavigationTarget()}?nome={((Regione)item).Nome}");
        }

        string GetNavigationTarget()
        {
            return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
        }
    }
}
