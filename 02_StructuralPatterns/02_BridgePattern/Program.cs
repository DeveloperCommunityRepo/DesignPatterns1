Console.WriteLine("Bridge Pattern...");

IDevice tv = new TvDevice();
IDevice radio = new RadioDevice();

IRemote remote = new Remote(radio);
remote.TogglePower();
remote.TogglePower();

Console.ReadLine();

interface IDevice
{
    bool IsOpen { get; set; }
    void Open();
    void Close();
    void SetVolume(int volume);
    void Mute();
}

class TvDevice : IDevice
{
    public bool IsOpen { get; set; }

    public void Close()
    {
        Console.WriteLine("Tv closed...");
        IsOpen = false;
    }

    public void Mute()
    {
        Console.WriteLine("Tv muted...");
    }

    public void Open()
    {
        Console.WriteLine("Tv opened...");
        IsOpen = true;
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine("Tv volume set: {0}", volume);
    }
}

class RadioDevice : IDevice
{
    public bool IsOpen { get; set; }
    public void Close()
    {
        Console.WriteLine("Radio closed...");
        IsOpen = false;
    }

    public void Mute()
    {
        Console.WriteLine("Radio muted...");
    }

    public void Open()
    {
        Console.WriteLine("Radio opened...");
        IsOpen = true;
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine("Radio volume set: {0}", volume);
    }
}

interface IRemote
{
    void TogglePower();
    void Mute();
    void SetVolume(int volume);
}

class Remote(IDevice device) : IRemote
{
    public void Mute()
    {
        device.Mute();
    }

    public void SetVolume(int volume)
    {
        device.SetVolume(volume);
    }

    public void TogglePower()
    {
        if (device.IsOpen)
        {
            device.Close();
        }
        else
        {
            device.Open();
        }
    }
}