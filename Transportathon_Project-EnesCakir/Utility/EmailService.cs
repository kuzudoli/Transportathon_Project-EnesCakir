using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using Transportathon_Project_EnesCakir.Configurations;

namespace Transportathon_Project_EnesCakir.Utility
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigurations _emailConfig;

        public EmailService(IOptionsMonitor<EmailConfigurations> emailConfig)
        {
            _emailConfig = emailConfig.CurrentValue;
        }

        public async Task SendResetPasswordEmailAsync(string resetLink, string email)
        {
            var smtpClient = new SmtpClient();
            smtpClient.Host = _emailConfig.Host;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(_emailConfig.Email, _emailConfig.Key);
            smtpClient.EnableSsl = true;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailConfig.Email);
            mailMessage.To.Add(email);
            mailMessage.Subject = "Transportathon | Şifre sıfırlama bağlantısı";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = @$"<h4>Şifrenizi yenilemek için aşağıdaki linke tıklayınız.</h4>
                                <p>
                                    <a href='{resetLink}'>{resetLink}</a>
                                </p>";

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
