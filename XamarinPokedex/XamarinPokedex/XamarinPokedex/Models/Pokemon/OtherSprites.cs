using Newtonsoft.Json;

namespace XamarinPokedex.Models
{
    public class OtherSprites
    {
        [JsonProperty("official-artwork")]
        public OfficialArtworkSprite OfficialArtwork { get; set; }
    }
}
