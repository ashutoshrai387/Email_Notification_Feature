using EmailNotificationFeature.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;
using Org.BouncyCastle.Tls;

namespace EmailNotificationFeature.Services.EmailNotificationService
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly IConfiguration _config;

        public EmailNotificationService(IConfiguration config) 
        {
            _config = config;
        }

        public void SendEmail(EmailDto request)
        {
            string toEmailAddress = request.email;
            var email = new MimeMessage();
            var senderName = _config.GetSection("Sendername").Value;
            var senderEmailAddress = _config.GetSection("EmailUsername").Value;
            var senderAddress = new MailboxAddress(senderName, senderEmailAddress);
            email.From.Add(senderAddress);
            //email.To.Add(MailboxAddress.Parse(request.To));
            email.To.Add(MailboxAddress.Parse(toEmailAddress));
            //email.Subject = request.Subject;
            email.Subject = "Test Email";
            //email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = "This is a test email sent from your .NET backend."
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
