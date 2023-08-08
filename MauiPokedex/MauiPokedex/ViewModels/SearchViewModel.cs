using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiPokedex.Models;
using MauiPokedex.Repositories;
using MauiPokedex.Services;

namespace MauiPokedex.ViewModels;

public class SearchViewModel : BaseViewModel
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string Type = "Type";
    public IEnumerable<string> SortItems { get; } = new List<string> { ID, Name, Type };
    public IEnumerable<string> FilterItems { get; private set; }

    public Query Query { get; } = new Query();
    private readonly PokemonService _pokemonService = PokemonService.Service;

    public SearchViewModel()
    {
        new Task(async () =>
        {
            var types = await _pokemonService.GetAllTypes();
            var typeNames = types.Select(type => type.Name).Prepend("");
            FilterItems = typeNames.ToList();
            OnPropertyChanged(nameof(FilterItems));
        }).Start();
    }

    public void SetSortDirection(int direction)
    {
        if (Query.SortDirection != direction)
        {
            Query.SortDirection = direction;
            OnQueryChanged();
        }
    }

    public void SetSortItem(string item)
    {
        if (Query.SortItem != item)
        {
            Query.SortItem = item;
            OnQueryChanged();
        }
    }

    public void SetSearchQuery(string searchQuery)
    {
        if (Query.SearchQuery != searchQuery)
        {
            Query.SearchQuery = searchQuery;
            OnQueryChanged();
        }
    }

    public void SetTypeQuery(string typeQuery)
    {
        if (Query.TypeQuery != typeQuery)
        {
            Query.TypeQuery = typeQuery;
            OnQueryChanged();
        }
    }

    private void OnQueryChanged()
    {
        OnPropertyChanged(nameof(Query));
    }
}

