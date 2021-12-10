using MCtabbed2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MCtabbed2.Services
{
    public class MockDataStore : IDataStore<Regione>
    {
        readonly List<Regione> regioni;

        public MockDataStore()
        {
            regioni = new List<Regione>()
            {
                new Regione
                {
                    Nome = "Abruzzo",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_abruzzo.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "l'Aquila",
                        },

                        new Provincia
                        {
                            Nome = "Teramo"
                        },

                        new Provincia
                        {
                            Nome = "Pescara"
                        },

                        new Provincia
                        {
                            Nome = "Chieti"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Basilicata",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_basilicata.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Matera"
                        },

                        new Provincia
                        {
                            Nome = "Potenza"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Calabria",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_calabria.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Catanzaro"
                        },

                        new Provincia
                        {
                            Nome = "Cosenza"
                        },

                        new Provincia
                        {
                            Nome = "Crotone"
                        },

                        new Provincia
                        {
                            Nome = "Reggio Calabria"
                        },

                        new Provincia
                        {
                            Nome = "Vibo Valentia"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Campania",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_campania.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Avellino"
                        },

                        new Provincia
                        {
                            Nome = "Benevento"
                        },

                        new Provincia
                        {
                            Nome = "Caserta"
                        },

                        new Provincia
                        {
                            Nome = "Napoli"
                        },

                        new Provincia
                        {
                            Nome = "Salerno"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Emilia Romagna",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_emiliaromagna.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Bologna"
                        },

                        new Provincia
                        {
                            Nome = "Ferrara"
                        },

                        new Provincia
                        {
                            Nome = "Forlì-Cesena"
                        },

                        new Provincia
                        {
                            Nome = "Modena"
                        },

                        new Provincia
                        {
                            Nome = "Modena"
                        },

                        new Provincia
                        {
                            Nome = "Parma"
                        },

                        new Provincia
                        {
                            Nome = "Piacenza"
                        },

                        new Provincia
                        {
                            Nome = "Ravenna"
                        },

                        new Provincia
                        {
                            Nome = "Reggio Emilia"
                        },

                        new Provincia
                        {
                            Nome = "Rimini"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Friuli Venezia Giulia",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_friuli.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Gorizia"
                        },

                        new Provincia
                        {
                            Nome = "Pordenone"
                        },

                        new Provincia
                        {
                            Nome = "Trieste"
                        },

                        new Provincia
                        {
                            Nome = "Udine"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Lazio",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_lazio.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Frosinone",
                            Falesie = new List<Falesia>
                            {
                                new Falesia
                                {
                                    Nome = "Acuto (Placche di Pila Rocca)",
                                    NumeroVie = 29,
                                    VieConRipetizioni = 28,
                                    NumeroRipetizioni = 731,
                                }, 
                            }
                        },

                        new Provincia
                        {
                            Nome = "Latina"
                        },

                        new Provincia
                        {
                            Nome = "Rieti"
                        },

                        new Provincia
                        {
                            Nome = "Roma"
                        },

                        new Provincia
                        {
                            Nome = "Viterbo"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Liguria",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_liguria.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Genova"
                        },

                        new Provincia
                        {
                            Nome = "Imperia"
                        },

                        new Provincia
                        {
                            Nome = "La Spezia"
                        },

                        new Provincia
                        {
                            Nome = "Savona"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Lombardia",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_lombardia.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Bergamo"
                        },

                        new Provincia
                        {
                            Nome = "Brescia"
                        },

                        new Provincia
                        {
                            Nome = "Como"
                        },

                        new Provincia
                        {
                            Nome = "Cremona"
                        },

                        new Provincia
                        {
                            Nome = "Lecco"
                        },

                        new Provincia
                        {
                            Nome = "Lodi"
                        },

                        new Provincia
                        {
                            Nome = "Mantova"
                        },

                        new Provincia
                        {
                            Nome = "Milano"
                        },

                        new Provincia
                        {
                            Nome = "Monza"
                        },

                        new Provincia
                        {
                            Nome = "Pavia"
                        },

                        new Provincia
                        {
                            Nome = "Sondrio"
                        },

                        new Provincia
                        {
                            Nome = "Varese"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Marche",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_marche.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Ancona"
                        },

                        new Provincia
                        {
                            Nome = "Ascoli Piceno"
                        },

                        new Provincia
                        {
                            Nome = "Fermo"
                        },

                        new Provincia
                        {
                            Nome = "Macerata"
                        },

                        new Provincia
                        {
                            Nome = "Pesaro"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Molise",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_molise.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Campobasso"
                        },

                        new Provincia
                        {
                            Nome = "Isernia"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Piemonte",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_piemonte.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Alessandria"
                        },

                        new Provincia
                        {
                            Nome = "Asti"
                        },

                        new Provincia
                        {
                            Nome = "Biella"
                        },

                        new Provincia
                        {
                            Nome = "Cuneo"
                        },

                        new Provincia
                        {
                            Nome = "Novara"
                        },

                        new Provincia
                        {
                            Nome = "Torino"
                        },

                        new Provincia
                        {
                            Nome = "Verbano"
                        },

                        new Provincia
                        {
                            Nome = "Vercelli"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Puglia",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_puglia.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Bari"
                        },

                        new Provincia
                        {
                            Nome = "Barletta"
                        },

                        new Provincia
                        {
                            Nome = "Brindisi"
                        },

                        new Provincia
                        {
                            Nome = "Foggia"
                        },

                        new Provincia
                        {
                            Nome = "Lecce"
                        },

                        new Provincia
                        {
                            Nome = "Taranto"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Sardegna",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_sardegna.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Cagliari"
                        },

                        new Provincia
                        {
                            Nome = "Nuoro"
                        },

                        new Provincia
                        {
                            Nome = "Oristano"
                        },

                        new Provincia
                        {
                            Nome = "Sassari"
                        },

                        new Provincia
                        {
                            Nome = "Sud Sardegna"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Sicilia",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_sicilia.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Agrigento"
                        },

                        new Provincia
                        {
                            Nome = "Caltanissetta"
                        },

                        new Provincia
                        {
                            Nome = "Catania"
                        },

                        new Provincia
                        {
                            Nome = "Enna"
                        },

                        new Provincia
                        {
                            Nome = "Messina"
                        },

                        new Provincia
                        {
                            Nome = "Palermo"
                        },

                        new Provincia
                        {
                            Nome = "Ragusa"
                        },

                        new Provincia
                        {
                            Nome = "Siracusa"
                        },

                        new Provincia
                        {
                            Nome = "Trapani"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Toscana",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_toscana.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Arezzo"
                        },

                        new Provincia
                        {
                            Nome = "Firenze"
                        },

                        new Provincia
                        {
                            Nome = "Grosseto"
                        },

                        new Provincia
                        {
                            Nome = "Livorno"
                        },

                        new Provincia
                        {
                            Nome = "Lucca"
                        },

                        new Provincia
                        {
                            Nome = "Massa-Carrara"
                        },

                        new Provincia
                        {
                            Nome = "Pisa"
                        },

                        new Provincia
                        {
                            Nome = "Pistoia"
                        },

                        new Provincia
                        {
                            Nome = "Prato"
                        },

                        new Provincia
                        {
                            Nome = "Siena"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Trentino Alto Adige",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_trentino.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Bolzano"
                        },

                        new Provincia
                        {
                            Nome = "Trento"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Umbria",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_umbria.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Perugia"
                        },

                        new Provincia
                        {
                            Nome = "Terni"
                        },
                    }
                },

                new Regione
                {
                    Nome = "Valle d'Aosta",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_valleaosta.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Aosta"
                        }
                    }
                },

                new Regione
                {
                    Nome = "Veneto",
                    Immagine = ImageSource.FromResource("MCtabbed2.Resources.Images.flag_veneto.png"),
                    Province = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nome = "Belluno"
                        },

                        new Provincia
                        {
                            Nome = "Padova"
                        },

                        new Provincia
                        {
                            Nome = "Rovigo"
                        },

                        new Provincia
                        {
                            Nome = "Treviso"
                        },

                        new Provincia
                        {
                            Nome = "Venezia"
                        },

                        new Provincia
                        {
                            Nome = "Verona"
                        },

                        new Provincia
                        {
                            Nome = "Vicenza"
                        }
                    }
                }
            };
        }


        public async Task<bool> AddItemAsync(Regione regione)
        {
            regioni.Add(regione);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string nomeRegione)
        {
            Regione vecchiaRegione = regioni.FirstOrDefault((Regione arg) => arg.Nome == nomeRegione);
            regioni.Remove(vecchiaRegione);

            return await Task.FromResult(true);
        }

        public async Task<Regione> GetItemAsync(string nomeRegione)
        {
            return await Task.FromResult(regioni.FirstOrDefault(regione => regione.Nome == nomeRegione));
        }

        public async Task<IEnumerable<Regione>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(regioni);
        }

        public async Task<bool> UpdateItemAsync(Regione nuovaRegione)
        {
            Regione vecchiaRegione = regioni.FirstOrDefault((Regione arg) => arg.Nome == nuovaRegione.Nome);
            regioni.Remove(vecchiaRegione);
            regioni.Add(nuovaRegione);

            return await Task.FromResult(true);
        }
    }
}
