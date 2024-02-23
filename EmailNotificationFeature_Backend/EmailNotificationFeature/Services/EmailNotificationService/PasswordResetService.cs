using EmailNotificationFeature.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using MailKit;
using Org.BouncyCastle.Tls;

namespace EmailNotificationFeature.Services
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IConfiguration _config;
        public PasswordResetService(IConfiguration config)
        {
            _config = config;
        }

        public void SendPasswordResetEmail(PasswordResetDto data)
        {
            string receiverEmail = data.emailId;
            string receiverName = data.userName;
            var email = new MimeMessage();
            var senderName = _config.GetSection("Sendername").Value;
            var senderEmailAddress = _config.GetSection("EmailUsername").Value;
            var senderAddress = new MailboxAddress(senderName, senderEmailAddress);
            email.From.Add(senderAddress);
            email.To.Add(MailboxAddress.Parse(receiverEmail));
            email.Subject = "Password Reset Request";

            //Using the templates for email body
            string serviceDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string templatePath = Path.Combine(serviceDirectory, "..", "..", "..", "Templates", "resetPassword.html");
            templatePath = Path.GetFullPath(templatePath);
            if (File.Exists(templatePath))
            {
                string htmlTemplate = File.ReadAllText(templatePath);
                string replacedTemplate = htmlTemplate.Replace("{toNamePlaceholder}", receiverName);

                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = replacedTemplate
                };
            }
            else
            {
                Console.WriteLine("The specified template file does not exist.");
            }

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
