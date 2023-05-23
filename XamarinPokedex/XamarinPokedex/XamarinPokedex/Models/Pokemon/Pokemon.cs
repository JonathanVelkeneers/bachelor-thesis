using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using XamarinPokedex.Models.Api;
using XamarinPokedex.Services;

namespace XamarinPokedex.Models
{

    public class Pokemon : NamedApiResource
    {
        public int Height { get; set; }

        public int Weight { get; set; }

        public PokemonSprite Sprites { get; set; }

        [JsonProperty("species")]
        public NamedApiReferralResource SpeciesReferral { get; set; }
        public Task<PokemonSpecies> Species()
        {
            return PokemonService.Service.GetSpecies(SpeciesReferral.Name);
        }

        public List<PokemonType> Types { get; set; }

        public ImageSource ImageUrl
        {
            get
            {
                string url = Sprites?.Other?.OfficialArtwork?.FrontDefault;
                if (url == null || url.Length == 0)
                {
                    return "placeholder_4_3.png";
                }
                return new UriImageSource
                {
                    Uri = new Uri(url),
                    CachingEnabled = true,
                    CacheValidity = TimeSpan.FromDays(7)
                };
            }
            private set { }
        }
    }
}
