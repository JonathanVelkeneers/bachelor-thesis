using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using XamarinPokedex.Models;
using XamarinPokedex.Services;

namespace XamarinPokedex.Views
{
    public partial class SearchBarView : ContentView
    {
        private SortOptionsService _sortOptionService = new SortOptionsService();
        private FilterOptionsService _filterOptionService = new FilterOptionsService();
        public event PropertyChangedEventHandler SearchOptionChanged;

        public List<string> SortOptions
        {
            get { return _sortOptionService.GetSortOptions(); }
            private set { }
        }
        public List<string> FilterOptions
        {
            get { return _filterOptionService.GetFilterOptions(); }
            private set { }
        }

        public SearchBarView()
        {
            InitializeComponent();
            sortPicker.ItemsSource = SortOptions;
            filterPicker.ItemsSource = FilterOptions;
        }

        void OnSortDirectionChanged(System.Object sender, System.EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            SearchOption searchOption = BindingContext as SearchOption;
            if (searchOption.SortDirection > 0)
            {
                button.Source = "icon_arrow_up.png";
            }
            else
            {
                button.Source = "icon_arrow_down.png";
            }
            searchOption.SortDirection *= -1;
            SearchOptionChanged?.Invoke(this, new PropertyChangedEventArgs("SortDirection"));
        }

        void OnFilterChanged(System.Object sender, System.EventArgs e)
        {
            Picker picker = sender as Picker;
            SearchOption searchOption = BindingContext as SearchOption;

            searchOption.FilterProperty = picker.SelectedItem as string;
            SearchOptionChanged?.Invoke(this, new PropertyChangedEventArgs("FilterProperty"));
        }

        void OnSortItemChanged(System.Object sender, System.EventArgs e)
        {
            Picker picker = sender as Picker;
            SearchOption searchOption = BindingContext as SearchOption;

            searchOption.SortProperty = picker.SelectedItem as string;
            SearchOptionChanged?.Invoke(this, new PropertyChangedEventArgs("SortProperty"));
        }

        void OnSearchQueryChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SearchOption searchOption = BindingContext as SearchOption;

            searchOption.SearchQuery = (sender as SearchBar).Text;
            SearchOptionChanged?.Invoke(this, new PropertyChangedEventArgs("SearchQuery"));
        }
    }
}

