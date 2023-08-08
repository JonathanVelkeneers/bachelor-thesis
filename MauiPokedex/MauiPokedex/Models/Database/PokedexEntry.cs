using System;
using SQLite;

namespace MauiPokedex.Models.Database;

public class PokedexEntry
{
    [PrimaryKey]
    public int Id { get; set; }


    public PokedexEntry()
    {
    }
    public PokedexEntry(int Id)
    {
        this.Id = Id;
    }
}

