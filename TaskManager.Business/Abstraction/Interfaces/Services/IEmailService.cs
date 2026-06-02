namespace TaskManager.Business.Abstraction.Interfaces.Services;

public interface IEmailService
{
    Task SendEmail(string to, string subject, string body);
}
