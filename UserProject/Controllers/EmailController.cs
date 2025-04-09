using AutoMapper;
using EmailProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserProject.Models;
using UserProject.Models.DTO;
using UserProject.Repositories;
using UserProject.Services;

namespace UserProject.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly IUsersAttemptService _usersAttemptService;

        public EmailController(IUsersAttemptService usersAttemptService, IEmailSender emailSender)
        {
            _usersAttemptService = usersAttemptService;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailDto sendEmailDto)
        {
            var attempt = await _usersAttemptService.Create(sendEmailDto);
            await _emailSender.SendEmailAsync(sendEmailDto.Email, attempt._id);

            return StatusCode(StatusCodes.Status201Created);

        }
    }
}
