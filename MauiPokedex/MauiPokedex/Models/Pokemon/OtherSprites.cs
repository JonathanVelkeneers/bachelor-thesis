using System;
using Newtonsoft.Json;

namespace MauiPokedex.Models;

public class OtherSprites
{
    [JsonProperty("official-artwork")]
    public OfficialArtworkSprite OfficialArtwork { get; set; }
}