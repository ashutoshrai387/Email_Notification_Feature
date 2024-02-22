using EmailNotificationFeature.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace EmailNotificationFeature.Services
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IConfiguration _config;

        public PasswordResetService(IConfiguration config)
        {
            _config = config;
        }

        public void SendPasswordResetEmail(PasswordResetDto reset_request)
        {
            string toEmailAddress = reset_request.email_id;
            var email = new MimeMessage();
            var senderName = _config.GetSection("Sendername").Value;
            var senderEmailAddress = _config.GetSection("EmailUsername").Value;
            var senderAddress = new MailboxAddress(senderName, senderEmailAddress);
            email.From.Add(senderAddress);
            email.To.Add(MailboxAddress.Parse(toEmailAddress));
            email.Subject = "Password Reset";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = "This is a password reset email sent from your .NET backend."
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
