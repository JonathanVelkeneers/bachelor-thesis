using System.Collections.Generic;
using Newtonsoft.Json;

namespace XamarinPokedex.Models
{
    public class Generation : NamedApiResource
    {
        // This class contains all the new stuff introduces in a new Generation
        [JsonProperty("pokemon_species")]
        public List<PokemonSpecies> PokemonSpecies { get; set; }

        public List<Type> Types { get; set; }
    }
}
