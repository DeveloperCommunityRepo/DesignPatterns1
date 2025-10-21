using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Singleton Pattern...");

ServiceCollection services = new();
services.AddSingleton<Logger2>();

var srv = services.BuildServiceProvider();
var logger = srv.GetRequiredService<Logger2>();
logger.Log("Hello world");

var logger2 = srv.GetRequiredService<Logger2>();
logger.Log("Hello world");

Console.ReadLine();

class Logger2
{
    public Logger2()
    {

    }
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

#region Classic Singleton Pattern
//Logger.Instance.Log("Hello world1");
//Logger.Instance.Log("Hello world2");
//Logger.Instance.Log("Hello world3");

//LoggerStatic.Log("Hello world");
static class LoggerStatic
{
    public static void Log(string message)
    {
        Logger.Instance.Log(message);
    }
}

class Logger
{
    private static Logger? _instance;
    private static readonly object _lock = new object();
    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance is null)
                {
                    _instance = new Logger();
                }
            }
            return _instance;
        }
    }
    private Logger()
    {

    }
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
#endregion
