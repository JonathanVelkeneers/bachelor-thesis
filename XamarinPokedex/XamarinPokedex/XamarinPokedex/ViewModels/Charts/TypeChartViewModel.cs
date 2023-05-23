using System;
using System.Collections.ObjectModel;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using XamarinPokedex.Models;
using XamarinPokedex.Services;

namespace XamarinPokedex.ViewModels.Charts
{
    public class TypeChartViewModel : BaseChartViewModel
    {
        private PokemonColorService _pokemonColorService = new PokemonColorService();

        public ChartColorCollection Colors { get; set; }

        public TypeChartViewModel() : base()
        {
            Colors = new ChartColorCollection();
            Colors.AddRange(_pokemonColorService.GetAllColors());
        }
    }
}
