namespace MillitaryService.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailOtp(string recipientEmail, string link, string receiverName);
    }
}
