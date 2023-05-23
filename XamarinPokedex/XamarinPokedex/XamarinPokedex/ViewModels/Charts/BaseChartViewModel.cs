using System;
using System.Collections.ObjectModel;
using XamarinPokedex.Models;

namespace XamarinPokedex.ViewModels.Charts
{
    public class BaseChartViewModel
    {
        public ObservableCollection<ChartDataModel> SeriesData { get; set; }

        public BaseChartViewModel()
        {
            SeriesData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Loading chart", "Loading chart", 1)
            };
        }
    }
}

