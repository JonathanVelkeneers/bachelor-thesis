using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinPokedex.Models;
using XamarinPokedex.Models.Database;

namespace XamarinPokedex.Repositories
{
	public interface IPokedexRepository
	{
        Task<List<PokedexEntry>> GetAll();
        Task<PokedexEntry> GetPokedexEntry(int id);
        Task<int> SavePokemon(Pokemon pokemon);
        Task<int> DeletePokemon(Pokemon pokemon);
    }
}

