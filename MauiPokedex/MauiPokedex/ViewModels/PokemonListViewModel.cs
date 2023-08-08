using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiPokedex.Models;
using System.Linq;

namespace MauiPokedex.ViewModels;

public class PokemonListViewModel : BaseViewModel
{

    private readonly ICollection<Pokemon> _sourceList;
    public IEnumerable<Pokemon> PokemonList => GetFilteredPokemon();

    public SearchViewModel SearchViewModel { get; }

    private bool _finishedLoading = false;
    public bool FinishedLoading
    {
        get => _finishedLoading;
        set
        {
            _finishedLoading = value;
            OnPropertyChanged();
        }
    }

    public PokemonListViewModel()
    {
        _sourceList = new ObservableCollection<Pokemon>();
        SearchViewModel = new SearchViewModel();

        SearchViewModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
        {
            if (e.PropertyName == nameof(SearchViewModel.Query))
            {
                OnPropertyChanged(nameof(PokemonList));
            }
        };
    }

    public void AddPokemonToList(Pokemon pokemon)
    {
        _sourceList.Add(pokemon);
        OnPropertyChanged(nameof(PokemonList));
    }

    public void ClearPokemonList()
    {
        _sourceList.Clear();
        OnPropertyChanged(nameof(PokemonList));
    }

    private IEnumerable<Pokemon> GetFilteredPokemon()
    {
        IEnumerable<Pokemon> returnList = _sourceList;
        var searchQuery = SearchViewModel.Query.SearchQuery.Trim().ToLower();
        var typeQuery = SearchViewModel.Query.TypeQuery;
        var sortQuery = SearchViewModel.Query.SortItem;

        if (searchQuery.Length > 0)
        {
            returnList = returnList.Where(pkmn => pkmn.Name.ToLower().Contains(searchQuery));
        }
        if (typeQuery.Length > 0)
        {
            returnList = returnList.Where(pkmn => pkmn.Types.Exists(types => types.Type.Name == typeQuery));
        }
        if (sortQuery.Length > 0)
        {
            returnList = sortQuery switch
            {
                SearchViewModel.Name => returnList.OrderBy(pkmn => pkmn.Name),
                SearchViewModel.Type => returnList.OrderBy(pkmn => pkmn.Types[0].Type.Name),
                _ => returnList.OrderBy(pkmn => pkmn.Id)
            };
        }

        if (SearchViewModel.Query.SortDirection < 0)
        {
            returnList = returnList.Reverse();
        }
        return returnList;
    }
}

