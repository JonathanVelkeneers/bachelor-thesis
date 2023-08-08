using MauiPokedex.Services;

namespace MauiPokedex.ViewModels;

public class MainPageViewModel
{
    private readonly PokemonService _pokemonService = PokemonService.Service;
    public PokemonListViewModel PokemonListViewModel { get; } = new();

    public async Task LoadPokemon()
    {
        if (!PokemonListViewModel.FinishedLoading)
        {
            await Task.Run(async () =>
            {
                for (var i = 1; i <= 200; i++)
                {
                    var fetchedPokemon = await _pokemonService.GetPokemon(i);
                    PokemonListViewModel.AddPokemonToList(fetchedPokemon);
                }
                PokemonListViewModel.FinishedLoading = true;
            });
        }
    }
}

