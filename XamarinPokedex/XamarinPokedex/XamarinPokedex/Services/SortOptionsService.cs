using System;
using System.Collections.Generic;
using XamarinPokedex.Models;

namespace XamarinPokedex.Services
{
    public class SortOptionsService
    {
        private static List<string> _sortOptions = new List<string>();

        static SortOptionsService()
        {
            _sortOptions.Add("ID");
            _sortOptions.Add("Name");
        }

        public List<string> GetSortOptions()
        {
            return _sortOptions;
        }

        public Object getSortOption(string sortOptionKey, Pokemon pokemon)
        {
            if (sortOptionKey == "ID")
            {
                return pokemon.Id;
            }
            if (sortOptionKey == "Name")
            {
                return pokemon.Name;
            }
            return null;
        }
    }
}

