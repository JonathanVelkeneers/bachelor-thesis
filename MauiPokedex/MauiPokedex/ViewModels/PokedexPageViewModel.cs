using MauiPokedex.Services;

namespace MauiPokedex.ViewModels;

public class PokedexPageViewModel
{
    private readonly PokemonService _pokemonService = PokemonService.Service;
    public PokemonListViewModel PokemonListViewModel { get; } = new();

    public async Task LoadPokemon()
    {

        await Task.Run(async () =>
        {
            var allPokemon = await _pokemonService.GetAllPokemonFromPokedex();
            PokemonListViewModel.ClearPokemonList();
            foreach (var pokemon in allPokemon)
            {
                var fetchedPokemon = await _pokemonService.GetPokemon(pokemon.Id);
                PokemonListViewModel.AddPokemonToList(fetchedPokemon);
            }
            PokemonListViewModel.FinishedLoading = true;
        });
    }
}
