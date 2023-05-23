using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SQLite;
using XamarinPokedex.Models;
using XamarinPokedex.Models.Api;
using System.IO;
using XamarinPokedex.Models.Database;

namespace XamarinPokedex.Repositories
{
    public class PokedexLocalRepository : IPokedexRepository
    {

        private static PokedexLocalRepository _pokedexRepository;
        public static PokedexLocalRepository Repository
        {
            get
            {
                if (_pokedexRepository == null)
                {
                    _pokedexRepository = new PokedexLocalRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pokedex.db3"));
                }
                return _pokedexRepository;
            }
            private set { }
        }
        private SQLiteAsyncConnection _database;


        private PokedexLocalRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            try
            {
                _database.CreateTableAsync<PokedexEntry>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public Task<PokedexEntry> GetPokedexEntry(int id)
        {
            return _database.Table<PokedexEntry>()
                            .Where(entry => entry.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<PokedexEntry>> GetAll()
        {
            return _database.Table<PokedexEntry>().ToListAsync();
        }

        public Task<int> SavePokemon(Pokemon pokemon)
        {
            return _database.InsertAsync(new PokedexEntry(pokemon.Id));
        }

        public Task<int> DeletePokemon(Pokemon pokemon)
        {
            return _database.Table<PokedexEntry>().DeleteAsync((entry) => entry.Id == pokemon.Id);
        }
    }
}
