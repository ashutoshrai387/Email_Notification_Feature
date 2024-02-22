namespace EmailNotificationFeature.Services
{
    public interface IPasswordResetService
    {
        void SendPasswordResetEmail(PasswordResetDto request);
    }
}
