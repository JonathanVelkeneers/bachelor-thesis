
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinPokedex.Models;
using XamarinPokedex.Services;

namespace XamarinPokedex.ViewModels
{
    public class PokemonDetailViewModel
    {
        private PokemonColorService _pokemonColorService = new PokemonColorService();
        public Pokemon Pokemon { get; private set; }

        public IList<PokemonType> Types
        {
            get => Pokemon.Types;
            private set { }
        }

        public ImageSource ImageUrl
        {
            get => Pokemon.ImageUrl;
            private set { }
        }

        public string Name
        {
            get => Pokemon.Name;
            private set { }
        }

        public int Id
        {
            get => Pokemon.Id;
            private set { }
        }

        public PokemonDetailViewModel(Pokemon pokemon)
        {
            this.Pokemon = pokemon;
        }

        public Color Color
        {
            get => _pokemonColorService.GetColorByType(this.Types[0].Type);
            private set {}
        }
    }
}

