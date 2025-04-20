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
        private readonly IUsersAttemptRepository _usersAttemptRepository;

        public UsersAttemptService(IUsersAttemptRepository userRepository, IOptions<EmailSettings> emailSettings) 
        {
            _emailSettings = emailSettings.Value; ;
            _usersAttemptRepository = userRepository;
        }


        public async Task<UsersAttempts> Create(string email)
        {
            var userAttemptModel = new UsersAttempts()
            {
                Email = email,
                UserClicked = false,
                EmailContent = _emailSettings.Template
            };

            var userModels = await _usersAttemptRepository.Create(userAttemptModel);

            return userModels;
        }
        public async Task UpdateStatus(string id, bool sent)
        {
            var userModels = await _usersAttemptRepository.UpdateStatus(id, sent);

            if(userModels.ModifiedCount == 0)
            {
                throw new KeyNotFoundException($"Attempt {id} not found");
            }
        }



    }
}
