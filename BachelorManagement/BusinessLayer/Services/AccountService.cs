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
            return _userRepository.GetAll()
                       .SingleOrDefault(u =>
                           string.Equals(u.Email.ToLower(), username.ToLower())) != null;
        }
    }
}