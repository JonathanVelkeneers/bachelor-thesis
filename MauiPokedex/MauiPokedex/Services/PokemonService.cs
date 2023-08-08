using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MauiPokedex.Models;
using MauiPokedex.Models.Database;
using MauiPokedex.Repositories;
using Type = MauiPokedex.Models.Type;

namespace MauiPokedex.Services
{
    public class PokemonService
    {
        private static IPokemonRepository _pokemonRepository = PokemonApiRepository.Repository;
        private static IPokedexRepository _pokedexRepository = PokedexLocalRepository.Repository;

        private static PokemonService _pokemonService;
        public static PokemonService Service => _pokemonService ??= new();

        public Task<Pokemon> GetPokemon(int id)
        {
            return _pokemonRepository.GetPokemon(id);
        }
        
        public Task<PokemonSpecies> GetSpecies(string name)
        {
            return _pokemonRepository.GetSpecies(name);
        }

        public Task<IEnumerable<Type>> GetAllTypes()
        {
            return _pokemonRepository.GetAllTypes();
        }

        public Task<IEnumerable<Generation>> GetAllGenerations()
        {
            return _pokemonRepository.GetAllGenerations();
        }


        #region Pokedex

        public Task<IEnumerable<PokedexEntry>> GetAllPokemonFromPokedex()
        {
            return _pokedexRepository.GetAllPokemon();
        }
        public async Task<bool> IsPokemonInPokedex(Pokemon pokemon)
        {
            return await _pokedexRepository.IsPokemonInPokedex(pokemon);
        }

        public Task<int> AddPokemonToPokedex(Pokemon pokemon)
        {
            return _pokedexRepository.AddPokemonToPokedex(pokemon);
        }
        public Task<int> RemovePokemonFromDex(Pokemon pokemon)
        {
            return _pokedexRepository.RemovePokemonFromDex(pokemon);
        }

        #endregion
    }
}

