using EmailProject.Models.DTO;
using UserProject.Models;

namespace EmailProject.Services
{
    public interface IEmailService
    {
        Task<AttemptDto> SendEmail(string email);
    }
}
