using MauiPokedex.ViewModels;
using static MauiPokedex.Views.PokemonListView;

namespace MauiPokedex.Pages;

public partial class PokedexPage
{
    public PokedexPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = ((PokedexPageViewModel)BindingContext);
        vm.LoadPokemon();
    }

    private async void OnPokemonClicked(object sender, EventArgs e)
    {

        var pokemon = ((PokemonClickedEventArgs)e).Pokemon;
        var detailPage = new PokemonDetailPage(new PokemonDetailViewModel(pokemon));
        await Navigation.PushAsync(detailPage);
    }
}
