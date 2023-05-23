using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinPokedex.Models;
using XamarinPokedex.Models.Database;
using XamarinPokedex.Repositories;
using Type = XamarinPokedex.Models.Type;

namespace XamarinPokedex.Services
{
    public class PokemonService
    {
        private static IPokemonRepository _pokemonRepository = PokemonApiRepository.Repository;
        private static IPokedexRepository _pokedexRepository = PokedexLocalRepository.Repository;
        private static PokemonService _pokemonService;
        public static PokemonService Service
        {
            get
            {
                if (_pokemonService == null)
                {
                    _pokemonService = new PokemonService();
                }
                return _pokemonService;
            }
            private set
            {

            }
        }

        public PokemonService()
        {
        }

        public Task<Pokemon> GetPokemon(int id)
        {
            return _pokemonRepository.GetPokemon(id);
        }

        public Task<PokemonSpecies> GetSpecies(int id)
        {
            return _pokemonRepository.GetSpecies(id);
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

        public async Task<bool> IsPokemonInPokedex(Pokemon pokemon)
        {
            return (await _pokedexRepository.GetPokedexEntry(pokemon.Id)) != null;
        }
        
        public Task<int> AddPokemonToPokedex(Pokemon pokemon)
        {
            return _pokedexRepository.SavePokemon(pokemon);
        }
        public Task<int> RemovePokemonFromDex(Pokemon pokemon)
        {
            return _pokedexRepository.DeletePokemon(pokemon);
        }
        public Task<List<PokedexEntry>> GetAllPokemonFromPokedex()
        {
            return _pokedexRepository.GetAll();
        }

        #endregion
    }
}
