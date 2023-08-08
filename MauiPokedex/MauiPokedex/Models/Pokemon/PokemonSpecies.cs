using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MauiPokedex.Models;

namespace MauiPokedex.Models;

public class PokemonSpecies : NamedApiResource
{
    public int Order { get; set; }

    public Generation Generation { get; set; }

    [JsonProperty("flavor_text_entries")]
    public IEnumerable<FlavorTextEntry> FlavorTextEntries { get; set; }
}
