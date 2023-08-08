using MauiPokedex.Models;
using MauiPokedex.Services;
using MauiPokedex.ViewModels;

namespace MauiPokedex.Pages;

public partial class PokemonDetailPage
{
    public PokemonDetailPage(PokemonDetailViewModel pokemonDetailViewModel)
    {
        InitializeComponent();
        BindingContext = pokemonDetailViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        PokemonDetailViewModel viewModel = ((PokemonDetailViewModel)BindingContext);
        viewModel.FetchDescription();
        FetchTypeIcons(viewModel.Pokemon);
        viewModel.FetchIsInPokedex();
    }

    private void FetchTypeIcons(Pokemon pokemon)
    {
        var pokemonTypes = pokemon.Types;
        pokemonTypes.Sort((x, y) => x.Slot - y.Slot);

        const int containerSize = 50;
        const int cornerRadius = containerSize / 2;


        foreach (var type in pokemonTypes.Select(type => type.Type))
        {
            var imageString = "icon_type_" + type.Name.ToLower();
            TypeContainer.Children.Add(new Frame
            {
                StyleClass = new List<string>() { "TypeIconFrame" },
                WidthRequest = containerSize,
                HeightRequest = containerSize,
                CornerRadius = cornerRadius,
                BackgroundColor = ColorService.GetColorByType(type),
                Content = new Image
                {
                    Source = imageString,
                    WidthRequest = containerSize - 15,
                    HeightRequest = containerSize - 15,
                }
            });
        }
    }

    private void OnAddToDexClicked(object sender, EventArgs e)
    {
        PokemonDetailViewModel viewModel = ((PokemonDetailViewModel)BindingContext);
        viewModel.AddPokemonToDex();
    }

    private void OnRemoveFromDexClicked(object sender, EventArgs e)
    {
        PokemonDetailViewModel viewModel = ((PokemonDetailViewModel)BindingContext);
        viewModel.RemovePokemonFromDex();
    }
}
