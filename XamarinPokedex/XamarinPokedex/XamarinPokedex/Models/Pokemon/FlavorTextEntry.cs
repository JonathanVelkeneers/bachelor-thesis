using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinPokedex.Models.Api;
using XamarinPokedex.Services;

namespace XamarinPokedex.Models
{
    public class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        private string _flavorText;
        public string FlavorText()
        {
            return _flavorText.Replace("\t", "").Replace("\n", " ").Replace("\f", " ");
        }

        [JsonProperty("language")]
        public NamedApiReferralResource LanguageReferral { get; set; }
    }
}
