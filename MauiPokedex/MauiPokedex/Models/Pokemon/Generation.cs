using System.Collections.Generic;
using Newtonsoft.Json;

namespace MauiPokedex.Models;

public class Generation : NamedApiResource
{
    [JsonProperty("pokemon_species")]
    public List<PokemonSpecies> PokemonSpecies { get; set; }

    public List<Type> Types { get; set; }
}
