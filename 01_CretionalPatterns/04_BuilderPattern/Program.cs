Console.WriteLine("Builder Pattern...");

var house1 = new HouseBuilder()
    .WithWindows(3)
    .WithWalls(2)
    .WithHeating("Electric")
    .Build();

var house2 = new HouseBuilder()
    .WithWindows(1)
    .WithGarden(true)
    .Build();

Console.ReadLine();

record House(
    int Walls,
    int Windows,
    bool Garden,
    string Heating
    );

interface IHouseBuilder
{
    IHouseBuilder WithWalls(int count);
    IHouseBuilder WithWindows(int count);
    IHouseBuilder WithGarden(bool isHave);
    IHouseBuilder WithHeating(string heating);
    House Build();
}

class HouseBuilder : IHouseBuilder
{
    int _walls;
    int _windows;
    bool _isHaveGarden;
    string _heating = string.Empty;
    public IHouseBuilder WithWalls(int count)
    {
        _walls = count;
        return this;
    }
    public IHouseBuilder WithWindows(int count)
    {
        _windows = count;
        return this;
    }
    public IHouseBuilder WithGarden(bool isHaveGarden)
    {
        _isHaveGarden = isHaveGarden;
        return this;
    }

    public IHouseBuilder WithHeating(string heating)
    {
        _heating = heating;
        return this;
    }

    public House Build()
    {
        return new House(_walls, _windows, _isHaveGarden, _heating);
    }
}