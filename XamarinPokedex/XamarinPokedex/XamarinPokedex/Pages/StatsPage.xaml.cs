using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using XamarinPokedex.Models;
using XamarinPokedex.Services;
using XamarinPokedex.ViewModels.Charts;
using Type = System.Type;

namespace XamarinPokedex.Pages
{
    public partial class StatsPage : ContentPage
    {
        private PokemonService _pokemonService = PokemonService.Service;
        public TypeChartViewModel TypeChartViewModel { get; set; } = new TypeChartViewModel();
        public BaseChartViewModel PokemonPerGenChartViewModel { get; set; } = new BaseChartViewModel();

        public StatsPage()
        {
            InitializeComponent();
            BindingContext = this;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadPokemonTypesChart();
            LoadPokemonPerGenerationChart();
        }

        private async void LoadPokemonTypesChart()
        {
            var types = await _pokemonService.GetAllTypes();
            TypeChartViewModel.SeriesData.Clear();
            foreach (var type in types)
            {
                int amountOfPokemon = type.Pokemon.Where(pkmnType => pkmnType.Slot == 1).Count();
                TypeChartViewModel.SeriesData.Add(new ChartDataModel(type.Name, type.Name, amountOfPokemon));
            }
            TypeChartLoader.IsVisible = false;
            TypeChart.IsVisible = true;
        }

        private async void LoadPokemonPerGenerationChart()
        {
            var generations = await _pokemonService.GetAllGenerations();
            PokemonPerGenChartViewModel.SeriesData.Clear();
            foreach (var generation in generations)
            {
                int amountOfPokemon = generation.PokemonSpecies.Count();
                PokemonPerGenChartViewModel.SeriesData.Add(new ChartDataModel(generation.Name, generation.Name, amountOfPokemon)); //TODO add chart
            }
            PokemonPerGenChartLoader.IsVisible = false;
            PokemonPerGenChart.IsVisible = true;

        }
    }
}
