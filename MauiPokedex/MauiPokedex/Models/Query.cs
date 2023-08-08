using System;
namespace MauiPokedex.Models;

public class Query
{
    public int SortDirection { get; set; } = 1;
    public string SortItem { get; set; } = "";
    public string SearchQuery { get; set; } = "";
    public string TypeQuery { get; set; } = "";

    public Query()
    {
    }
}

