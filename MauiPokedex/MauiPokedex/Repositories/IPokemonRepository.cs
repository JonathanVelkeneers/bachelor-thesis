using System;
using MauiPokedex.Models;
using Type = MauiPokedex.Models.Type;

namespace MauiPokedex.Repositories;

public interface IPokemonRepository
{
    public Task<IEnumerable<Pokemon>> GetAllPokemon();
    public Task<Pokemon> GetPokemon(int id);
    public Task<PokemonSpecies> GetSpecies(string name);
    public Task<IEnumerable<Type>> GetAllTypes();
    public Task<IEnumerable<Generation>> GetAllGenerations();
}