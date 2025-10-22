Console.WriteLine("Facade Pattern...");

var shop = new ShopFacade();
shop.PlaceOrder("Bilgisayar", "Taner Saydam", "1111", "Kayseri");

Console.ReadLine();

class InventoryService
{
    public bool IsAvailable(string product)
    {
        Console.WriteLine("[Inventory] Checking availability for {0}", product);
        return true;
    }
}

class PaymentService
{
    public bool Pay(string customer, string cardNumber)
    {
        Console.WriteLine("[Payment] Processing payment for {0}", customer);
        return true;
    }
}

class DeliveryService
{
    public void Delivery(string product, string address)
    {
        Console.WriteLine("[Delivery] Scheduling delivery of {0} to {1}", product, address);
    }
}

class ShopFacade
{
    private readonly InventoryService inventoryService = new();
    private readonly PaymentService paymentService = new();
    private readonly DeliveryService deliveryService = new();

    public void PlaceOrder(string product, string customer, string cardNumber, string address)
    {
        bool productIsAvailable = inventoryService.IsAvailable(product);
        bool IsPay = paymentService.Pay(customer, cardNumber);
        deliveryService.Delivery(product, address);
    }
}