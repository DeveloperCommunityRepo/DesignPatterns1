Console.WriteLine("Factory Pattern...");

var notification = NotificationFactory.CreateNotification(NotificationTypeEnum.Sms);
notification.Send("hello world");

var notification2 = NotificationFactory.CreateNotification(NotificationTypeEnum.Email);
notification2.Send("hello world");

var notification3 = NotificationFactory.CreateNotification(NotificationTypeEnum.Whatsapp);
notification3.Send("hello world");

Console.ReadLine();

interface INotification
{
    void Send(string msg);
}
class SmsNotification : INotification
{
    public void Send(string msg)
    {
        Console.WriteLine("I send sms: {0}", msg);
    }
}

class EmailNotification : INotification
{
    public void Send(string msg)
    {
        Console.WriteLine("I send email: {0}", msg);
    }
}

class CloudeNotification : INotification
{
    public void Send(string msg)
    {
        Console.WriteLine("I send clode message: {0}", msg);
    }
}

class WhatpsappNotification : INotification
{
    public void Send(string msg)
    {
        Console.WriteLine("I send whatpsapp message: {0}", msg);
    }
}

class NotificationFactory
{
    public static INotification CreateNotification(NotificationTypeEnum type)
    {
        switch (type)
        {
            case NotificationTypeEnum.Sms:
                return new SmsNotification();
            case NotificationTypeEnum.Email:
                return new EmailNotification();
            case NotificationTypeEnum.Whatsapp:
                return new WhatpsappNotification();
            case NotificationTypeEnum.Cloude:
                return new CloudeNotification();
            default:
                throw new ArgumentException("Invalid notification type");
        }
    }
}

enum NotificationTypeEnum
{
    Sms,
    Email,
    Whatsapp,
    Cloude
}