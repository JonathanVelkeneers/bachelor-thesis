using System.Collections.Generic;

namespace XamarinPokedex.Models
{
    public class PokemonEvolutionChain : ApiResource
    {
        public ChainLink Chain { get; set; }
    }

    public class ChainLink
    {
        public PokemonSpecies Species { get; set; }

        public List<ChainLink> EvolvesTo { get; set; }
    }
}
