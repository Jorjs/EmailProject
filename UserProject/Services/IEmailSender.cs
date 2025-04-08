namespace EmailProject.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string id);
    }
}
