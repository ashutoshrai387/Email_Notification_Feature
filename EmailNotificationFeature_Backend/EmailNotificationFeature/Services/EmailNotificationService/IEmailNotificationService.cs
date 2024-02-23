namespace EmailNotificationFeature.Services.EmailNotificationService
{
    public interface IEmailNotificationService
    {
        void SendEmail(EmailDto data);
    }
}
