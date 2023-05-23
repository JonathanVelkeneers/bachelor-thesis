using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinPokedex.Models;
using XamarinPokedex.Models.Database;
using XamarinPokedex.Services;
using XamarinPokedex.ViewModels;
using XamarinPokedex.Views;
using static XamarinPokedex.Views.PokemonListView;

namespace XamarinPokedex.Pages
{
    public partial class MyDexPage : ContentPage
    {
        private PokemonService _pokemonService = PokemonService.Service;
        public SearchOption SearchOption { get; set; } = new SearchOption();
        public PokemonListViewModel PokemonListViewModel { get; set; }


        public MyDexPage()
        {
            InitializeComponent();
            BindingContext = this;
            PokemonListViewModel = new PokemonListViewModel(null, SearchOption);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PokemonListViewModel.SourcePokemonList = new List<Pokemon>();
            fetchPokemon();
            OnPropertyChanged(nameof(PokemonListViewModel));
        }

        private async void fetchPokemon()
        {
            var pokemonInDex = await _pokemonService.GetAllPokemonFromPokedex();

            foreach (var entry in pokemonInDex)
            {
                var fetchedPokemon = await _pokemonService.GetPokemon(entry.Id);
                if (fetchedPokemon != null)
                {
                    addPokemonToSourceList(fetchedPokemon);
                }
            }
            PokemonListViewModel.FinishLoading();
            ListView.IsLoaded = true;
        }

        private void addPokemonToSourceList(Pokemon pokemon)
        {
            List<Pokemon> pokemonList = PokemonListViewModel.SourcePokemonList.ToList();
            pokemonList.Add(pokemon);
            PokemonListViewModel.SourcePokemonList = pokemonList;
        }

        void OnSearchOptionChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            PokemonListViewModel.SearchOption = SearchOption;
        }

        async void OnPokemonClicked(System.Object sender, System.EventArgs e)
        {
            var detailPage = new PokemonDetailPage(new PokemonDetailViewModel(((PokemonClickedEventArgs)e).Pokemon));
            await Navigation.PushAsync(detailPage);
        }
    }
}

