using EmailProject.EmailInfo;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;


namespace EmailProject.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value; ;
        }
        public async Task SendEmailAsync(string email, string id)
        {
            var message = new MimeMessage();
            string messageBody = _emailSettings.Template.Replace("{id}", id);

            message.From.Add(new MailboxAddress("", _emailSettings.SendEmail));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = _emailSettings.Subject;

            message.Body = new TextPart("html")
            {
                Text = messageBody
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, _emailSettings.SecureSocketOption);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}



