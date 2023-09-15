namespace Transportathon_Project_EnesCakir.Utility
{
    public interface IEmailService
    {
        Task SendResetPasswordEmailAsync(string resetLink, string email);
    }
}
