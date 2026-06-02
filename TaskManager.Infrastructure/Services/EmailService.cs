using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using TaskManager.Business.Abstraction.Interfaces.Services;

namespace TaskManager.Infrastructure.Services;

public class EmailService : IEmailService
{
    //private readonly string email = "mamadbagheriwork@gmail.com";
    //private readonly string appPassword = "rmqv luym pbkx bgzw";
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task SendEmail(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("OtpMail", _configuration["GoogleCreds:Email"]));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;
        message.Body = new TextPart("plain") { Text = body };

        using var client = new SmtpClient();
        await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_configuration["GoogleCreds:Email"], _configuration["GoogleCreds:AppPassword"]);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
