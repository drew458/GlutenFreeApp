using GlutenFree.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlutenFree.Services
{
    public interface IProvinceService
    {
        Task<IEnumerable<Provincia>> GetProvinceAsync();
        Task<Provincia> GetProvinciaAsync(string nome);
    }
}
