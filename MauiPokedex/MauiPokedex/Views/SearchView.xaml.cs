using System.ComponentModel;
using MauiPokedex.ViewModels;

namespace MauiPokedex.Views;

public partial class SearchView
{
    public SearchView()
    {
        InitializeComponent();
    }


    void OnSearchQueryChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        var binding = ((SearchViewModel)BindingContext);
        binding.SetSearchQuery(e.NewTextValue);
    }

    void OnFilterItemChanged(System.Object sender, System.EventArgs e)
    {
        var binding = ((SearchViewModel)BindingContext);
        binding.SetTypeQuery((sender as Picker).SelectedItem as string);
    }

    void OnSortItemChanged(System.Object sender, System.EventArgs e)
    {
        var binding = ((SearchViewModel)BindingContext);
        binding.SetSortItem((sender as Picker).SelectedItem as string);
    }

    void OnSortDirectionChanged(System.Object sender, System.EventArgs e)
    {
        var binding = ((SearchViewModel)BindingContext);
        var currentDirection = binding.Query.SortDirection;
        ImageButton button = sender as ImageButton;

        if (currentDirection > 0)
        {
            button.Source = "icon_arrow_up.png";
        }
        else
        {
            button.Source = "icon_arrow_down.png";
        }
        binding.SetSortDirection(currentDirection * -1);
    }
}
