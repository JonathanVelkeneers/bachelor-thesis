using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinPokedex.Models;
using XamarinPokedex.Repositories;
using XamarinPokedex.Services;
using XamarinPokedex.ViewModels;
using XamarinPokedex.Views;
using static XamarinPokedex.Views.PokemonListView;

namespace XamarinPokedex.Pages
{
    public partial class MainPage : ContentPage
    {
        private PokemonService _pokemonService = PokemonService.Service;

        public SearchOption SearchOption { get; set; } = new SearchOption();

        public PokemonListViewModel PokemonListViewModel { get; set; }

        public MainPage()
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

        void OnSearchOptionChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            PokemonListViewModel.SearchOption = SearchOption;
        }

        private async void fetchPokemon()
        {
            var startIndex = ((SearchOption.Page - 1) * SearchOption.Limit) + 1;
            var limit = startIndex + SearchOption.Limit;
            for (int i = startIndex; i < limit; i++)
            {
                var fetchedPokemon = await _pokemonService.GetPokemon(i);
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

        async void OnPokemonClicked(System.Object sender, System.EventArgs e)
        {
            var detailPage = new PokemonDetailPage(new PokemonDetailViewModel(((PokemonClickedEventArgs)e).Pokemon));
            await Navigation.PushAsync(detailPage);
        }
    }
}
