using AutoMapper;
using UserProject.Models;
using UserProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserProject.Exceptions;
using UserProject.Models.DTO;
using EmailProject.EmailInfo;
using EmailProject.Services;
using Microsoft.Extensions.Options;

namespace UserProject.Services
{
    public class UsersAttemptService : IUsersAttemptService
    {
        private EmailSettings _emailSettings;
        private readonly IUsersAttemptRepository _userRepository;

        public UsersAttemptService(IUsersAttemptRepository userRepository, IOptions<EmailSettings> emailSettings) 
        {
            _emailSettings = emailSettings.Value; ;
            _userRepository = userRepository;
        }


        public async Task<UsersAttempts> Create(EmailDto emailInfo)
        {
            //string messageBody = _emailSettings.Template.Replace("{id}", id);

            var userAttemptModel = new UsersAttempts()
            {
                Email = emailInfo.Email,
                UserClicked = false,
                EmailContent = _emailSettings.Template
            };

            var userModels = await _userRepository.Create(userAttemptModel);

            return userModels;
        }



    }
}
