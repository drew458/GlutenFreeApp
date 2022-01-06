using GlutenFree.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GlutenFree.Services
{
    public class RegioniService : IRegioniService
    {
        SQLiteAsyncConnection db;

        async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Regioni.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Regione>();
        }

        public async Task<IEnumerable<Regione>> GetRegioniAsync()
        {
            await Init();

            var regioni = await db.Table<Regione>().ToListAsync();
            return regioni;
        }

        public async Task<Regione> GetRegioneAsync(string nome)
        {
            await Init();

            var regione = await db.Table<Regione>()
                .FirstOrDefaultAsync(r => r.Nome.Equals(nome));
            return regione;
        }

        
    }
}
