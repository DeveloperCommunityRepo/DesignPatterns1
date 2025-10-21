Console.WriteLine("Abstract factory Pattern");

IFurnitureFactory classicFurniture = FurnitureFactoryProvider.Create(FurnitureTypeEnum.Classic);
IChair chair1 = classicFurniture.CreateChair();
chair1.SitOn();
IChair chair2 = classicFurniture.CreateChair();
ITable table1 = classicFurniture.CreateTable();

IFurnitureFactory modernFurniture = FurnitureFactoryProvider.Create(FurnitureTypeEnum.Modern);
ITable table2 = modernFurniture.CreateTable();

Console.ReadLine();

interface IChair
{
    void SitOn();
}

interface ITable
{
    void Use();
}

class ClassicChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("I sit on classic chair");
    }
}

class ModernChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("I sit on modern chair");
    }
}

class ClassicTable : ITable
{
    public void Use()
    {
        Console.WriteLine("I use classic chair");
    }
}

class ModernTable : ITable
{
    public void Use()
    {
        Console.WriteLine("I use modern chair");
    }
}

interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}

class ClassicFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ClassicChair();
    }

    public ITable CreateTable()
    {
        return new ClassicTable();
    }
}

class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ITable CreateTable()
    {
        return new ModernTable();
    }
}

enum FurnitureTypeEnum
{
    Classic,
    Modern
}

class FurnitureFactoryProvider
{
    public static IFurnitureFactory Create(FurnitureTypeEnum type)
    {
        switch (type)
        {
            case FurnitureTypeEnum.Classic:
                return new ClassicFurnitureFactory();
            case FurnitureTypeEnum.Modern:
                return new ModernFurnitureFactory();
            default:
                throw new ArgumentException("Invalid type");
        }
    }
}