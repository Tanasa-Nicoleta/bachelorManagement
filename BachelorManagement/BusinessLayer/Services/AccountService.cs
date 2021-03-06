﻿using System;
using System.Linq;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.DataLayer.Enums;
using BachelorManagement.Interfaces;

namespace BachelorManagement.BusinessLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<User> _userRepository;

        public AccountService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CheckIfAccountExists(string username, string password)
        {
            return _userRepository.GetAll()
                       .SingleOrDefault(u =>
                           string.Equals(u.Email.ToLower(), username.ToLower()) &&
                           string.Equals(u.Password, password)) != null;
        }

        public bool AddNewUser(string username, string password)
        {
            _userRepository.Add(new User
            {
                Email = username,
                Password = password,
                UserType = UserType.Student
            });

            return true;
        }

        public bool CheckIfUserNameExists(string username)
        {
            if (username == null)
                return false;

            return _userRepository.GetAll()
                       .SingleOrDefault(u =>
                           string.Equals(u.Email.ToLower(), username.ToLower())) != null;
        }

        public bool IsTeacher(string username)
        {
            var user = GetUserByEmail(username);

            if (user != null)
                return user.UserType == UserType.Teacher;

            return false;
        }

        public Guid? GetAccesToken(string username)
        {
            var user = GetUserByEmail(username);

            return user?.Token;
        }

        public Guid AddAccesToken(string username)
        {
            var user = GetUserByEmail(username);

            if (user != null)
            {               
                user.Token = Guid.NewGuid();
                _userRepository.Update(user);
            }

            return user.Token;
        }

        public bool CheckTheTokenValidity(string username, Guid token)
        {
            var user = GetUserByEmail(username);

            if(user != null)
                return user.Token == token;

            return false;
        }

        private User GetUserByEmail(string email)
        {
            return _userRepository.GetAll().FirstOrDefault(u => u.Email == email);
        }
    }

}