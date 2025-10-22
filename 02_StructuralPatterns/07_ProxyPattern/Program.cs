Console.WriteLine("Proxy Pattern...");

IImage image = new ImageProxy("Ağaç");
image.Display();
image.Display();

Console.ReadLine();

interface IImage
{
    void Display();
}

class RealImage : IImage
{
    private readonly string _name;
    private bool _loaded;
    public RealImage(string name)
    {
        _name = name;
        _loaded = false;
    }

    private void LoadFromDisk()
    {
        if (_loaded) return;
        Console.WriteLine("File loading from disk: {0}", _name);
        System.Threading.Thread.Sleep(200);
        _loaded = true;
    }

    public void Display()
    {
        LoadFromDisk();
        Console.WriteLine("[RealImage] Displaying {0}", _name);
    }
}

class ImageProxy : IImage
{
    private readonly string _name;
    private RealImage? _image;
    public ImageProxy(string name)
    {
        _name = name;
    }
    public void Display()
    {
        _image ??= new RealImage(_name);
        _image.Display();
    }
}