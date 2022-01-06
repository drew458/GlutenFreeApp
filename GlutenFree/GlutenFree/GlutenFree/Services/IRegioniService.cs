using GlutenFree.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlutenFree.Services
{
    public interface IRegioniService
    {
        Task<IEnumerable<Regione>> GetRegioniAsync();
        Task<Regione> GetRegioneAsync(string nome);
    }
}
