using MauiPokedex.ViewModels;
using static MauiPokedex.Views.PokemonListView;

namespace MauiPokedex.Pages;

public partial class MainPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = ((MainPageViewModel)BindingContext);
        vm.LoadPokemon();
    }

    private async void OnPokemonClicked(object sender, EventArgs e)
    {

        var pokemon = ((PokemonClickedEventArgs)e).Pokemon;
        var detailPage = new PokemonDetailPage(new PokemonDetailViewModel(pokemon));
        await Navigation.PushAsync(detailPage);
    }
}
