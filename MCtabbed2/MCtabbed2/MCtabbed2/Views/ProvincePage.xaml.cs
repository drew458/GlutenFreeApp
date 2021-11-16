using Xamarin.Forms;
using MCtabbed2.Models;
using MCtabbed2.Data;
using System.Linq;
using System;
using System.Collections.Generic;

namespace MCtabbed2.Views
{
    [QueryProperty(nameof(Nome), "name")]
    public partial class ProvincePage : ContentPage
    {

        public string Nome
        {
            set
            {
                LoadProvince(value);
            }
        }

        public ProvincePage()
        {
            InitializeComponent();
        }

        void LoadProvince(string nome)
        {
            try
            {
                Regione regione = RegioniData.Regioni.FirstOrDefault(r => r.Nome == nome);
                IList<Provincia> province = regione.Province;
                BindingContext = province;
                
            }
            catch (Exception)
            {
                Console.WriteLine("Impossibile caricare la provincia");
            }
        }
    }
}