﻿using System.Linq;
using BusinessLayer.Contracts;
using BusinessLayer.Interfaces;
using Interfaces;

namespace BusinessLayer.Services
{
    public class AccountService: IAccountService
    {
        private readonly IRepository<User> UserRepository;

        public AccountService(IRepository<User> userRepository)
        {
            UserRepository = userRepository;
        }

        public bool CheckIfAccountExists(string username, string password)
        {
            return UserRepository.GetAll()
                       .SingleOrDefault(u =>
                           string.Equals(u.Email.ToLower(), username.ToLower()) &&
                           string.Equals(u.Password, password)) != null;
        }
    }
}
