using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XamarinPokedex.Models;

namespace XamarinPokedex.Services
{
	public class FilterOptionsService
	{

        private static List<string> _filterOptions = new List<string>();

        static FilterOptionsService()
        {
            _filterOptions.Add("No filter");
            _filterOptions.Add("Normal");
            _filterOptions.Add("Fire");
            _filterOptions.Add("Water");
            _filterOptions.Add("Grass");
            _filterOptions.Add("Flying");
            _filterOptions.Add("Fighting");
            _filterOptions.Add("Poison");
            _filterOptions.Add("Electric");
            _filterOptions.Add("Ground");
            _filterOptions.Add("Rock");
            _filterOptions.Add("Psychic");
            _filterOptions.Add("Ice");
            _filterOptions.Add("Bug");
            _filterOptions.Add("Ghost");
            _filterOptions.Add("Steel");
            _filterOptions.Add("Dragon");
            _filterOptions.Add("Dark");
            _filterOptions.Add("Fairy");
        }
        public List<string> GetFilterOptions()
        {
            return _filterOptions;
        }

        public Object getFilteredOption(string sortOptionKey, Pokemon pokemon)
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

