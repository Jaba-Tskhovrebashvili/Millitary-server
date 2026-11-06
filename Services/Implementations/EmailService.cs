using MailKit.Net.Smtp;
using MillitaryService.Services.Interfaces;
using MimeKit;

namespace MillitaryService.Services.Implementations
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailOtp(
        string recipientEmail,
        string link,
        string receiverName)
        {
            var message = new MimeMessage();

            var smtpUser = _configuration["EmailSettings:SMTP_USER"];

            message.From.Add(
                new MailboxAddress(smtpUser, smtpUser));

            message.To.Add(
                new MailboxAddress(receiverName, recipientEmail));

            message.Subject = $"Hello {receiverName}";

            var clientAddress = _configuration["Client:Address"];

            var verificationUrl =
                $"{clientAddress}/sign-up?token={Uri.EscapeDataString(link)}";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
                <h3>Hello {System.Net.WebUtility.HtmlEncode(receiverName)}</h3>
                <p>Your verification link:</p>
                <a href=""{System.Net.WebUtility.HtmlEncode(verificationUrl)}"">
                    Click here
                </a>"
            };

            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient(); 

            await client.ConnectAsync(
                _configuration["EmailSettings:SMTP_HOST"],
                int.Parse(_configuration["EmailSettings:PORT"]!),
                MailKit.Security.SecureSocketOptions.StartTls);

            await client.AuthenticateAsync(
                smtpUser,
                _configuration["EmailSettings:SMTP_PASSWORD"]);

            await client.SendAsync(message);

            await client.DisconnectAsync(true);
        }
    }
}
