using GlutenFree.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GlutenFree.Services
{
    public class ProvinceService : IProvinceService
    {
        SQLiteAsyncConnection db;

        async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Province.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Regione>();
        }

        public async Task<IEnumerable<Provincia>> GetProvinceAsync()
        {
            await Init();

            var province = await db.Table<Provincia>().ToListAsync();
            return province;
        }

        public async Task<Provincia> GetProvinciaAsync(string nome)
        {
            await Init();

            var provincia = await db.Table<Provincia>()
                .FirstOrDefaultAsync(p => p.Nome.Equals(nome));
            return provincia;
        }
    }
}
