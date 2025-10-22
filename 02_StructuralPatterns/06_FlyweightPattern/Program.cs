Console.WriteLine("Flyweight Pattern...");

var forest = new Forest();
forest.PlantTree(5, 10, "Çam", "Kırmızı", "cam.png");
forest.PlantTree(15, 20, "Kavak", "Yeşil", "kavak.png");
forest.PlantTree(20, 25, "Çam", "Kırmızı", "cam.png");
forest.PlantTree(35, 40, "Kavak", "Yeşil", "kavak.png");

forest.Draw();

Console.ReadLine();

record TreeType(
    string Name,
    string Color,
    string Texture)
{
    public void Draw(int x, int y)
    {
        Console.WriteLine("Draw {0} at ({1},{2}) with Color={3}, Texture={4}", Name, x, y, Color, Texture);
    }
}

record Tree(
    int x,
    int y,
    TreeType TreeType)
{
    public void Draw() => TreeType.Draw(x, y);
}

static class TreeFactory
{
    public static Dictionary<string, TreeType> _cached = new();
    public static int CacheCount => _cached.Count;
    public static TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}|{color}|{texture}";
        if (_cached.TryGetValue(key, out var type))
        {
            Console.WriteLine("Tree with cache");
            return type;
        }

        Console.WriteLine("New Tree");
        type = new TreeType(name, color, texture);
        _cached[key] = type;
        return type;
    }
}

class Forest
{
    private List<Tree> _trees = new();
    public void PlantTree(int x, int y, string name, string color, string texture)
    {
        var type = TreeFactory.GetTreeType(name, color, texture);
        _trees.Add(new Tree(x, y, type));
    }
    public void Draw()
    {
        foreach (var item in _trees)
        {
            item.Draw();
        }
    }
}