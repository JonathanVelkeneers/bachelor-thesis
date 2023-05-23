using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinPokedex.Models;
using XamarinPokedex.ViewModels;

namespace XamarinPokedex.Views
{
    public partial class PokemonListView : ContentView
    {
        public event EventHandler PokemonClicked;
        public event EventHandler RemainingItemsThresholdReached;

        public bool IsLoaded { get; set; } = false;

        public PokemonListView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (IsLoaded)
            {
                PokemonCollectionViewLoader.IsVisible = false;
                PokemonCollectionView.IsVisible = true;
            }

            var viewModel = (PokemonListViewModel)this.BindingContext;
            if (viewModel != null)
            {
                viewModel.FinishedLoading += OnFinishedLoading;
            }
        }

        void OnSelectPokemon(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            Pokemon selected = e.CurrentSelection[0] as Pokemon;
            PokemonClicked?.Invoke(this, new PokemonClickedEventArgs(selected));
        }

        public class PokemonClickedEventArgs : EventArgs
        {
            public Pokemon Pokemon { get; private set; }
            public PokemonClickedEventArgs(Pokemon pokemon)
            {
                this.Pokemon = pokemon;
            }
        }

        void OnRemainingItemsThresholdReached(System.Object sender, System.EventArgs e)
        {
            RemainingItemsThresholdReached?.Invoke(this, null);
        }


        private void OnFinishedLoading(object sender, EventArgs e)
        {
            IsLoaded = true;
            PokemonCollectionViewLoader.IsVisible = false;
            PokemonCollectionView.IsVisible = true;
        }
    }
}

