using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinPokedex.Models;
using Type = XamarinPokedex.Models.Type;

namespace XamarinPokedex.Repositories
{
	public interface IPokemonRepository
	{
        Task<IEnumerable<Pokemon>> GetAll(SearchOption filter);
        Task<Pokemon> GetPokemon(int id);
        Task<PokemonSpecies> GetSpecies(int id);
        Task<PokemonSpecies> GetSpecies(string name);
        Task<IEnumerable<Type>> GetAllTypes();
        Task<IEnumerable<Generation>> GetAllGenerations();
    }
}

