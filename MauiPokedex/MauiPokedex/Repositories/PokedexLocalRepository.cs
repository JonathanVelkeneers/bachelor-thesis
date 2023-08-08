using System;
using MauiPokedex.Models;
using MauiPokedex.Models.Database;
using SQLite;

namespace MauiPokedex.Repositories;

public class PokedexLocalRepository : IPokedexRepository
{
    private static PokedexLocalRepository _pokedexLocalRepository;
    public static PokedexLocalRepository Repository => _pokedexLocalRepository ??= new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pokedex.db3"));

    private readonly SQLiteAsyncConnection _database;

    private PokedexLocalRepository(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        try
        {
            _database.CreateTableAsync<PokedexEntry>().Wait();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }

    public async Task<IEnumerable<PokedexEntry>> GetAllPokemon()
    {
        return await _database.Table<PokedexEntry>().ToListAsync();
    }

    public async Task<bool> IsPokemonInPokedex(Pokemon pokemon)
    {
        return (await _database.Table<PokedexEntry>().Where(entry => entry.Id == pokemon.Id).CountAsync()) > 0;
    }

    public Task<int> AddPokemonToPokedex(Pokemon pokemon)
    {
        return _database.InsertAsync(new PokedexEntry(pokemon.Id));
    }

    public Task<int> RemovePokemonFromDex(Pokemon pokemon)
    {
        return _database.DeleteAsync(new PokedexEntry(pokemon.Id));
    }
}

