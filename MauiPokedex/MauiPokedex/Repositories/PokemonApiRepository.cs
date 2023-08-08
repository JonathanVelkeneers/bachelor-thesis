using System.Net.Http.Headers;
using System.Text.Json;
using MauiPokedex.Models;
using MonkeyCache.FileStore;
using Type = MauiPokedex.Models.Type;

namespace MauiPokedex.Repositories;

public class PokemonApiRepository : IPokemonRepository
{
    private static readonly JsonSerializerOptions _serializerOptions = new() { IncludeFields = true };

    private const string ApiUrl = "https://pokeapi.co/api/v2/";
    private readonly HttpClient _client = new();


    private static PokemonApiRepository _pokemonApiRepository;
    public static PokemonApiRepository Repository => _pokemonApiRepository ??= new PokemonApiRepository();

    private PokemonApiRepository()
    {
        _client.BaseAddress = new Uri(ApiUrl);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public Task<Pokemon> GetPokemon(int id)
    {
        return Get<Pokemon>("pokemon", id);
    }

    public Task<IEnumerable<Pokemon>> GetAllPokemon()
    {
        return GetAll<Pokemon>("pokemon");
    }

    public Task<PokemonSpecies> GetSpecies(string name)
    {
        return Get<PokemonSpecies>("pokemon-species", name);
    }


    public async Task<IEnumerable<Type>> GetAllTypes()
    {
        var typeOverview = await GetAll<Type>("type");
        var typeList = new List<Type>();
        foreach (var type in typeOverview)
        {
            typeList.Add(await Get<Type>("type", type.Name.ToLower()));
        }
        return typeList.Where(type => type != null && type.Pokemon != null && type.Pokemon.Count > 0);
    }


    public async Task<IEnumerable<Generation>> GetAllGenerations()
    {
        var generationOverview = await GetAll<Generation>("generation");
        var generationList = new List<Generation>();
        foreach (var generation in generationOverview)
        {
            generationList.Add(await Get<Generation>("generation", generation.Name.ToLower()));
        }
        return generationList;
    }

    private async Task<TResult> Get<TResult>(string endpoint, object key)
    {
        var result = default(TResult);
        var url = $"{endpoint}/{key}";

        Barrel.Current.EmptyExpired();
        if (!Barrel.Current.IsExpired(key: url))
        {
            return Barrel.Current.Get<TResult>(key: url, options: _serializerOptions);
        }

        var response = await _client.GetAsync(url);
        if (!response.IsSuccessStatusCode) return result;

        result = await response.Content.ReadAsAsync<TResult>();
        Barrel.Current.Add(key: url, data: result, expireIn: TimeSpan.FromDays(7), options: _serializerOptions);
        return result;
    }

    private async Task<IEnumerable<TResult>> GetAll<TResult>(string endpoint)
    {
        Barrel.Current.EmptyExpired();
        if (!Barrel.Current.IsExpired(key: endpoint))
        {
            return Barrel.Current.Get<IEnumerable<TResult>>(key: endpoint);
        }

        var response = await _client.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode) return null;

        var listResult = await response.Content.ReadAsAsync<ApiListResource<TResult>>();
        var result = listResult.Results.ToList();
        Barrel.Current.Add(key: endpoint, data: result, expireIn: TimeSpan.FromDays(7));
        return result;
    }
}

