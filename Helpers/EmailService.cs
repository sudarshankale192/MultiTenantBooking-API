using System.Configuration;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MultiTenantBookingAPI.Helpers
{
    public static class EmailService
    {
        private static readonly string apiKey = ConfigurationManager.AppSettings["SendGridApiKey"];

        public static async Task SendConfirmationEmailAsync(string toEmail, string subject, string body)
        {
            if (!FeatureFlagManager.IsNotificationEnabled())
                return; // Feature disabled, skip sending email

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(FeatureFlagManager.GetSenderEmail(), "No Reply");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            var response = await client.SendEmailAsync(msg);
            // Optional: log response status
        }
    }
}