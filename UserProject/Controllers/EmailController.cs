using AutoMapper;
using EmailProject.Models.DTO;
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
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult<AttemptDto>> SendEmail([FromBody] EmailDto sendEmailDto)
        {
            var attempts = await _emailService.SendEmail(sendEmailDto.Email);

            return StatusCode(201, attempts);

        }
    }
}
