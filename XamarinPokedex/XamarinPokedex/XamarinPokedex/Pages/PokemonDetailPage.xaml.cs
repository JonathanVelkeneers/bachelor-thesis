using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinPokedex.Models;
using XamarinPokedex.Services;
using XamarinPokedex.ViewModels;

namespace XamarinPokedex.Pages
{
    public partial class PokemonDetailPage : ContentPage
    {
        private PokemonService _pokemonService = PokemonService.Service;
        private PokemonColorService _pokemonColorService = new PokemonColorService();

        public PokemonDetailPage(PokemonDetailViewModel pokemonDetailViewModel)
        {
            InitializeComponent();
            this.BindingContext = pokemonDetailViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var pokemon = ((PokemonDetailViewModel)BindingContext).Pokemon;
            FetchDescription(pokemon);
            FetchTypeIcons(pokemon);
            AddCorrectDexButton(pokemon);
        }

        private async void FetchDescription(Pokemon pokemon)
        {
            var allDescriptions = (await pokemon.Species()).FlavorTextEntries;
            var description = allDescriptions.Find((text) => text.LanguageReferral.Name == "en").FlavorText();
            DescriptionLabel.Text = description;
        }

        private void FetchTypeIcons(Pokemon pokemon)
        {
            var pokemonTypes = pokemon.Types;
            pokemonTypes.Sort((x, y) => x.Slot - y.Slot);

            var imageWidth = 55;
            var cornerRadius = imageWidth / 2;


            foreach (var type in pokemonTypes)
            {
                var imageString = "icon_type_" + type.Type.Name.ToLower();
                TypeContainer.Children.Add(new Frame
                {
                    CornerRadius = cornerRadius,
                    Padding = 10,
                    IsClippedToBounds = true,
                    BackgroundColor = _pokemonColorService.GetColorByType(type.Type),
                    Content = new Image
                    {
                        Source = imageString,
                        WidthRequest = imageWidth
                    }
                });
            }
        }

        private async void AddCorrectDexButton(Pokemon pokemon)
        {
            DexButtonContainer.Children.Clear();
            Button button = new Button
            {
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Button)),
                FontAttributes = FontAttributes.Bold,
                Padding = new Thickness(20, 10),
                BackgroundColor = _pokemonColorService.GetColorByType(pokemon.Types[0].Type),
                TextColor = Color.Black
            };
            if (await _pokemonService.IsPokemonInPokedex(pokemon))
            {
                button.Text = "Remove from PokéDex";
                button.Clicked += OnRemoveFromDexClicked;
            }
            else
            {
                button.Text = "Add to PokéDex";
                button.Clicked += OnAddToDexClicked;
            }
            DexButtonContainer.Children.Add(button);

        }

        async void OnAddToDexClicked(System.Object sender, System.EventArgs e)
        {
            var pokemon = ((PokemonDetailViewModel)BindingContext).Pokemon;
            await _pokemonService.AddPokemonToPokedex(pokemon);
            AddCorrectDexButton(pokemon);
        }

        async void OnRemoveFromDexClicked(System.Object sender, System.EventArgs e)
        {
            var pokemon = ((PokemonDetailViewModel)BindingContext).Pokemon;
            await _pokemonService.RemovePokemonFromDex(pokemon);
            AddCorrectDexButton(pokemon);
        }
    }
}
