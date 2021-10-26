using MCtabbed2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCtabbed2.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public List<Regione> Regioni { get; set; }

        public ListViewModel()
        {
            Title = "List (regioni)";

            var immagine = "";

            Regioni = new List<Regione>
            {
                new Regione("Abruzzo", ""),
                new Regione("Basilicata", ""),
                new Regione("Calabria", ""),
                new Regione("Campania", ""),
                new Regione("Emilia Romagna", ""),
                new Regione("Friuli Venezia Giulia", ""),
                new Regione("Lazio", ""),
                new Regione("Liguria", ""),
                new Regione("Lombardia", ""),
                new Regione("Marche", ""),
                new Regione("Molise", ""),
                new Regione("Piemonte", ""),
                new Regione("Puglia", ""),
                new Regione("Sardegna", ""),
                new Regione("Sicilia", ""),
                new Regione("Toscana", ""),
                new Regione("Trentino Alto Adige", ""),
                new Regione("Umbria", ""),
                new Regione("Valle d'Aosta", ""),
                new Regione("Veneto", "")
            };
        }
    }
}
