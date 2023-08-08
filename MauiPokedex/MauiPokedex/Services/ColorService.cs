using Type = MauiPokedex.Models.Type;
namespace MauiPokedex.Services;

public static class ColorService
{
    private static Dictionary<string, Color> TypeColorMap { get; set; } = new()
        {
            {"normal", Color.FromRgb(194, 191, 183)},
            {"fighting", Color.FromRgb(119, 60, 40)},
            {"flying", Color.FromRgb(137, 154, 235)},
            {"poison", Color.FromRgb(134, 62, 135)},
            {"ground", Color.FromRgb(202, 168, 76)},
            {"rock", Color.FromRgb(146, 124, 51)},
            {"bug", Color.FromRgb(129, 140, 21)},
            {"ghost",Color.FromRgb(96, 94, 176) },
            {"steel", Color.FromRgb(166, 166, 182)},
            {"fire", Color.FromRgb(236, 58, 14)},
            {"water", Color.FromRgb(46, 139, 246)},
            {"grass",  Color.FromRgb(112, 191, 54)},
            {"electric",Color.FromRgb(248, 187, 41) },
            {"psychic", Color.FromRgb(233, 61, 116)},
            {"ice",Color.FromRgb(115, 214, 247) },
            {"dragon", Color.FromRgb(107, 86, 226)},
            {"dark", Color.FromRgb(79, 64, 55)},
            {"fairy", Color.FromRgb(248, 178, 246)},
        };

    public static Color GetColorByType(Type type)
    {
        TypeColorMap.TryGetValue(type.Name.ToLower(), out var color);
        return color;
    }
    public static IEnumerable<Color> GetAllColors()
    {
        return TypeColorMap.Values;
    }
}

