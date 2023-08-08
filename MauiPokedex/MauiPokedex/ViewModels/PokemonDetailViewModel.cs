using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using MauiPokedex.Models;
using MauiPokedex.Services;

namespace MauiPokedex.ViewModels;

public class PokemonDetailViewModel : BaseViewModel
{
    private readonly PokemonService _pokemonService = PokemonService.Service;

    public Pokemon Pokemon { get; }
    public int Id => Pokemon.Id;
    public string Name => Pokemon.Name;
    public ImageSource ImageUrl => Pokemon.ImageUrl;
    public Color Color => ColorService.GetColorByType(Pokemon.Types[0].Type);

    private string _description = "";
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged();
        }
    }

    private bool _isInPokedex = false;
    public bool IsInPokedex
    {
        get => _isInPokedex;
        set
        {
            _isInPokedex = value;
            OnPropertyChanged();
        }
    }


    public PokemonDetailViewModel(Pokemon pokemon)
    {
        Pokemon = pokemon;
    }

    public async Task FetchDescription()
    {
        var species = await Pokemon.GetSpecies();
        Description = species.FlavorTextEntries.First(text => text.LanguageReferral.Name == "en").FlavorText;
    }
    public async Task FetchIsInPokedex()
    {
        var isInDex = await _pokemonService.IsPokemonInPokedex(Pokemon);
        IsInPokedex = isInDex;
    }

    public void AddPokemonToDex()
    {
        _pokemonService.AddPokemonToPokedex(Pokemon);
        IsInPokedex = true;
    }

    public void RemovePokemonFromDex()
    {
        _pokemonService.RemovePokemonFromDex(Pokemon);
        IsInPokedex = false;
    }
}
