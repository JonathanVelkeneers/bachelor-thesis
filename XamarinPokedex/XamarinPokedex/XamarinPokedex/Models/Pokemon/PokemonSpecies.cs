using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinPokedex.Models.Api;
using XamarinPokedex.Services;

namespace XamarinPokedex.Models
{
    public class PokemonSpecies : NamedApiResource
    {
        public int Order { get; set; }

        public bool HasGenderDifferences { get; set; }

        [JsonProperty("evolves_from_species")]
        public NamedApiReferralResource EvolvesFromSpeciesReferral { get; set; }
        public Task<PokemonSpecies> EvolvesFromSpecies()
        {
            return PokemonService.Service.GetSpecies(EvolvesFromSpeciesReferral.Name);
        }

        [JsonIgnore]
        public PokemonEvolutionChain EvolutionChain { get; set; }

        [JsonProperty("evolution_chain")]
        public ApiReferralResource EvolutionChainReferral { get; set; }

        public Generation Generation { get; set; }

        [JsonProperty("flavor_text_entries")]
        public List<FlavorTextEntry> FlavorTextEntries { get; set; }
    }
}
