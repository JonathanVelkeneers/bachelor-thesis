using System;
using System.Collections.Generic;
namespace MauiPokedex.Models;

public class ApiListResource<T>
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public IEnumerable<T> Results { get; set; }
    public ApiListResource()
    {
    }
}
