Console.WriteLine("Prototype Pattern...");

Product product = new();
product.Name = "Bilgisayar";
product.Price = 10000;

Product product2 = (Product)product.Clone();
product2.Name = "Laptop";

Console.WriteLine("Product1 Name: {0}", product.Name);
Console.WriteLine("Product2 Name: {0}", product2.Name);

Console.ReadLine();

class Product : ICloneable
{
    public Product()
    {
        Id = Guid.CreateVersion7();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

    public object Clone()
    {
        return new Product()
        {
            Name = Name,
            Price = Price
        };
    }
}