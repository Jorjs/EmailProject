using EmailProject.Models.DTO;
using SharpCompress.Common;
using UserProject.Models;
using UserProject.Services;

namespace EmailProject.Services
{
    public class EmailService: IEmailService
    {
        private IEmailSender _emailSender;
        private IUsersAttemptService _usersAttemptService;

        public EmailService(IEmailSender emailSender, IUsersAttemptService usersAttempt) {
            this._emailSender = emailSender;
            this._usersAttemptService = usersAttempt;
        }

        public async Task<AttemptDto> SendEmail(string email)
        {
            var attempt = await _usersAttemptService.Create(email);

            await _emailSender.SendEmailAsync(email, attempt._id);
            await _usersAttemptService.UpdateStatus(attempt._id, true);

            return new AttemptDto
            {
                Id = attempt._id,
                Email = attempt.Email,
                EmailContent = attempt.EmailContent,
                UserClicked = attempt.UserClicked,
                Sent = true
            };

        }
    }
}
