using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MauiPokedex.Models;
using MauiPokedex.Services;
using MonkeyCache.FileStore;

namespace MauiPokedex.Models
{
    public class Pokemon : NamedApiResource
    {
        public int Height { get; set; }

        public int Weight { get; set; }

        public PokemonSprite Sprites { get; set; }

        [JsonProperty("species")] public NamedApiReferralResource SpeciesReferral { get; set; }

        public Task<PokemonSpecies> GetSpecies() => PokemonService.Service.GetSpecies(SpeciesReferral.Name);

        public List<PokemonType> Types { get; set; }

        public ImageSource ImageUrl
        {
            get
            {
                var url = Sprites?.Other?.OfficialArtwork?.FrontDefault;
                if (string.IsNullOrEmpty(url))
                {
                    return "placeholder_4_3.png";
                }

                return new UriImageSource
                {
                    Uri = new Uri(url),
                    CacheValidity = TimeSpan.FromDays(7)
                };
            }
        }
    }
}