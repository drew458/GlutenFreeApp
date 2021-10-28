using System;
using System.Collections.Generic;
using System.Text;
using MCtabbed2.Models;
using Xamarin.Forms;

namespace MCtabbed2.Data
{
    class RegioniData
    {
        public static IList<Regione> Regioni { get; private set; }

        static RegioniData()
        {
            Regioni = new List<Regione>
            {
                new Regione
                {
                    Nome = "Abruzzo",
                    Immagine = new Image { Source = "flag_abruzzo.png" }
                },

                new Regione
                {
                    Nome = "Basilicata",
                    Immagine = new Image { Source = "flag_basilicata.png" }
                },

                new Regione
                {
                    Nome = "Calabria",
                    Immagine = new Image { Source = "flag_calabria.png" }
                },

                new Regione
                {
                    Nome = "Campania",
                    Immagine = new Image { Source = "flag_campania.png" }
                },

                new Regione
                {
                    Nome = "Emilia Romagna",
                    Immagine = new Image { Source = "flag_emiliaromagna.png" }
                },

                new Regione
                {
                    Nome = "Friuli Venezia Giulia",
                    Immagine = new Image { Source = "flag_friuli.png" }
                },

                new Regione
                {
                    Nome = "Lazio",
                    Immagine = new Image { Source = "flag_lazio.png" }
                },

                new Regione
                {
                    Nome = "Liguria",
                    Immagine = new Image { Source = "flag_liguria.png" }
                },

                new Regione
                {
                    Nome = "Lombardia",
                    Immagine = new Image { Source = "flag_lombardia.png" }
                },

                new Regione
                {
                    Nome = "Marche",
                    Immagine = new Image { Source = "flag_marche.png" }
                },

                new Regione
                {
                    Nome = "Molise",
                    Immagine = new Image { Source = "flag_molise.png" }
                },

                new Regione
                {
                    Nome = "Piemonte",
                    Immagine = new Image { Source = "flag_piemonte.png" }
                },

                new Regione
                {
                    Nome = "Puglia",
                    Immagine = new Image { Source = "flag_puglia.png" }
                },

                new Regione
                {
                    Nome = "Sardegna",
                    Immagine = new Image { Source = "flag_sardegna.png" }
                },

                new Regione
                {
                    Nome = "Sicilia",
                    Immagine = new Image { Source = "flag_sicilia.png" }
                },

                new Regione
                {
                    Nome = "Toscana",
                    Immagine = new Image { Source = "flag_toscana.png" }
                },

                new Regione
                {
                    Nome = "Trentino Alto Adige",
                    Immagine = new Image { Source = "flag_trentino.png" }
                },

                new Regione
                {
                    Nome = "Umbria",
                    Immagine = new Image { Source = "flag_umbria.png" }
                },

                new Regione
                {
                    Nome = "Valle d'Aosta",
                    Immagine = new Image { Source = "flag_valleaosta.png" }
                },

                new Regione
                {
                    Nome = "Veneto",
                    Immagine = new Image { Source = "flag_veneto.png" }
                }
            };
        }

    }
}
