using MCtabbed2.Data;
using MCtabbed2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MCtabbed2.ViewModels
{
    [QueryProperty(nameof(Nome), "nome")]
    public class ProvinceViewModel : BindableObject
    {
        // per capire auto-property, guardare https://www.w3schools.com/cs/cs_properties.php

        // auto-property
        public IList<Provincia> ListaProvince { get; private set; }
        public IList<Provincia> ProvinceToSearch { get; private set; }

        public string Nome
        {
            set => LoadProvince(value);
        }

        private void LoadProvince(string nome)
        {
            try
            {
                Regione regione = RegioniData.Regioni.FirstOrDefault(r => r.Nome == nome);
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
