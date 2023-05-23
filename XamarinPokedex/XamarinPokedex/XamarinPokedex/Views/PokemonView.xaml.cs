using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinPokedex.Models;

namespace XamarinPokedex.Views
{
    public partial class PokemonView : ContentView
    {
        private IList<Pokemon> _pokemonList;
        public IList<Pokemon> PokemonList
        {
            get
            {
                return getFilteredPokemon();
            }
            private set { }
        }
        public SearchOption SearchOption { get; set; } = new SearchOption();

        public PokemonView(IList<Pokemon> pokemonList)
        {
            _pokemonList = pokemonList;
            InitializeComponent();
            BindingContext = this;
        }

        private IList<Pokemon> getFilteredPokemon()
        {
            return _pokemonList;
        }

        void OnPokemonClicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

