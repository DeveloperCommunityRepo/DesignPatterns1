Console.WriteLine("Adapter Pattern....");

ReportService report = new();
var reports = report.Reports();
foreach (var item in reports)
{
    Console.WriteLine(item);
}

Console.ReadLine();

class EmailService
{
    public string To { get; set; } = default!;
    public string Body { get; set; } = default!;
    public List<string> Attachments { get; set; } = new();

    public void SendEmail()
    {
        Console.WriteLine("To: {0}, Body: {1}", To, Body);
        //mail gönder
    }
}

class ReportService
{
    NotificationAdapter notificationAdapter = new();
    public List<object> Reports()
    {
        return notificationAdapter.Reports();
    }
}

class SmsService
{
    public string PhoneNumber { get; set; } = default!;
    public string Message { get; set; } = default!;

    public void SendSms()
    {
        Console.WriteLine("PhoneNumber: {0}, Message: {1}", PhoneNumber, Message);
        //mail gönder
    }
}

class NotificationAdapter
{
    public string To { get; set; } = default!;
    public string Body { get; set; } = default!;

    EmailService emailService = new();
    SmsService smsService = new();

    public List<object> Reports()
    {
        List<object> reports = new();
        reports.Add(new { To = emailService.To, Body = emailService.Body });
        reports.Add(new { To = smsService.PhoneNumber, Body = smsService.Message });

        return reports;
    }
}