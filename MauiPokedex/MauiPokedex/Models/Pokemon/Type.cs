using System.Collections.Generic;

namespace MauiPokedex.Models;

public class Type : NamedApiResource
{
    public Generation Generation { get; set; }
    public List<TypePokemon> Pokemon { get; set; }
}
