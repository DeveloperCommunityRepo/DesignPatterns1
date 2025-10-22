Console.WriteLine("Decorator Pattern...");

IDrink coffee = new Coffee();
Console.WriteLine("{0} - {1}", coffee.GetDescription(), coffee.GetCost());

IDrink milkCoffee = new MilkDecorator(coffee);
Console.WriteLine("{0} - {1}", milkCoffee.GetDescription(), milkCoffee.GetCost());

IDrink sugarCoffee = new SugarDecorator(milkCoffee);
Console.WriteLine("{0} - {1}", sugarCoffee.GetDescription(), sugarCoffee.GetCost());

Console.ReadLine();

interface IDrink
{
    string GetDescription();
    decimal GetCost();
}

class Coffee : IDrink
{
    public decimal GetCost()
    {
        return 25;
    }

    public string GetDescription()
    {
        return "Regular Coffee";
    }
}

abstract class DrinkDecorator : IDrink
{
    public readonly IDrink _drink;

    protected DrinkDecorator(IDrink drink)
    {
        _drink = drink;
    }

    public abstract decimal GetCost();

    public abstract string GetDescription();
}

class MilkDecorator : DrinkDecorator
{
    public MilkDecorator(IDrink drink) : base(drink)
    {
    }

    public override decimal GetCost()
    {
        return _drink.GetCost() + 10;
    }

    public override string GetDescription()
    {
        return _drink.GetDescription() + ", Milk";
    }
}

class SugarDecorator : DrinkDecorator
{
    public SugarDecorator(IDrink drink) : base(drink)
    {
    }

    public override decimal GetCost()
    {
        return _drink.GetCost() + 5;
    }

    public override string GetDescription()
    {
        return _drink.GetDescription() + ", Sugar";
    }
}