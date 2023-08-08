using MauiPokedex.ViewModels;

namespace MauiPokedex.Pages;

public partial class StatsPage
{
    public StatsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = (StatsPageViewModel)BindingContext;
        vm.LoadData();
    }
}
