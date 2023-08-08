using System;
using MauiPokedex.Models;
using MauiPokedex.Models.Database;

namespace MauiPokedex.Repositories;

public interface IPokedexRepository
{
    public Task<IEnumerable<PokedexEntry>> GetAllPokemon();
    public Task<bool> IsPokemonInPokedex(Pokemon pokemon);
    public Task<int> AddPokemonToPokedex(Pokemon pokemon);
    public Task<int> RemovePokemonFromDex(Pokemon pokemon);
}

