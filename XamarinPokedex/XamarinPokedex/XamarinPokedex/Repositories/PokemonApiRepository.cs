using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MonkeyCache.FileStore;
using XamarinPokedex.Models;
using XamarinPokedex.Models.Api;
using Type = XamarinPokedex.Models.Type;

namespace XamarinPokedex.Repositories
{
    public class PokemonApiRepository : IPokemonRepository
    {
        private const string BASE_API_URL = "https://pokeapi.co/api/v2/";
        private static HttpClient client = new HttpClient();

        private static PokemonApiRepository _pokemonApiRepository;
        public static PokemonApiRepository Repository
        {
            get
            {
                if (_pokemonApiRepository == null)
                {
                    _pokemonApiRepository = new PokemonApiRepository();
                }
                return _pokemonApiRepository;
            }
            private set { }
        }

        private PokemonApiRepository()
        {
            client.BaseAddress = new Uri(BASE_API_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<Pokemon> GetPokemon(int id)
        {
            return Get<Pokemon, int>("pokemon", id);
        }

        public async Task<IEnumerable<Pokemon>> GetAll(SearchOption filter)
        {
            IEnumerable<Pokemon> pokemonList = null;
            string endpoint = $"pokemon?limit={filter.Limit}&offset={filter.Limit * (filter.Page - 1)}";

            HttpResponseMessage response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                pokemonList = (await response.Content.ReadAsAsync<NamedAPIResourceList<Pokemon>>()).results;
            }
            return pokemonList;
        }

        public Task<PokemonSpecies> GetSpecies(int id)
        {
            return Get<PokemonSpecies, int>("pokemon-species", id);
        }
        public Task<PokemonSpecies> GetSpecies(string name)
        {
            return Get<PokemonSpecies, string>("pokemon-species", name);
        }

        public async Task<IEnumerable<Type>> GetAllTypes()
        {
            List<Type> typeList = new List<Type>();

            var typeCollection = (await GetList<Type>("type"));
            for (int i = 1; i <= typeCollection.Count(); i++)
            {
                typeList.Add(await Get<Type, int>("type", i));
            }
            return typeList.Where(type => type != null && type.Pokemon != null).ToList();
        }


        public async Task<IEnumerable<Generation>> GetAllGenerations()
        {
            List<Generation> generationList = new List<Generation>();

            var typeCollection = (await GetList<Generation>("generation"));
            for (int i = 1; i <= typeCollection.Count(); i++)
            {
                generationList.Add(await Get<Generation, int>("generation", i));
            }
            return generationList;
        }

        private async Task<T> Get<T, X>(string endpoint, X key)
        {
            T result = default(T);
            var url = $"{endpoint}/{key}";

            if (!Barrel.Current.IsExpired(key: url))
            {
                return Barrel.Current.Get<T>(key: url);
            }

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
                Barrel.Current.Add(key: url, data: result, expireIn: TimeSpan.FromDays(7));
            }
            return result;
        }

        private async Task<IEnumerable<T>> GetList<T>(string endpoint)
        {
            IEnumerable<T> result = default(IEnumerable<T>);
            var url = $"{endpoint}";

            if (!Barrel.Current.IsExpired(key: url))
            {
                return Barrel.Current.Get<IEnumerable<T>>(key: url);
            }

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var listResult = await response.Content.ReadAsAsync<ApiListResource<T>>();
                result = listResult.Results;
                Barrel.Current.Add(key: url, data: result, expireIn: TimeSpan.FromDays(7));
            }
            return result;
        }
    }
}
