using MauiPokedex.Models;

namespace MauiPokedex.Views;

public partial class PokemonListView
{
    public event EventHandler PokemonClicked;

    public PokemonListView()
    {
        InitializeComponent();
    }


    void OnSelectPokemon(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            Pokemon selected = e.CurrentSelection[0] as Pokemon;
            PokemonClicked?.Invoke(this, new PokemonClickedEventArgs(selected));
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    public class PokemonClickedEventArgs : EventArgs
    {
        public Pokemon Pokemon { get; private set; }
        public PokemonClickedEventArgs(Pokemon pokemon)
        {
            this.Pokemon = pokemon;
        }
    }
}
