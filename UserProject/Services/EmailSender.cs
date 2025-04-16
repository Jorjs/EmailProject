using EmailProject.EmailInfo;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;


namespace EmailProject.Services
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value; ;
        }
        public async Task SendEmailAsync(string email, string id)
        {
            var message = new MimeMessage();
            string messageBody = _emailSettings.Template.Replace("{id}", id);

            message.From.Add(new MailboxAddress("Sender Name", _emailSettings.SendEmail));
            message.To.Add(new MailboxAddress("Recipient Name", email));
            message.Subject = "Your credit card details have been stole";

            message.Body = new TextPart("html")
            {
                Text = messageBody
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("localhost", 25, SecureSocketOptions.None);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}



