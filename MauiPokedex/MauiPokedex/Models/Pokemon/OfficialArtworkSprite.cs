using Newtonsoft.Json;

namespace MauiPokedex.Models;

public class OfficialArtworkSprite
{
    [JsonProperty("front_default")]
    public string FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string FrontShiny { get; set; }
}
