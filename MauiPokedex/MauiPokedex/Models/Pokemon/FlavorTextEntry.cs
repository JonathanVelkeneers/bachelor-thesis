using System.Threading.Tasks;
using Newtonsoft.Json;
using MauiPokedex.Models;
using System.Text.Json.Serialization;

namespace MauiPokedex.Models;

public class FlavorTextEntry
{
    [JsonProperty("flavor_text")]
    private string _flavorText;

    public string FlavorText
    {
        get => _flavorText.Replace("\t", "").Replace("\n", " ").Replace("\f", " ");
        set => _flavorText = value;
    }

    [JsonProperty("language")]
    public NamedApiReferralResource LanguageReferral { get; set; }
}