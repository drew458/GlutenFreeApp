using GlutenFree.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GlutenFree.Services
{
    public class RegioniProvinceService : IRegioniProvinceService
    {
        SQLiteAsyncConnection dbRegioni;
        SQLiteAsyncConnection dbProvince;

        async Task InitRegioni()
        {
            if (dbRegioni != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Regioni.db");

            dbRegioni = new SQLiteAsyncConnection(databasePath);

            await dbRegioni.CreateTableAsync<Regione>();
        }

        async Task InitProvince()
        {
            if (dbProvince != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Province.db");

            dbProvince = new SQLiteAsyncConnection(databasePath);

            await dbProvince.CreateTableAsync<Provincia>();
        }

        public async Task<IEnumerable<Regione>> GetRegioniAsync()
        {
            await InitRegioni();

            var regioni = await dbRegioni.Table<Regione>().ToListAsync();
            return regioni;
        }

        public async Task<Regione> GetRegioneAsync(string nome)
        {
            await InitRegioni();

            var regione = await dbRegioni.Table<Regione>()
                .FirstOrDefaultAsync(r => r.Nome.Equals(nome));
            return regione;
        }

        public async Task<IEnumerable<Provincia>> GetProvinceAsync()
        {
            await InitProvince();

            var province = await dbProvince.Table<Provincia>().ToListAsync();
            return province;
        }

        public async Task<Provincia> GetProvinciaAsync(string nome)
        {
            await InitProvince();

            var provincia = await dbProvince.Table<Provincia>()
                .FirstOrDefaultAsync(p => p.Nome.Equals(nome));
            return provincia;
        }
    }
}
