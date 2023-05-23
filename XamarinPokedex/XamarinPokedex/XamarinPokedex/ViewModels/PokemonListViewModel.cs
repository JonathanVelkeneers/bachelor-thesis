using System;
using System.Collections.Generic;
using System.ComponentModel;
using XamarinPokedex.Models;
using System.Linq;
using System.Reflection;
using Xamarin.Forms.Internals;
using XamarinPokedex.Services;
using System.Runtime.CompilerServices;

namespace XamarinPokedex.ViewModels
{
    public class PokemonListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler FinishedLoading;

        private SortOptionsService sortOptionsService = new SortOptionsService();

        private IEnumerable<Pokemon> _pokemonList;
        public IEnumerable<Pokemon> SourcePokemonList
        {
            get { return _pokemonList; }
            set {
                _pokemonList = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilteredPokemonList"));
            }
        }
        public IEnumerable<Pokemon> FilteredPokemonList
        {
            get
            {
                return getFilteredPokemon();
            }
            private set { }
        }

        private SearchOption _searchOption;
        public SearchOption SearchOption
        {
            get { return _searchOption; }
            set
            {
                _searchOption = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilteredPokemonList"));
            }
        }

        public PokemonListViewModel(IEnumerable<Pokemon> pokemonList, SearchOption searchOption)
        {
            this.SourcePokemonList = pokemonList;
            this.SearchOption = searchOption;
        }

        private IEnumerable<Pokemon> getFilteredPokemon()
        {
            IEnumerable<Pokemon> returnList = _pokemonList;
            string sortProperty = SearchOption.SortProperty;
            int sortDirection = SearchOption.SortDirection;
            string filterProperty = SearchOption.FilterProperty;
            string searchQuery = SearchOption.SearchQuery.ToLower();

            if (filterProperty != null && filterProperty.Trim().Length > 0 && filterProperty != "No filter")
            {
                returnList = returnList.Where(pkmn => pkmn.Types.Any(type => type.Type.Name == filterProperty));
            }
            if (searchQuery != null && searchQuery.Trim().Length > 0)
            {
                returnList = returnList.Where(pkmn => pkmn.Name.ToLower().Contains(searchQuery));
            }
            if (sortProperty != null && sortProperty.Trim().Length > 0)
            {
                returnList = returnList.OrderBy(pkmn => sortOptionsService.getSortOption(sortProperty, pkmn));
            }
            if (sortDirection < 0)
            {
                returnList = returnList.Reverse();
            }
            return returnList;
        }

        public void FinishLoading()
        {
            this.FinishedLoading?.Invoke(this, new EventArgs());
        }
    }
}
