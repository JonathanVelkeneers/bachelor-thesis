namespace MauiPokedex.Models.Api;

public class NamedAPIResourceList<T> where T : NamedApiResource
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public IEnumerable<T> Results { get; set; }
}

