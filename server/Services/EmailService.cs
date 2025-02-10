using System.Net;
using System.Net.Mail;

namespace Server.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendFeedbackEmail(string email, string rating)
        {
            string senderEmail = _config["Email:Sender"] ?? throw new ArgumentNullException("Email:Sender configuration is missing.");
            string senderPassword = _config["Email:Password"] ?? throw new ArgumentNullException("Email:Password configuration is missing.");

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true;

                var message = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = "Gracias por tu valoración",
                    Body = $"Tu valoración fue: {rating}",
                    IsBodyHtml = true
                };

                message.To.Add(email);
                smtp.Send(message);
            }
        }
    }
}