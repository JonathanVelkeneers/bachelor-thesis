using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinPokedex.Models
{
    public class Type : NamedApiResource
    {
        public Generation Generation { get; set; }
        public List<TypePokemon> Pokemon { get; set; }
    }
}
