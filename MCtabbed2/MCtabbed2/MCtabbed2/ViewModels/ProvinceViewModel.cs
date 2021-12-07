using MCtabbed2.Data;
using MCtabbed2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MCtabbed2.ViewModels
{
    [QueryProperty(nameof(Nome), nameof(Nome))]
    public class ProvinceViewModel : BaseViewModel
    {
        private string nomeRegione;

        // per capire auto-property, guardare https://www.w3schools.com/cs/cs_properties.php

        // auto-property
        public IList<Provincia> ListaProvince { get; private set; }
        public IList<Provincia> ProvinceToSearch { get; private set; }

        public string Nome
        {
            get
            {
                return nomeRegione;
            }

            set
            {
                nomeRegione = value;
                LoadProvince(value);
            }
        }

        public async void LoadProvince(string nomeRegione)
        {
            try
            {
                var regione = await DataStore.GetItemAsync(nomeRegione);
                IList<Provincia> province = regione.Province;
                ListaProvince = province;
                ProvinceToSearch = province;
            }
            catch (Exception)
            {
                Console.WriteLine("Impossibile caricare la provincia");
            }
        }
    }
}
