Console.WriteLine("Composite Pattern...");

var file1 = new FileItem("File1.txt", 120);
var file2 = new FileItem("File2.txt", 80);
var file3 = new FileItem("File3.txt", 45);

var subFolder = new FolderItem("SubFoler");
subFolder.Files.Add(file1);

var rootFolder = new FolderItem("RootFolder");
rootFolder.Files.Add(file2);
rootFolder.Files.Add(file3);
rootFolder.Files.Add(subFolder);

rootFolder.Display(0);
Console.WriteLine("Folder Size: {0}", rootFolder.GetSize());

Console.ReadLine();

interface IFileSystem
{
    string Name { get; }
    void Display(int dept);
    int GetSize();
}

class FileItem : IFileSystem
{
    public string Name { get; }
    private int _size;

    public FileItem(string name, int size)
    {
        Name = name;
        _size = size;
    }
    public void Display(int dept)
    {
        Console.WriteLine(new string('-', dept) + Name);
    }

    public int GetSize()
    {
        return _size;
    }
}

class FolderItem : IFileSystem
{
    public string Name { get; }
    public List<IFileSystem> Files { get; set; } = new();
    public FolderItem(string name)
    {
        Name = name;
    }

    public void Display(int dept)
    {
        Console.WriteLine(new string('-', dept) + Name);
        foreach (var item in Files)
        {
            item.Display(dept + 2);
        }
    }

    public int GetSize()
    {
        int total = 0;
        foreach (IFileSystem file in Files)
        {
            total += file.GetSize();
        }

        return total;
    }
}