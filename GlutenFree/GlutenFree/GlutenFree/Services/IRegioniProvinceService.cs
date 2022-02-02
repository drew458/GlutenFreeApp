﻿using GlutenFree.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlutenFree.Services
{
    public interface IRegioniProvinceService
    {
        Task<IEnumerable<Regione>> GetRegioniAsync();
        Task<IEnumerable<Provincia>> GetProvinceAsync();
        Task<Regione> GetRegioneAsync(string nome);
        Task<Provincia> GetProvinciaAsync(string nome);
    }
}
