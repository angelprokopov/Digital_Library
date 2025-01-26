using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace Digital_Library.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;  
        public EmailSender(IConfiguration configuration) { _config = configuration; }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpHost = _config["EmailSettings:SMTPHost"];
            var smtpPort = int.Parse(_config["EmailSettings:SMTPPort"]);

            using var smtpClient = new SmtpClient
            {
                Host = smtpHost,
                Port = smtpPort,
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(email),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
