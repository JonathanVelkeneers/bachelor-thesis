using System.Collections.ObjectModel;
using MauiPokedex.Services;

namespace MauiPokedex.ViewModels;

public class StatsPageViewModel
{
    private readonly PokemonService _pokemonService = PokemonService.Service;

    private readonly IList<KeyValuePair<string, int>> _typeChartData = new ObservableCollection<KeyValuePair<string, int>>
    {
        new KeyValuePair<string, int>("bigplaceholder1", 1),
        new KeyValuePair<string, int>("bigplaceholder2", 1),
        new KeyValuePair<string, int>("bigplaceholder3", 1),
        new KeyValuePair<string, int>("bigplaceholder4", 1),
        new KeyValuePair<string, int>("bigplaceholder5", 1),
    };
    public IEnumerable<KeyValuePair<string, int>> TypeChartData => _typeChartData;


    private readonly IList<KeyValuePair<string, int>> _pokemonPerGenChartData = new ObservableCollection<KeyValuePair<string, int>>();
    public IEnumerable<KeyValuePair<string, int>> PokemonPerGenChartData => _pokemonPerGenChartData;


    public List<Brush> TypeCustomBrushes { get; } = new List<Brush>();


    public StatsPageViewModel()
    {
        TypeCustomBrushes.AddRange(ColorService.GetAllColors().Select(color => new SolidColorBrush(color)));
    }

    public async Task LoadData()
    {
        var allTypes = await _pokemonService.GetAllTypes();
        _typeChartData.Clear();
        foreach (var type in allTypes)
        {
            var allPokemonWithTypeAsPrimary = type.Pokemon.Where(pkmn => pkmn.Slot == 1);
            _typeChartData.Add(new KeyValuePair<string, int>(type.Name, allPokemonWithTypeAsPrimary.Count()));
        }



        var generations = await _pokemonService.GetAllGenerations();
        _pokemonPerGenChartData.Clear();
        foreach (var generation in generations)
        {
            int amountOfPokemon = generation.PokemonSpecies.Count;
            _pokemonPerGenChartData.Add(new KeyValuePair<string, int>(generation.Name, amountOfPokemon));
        }
    }
}

