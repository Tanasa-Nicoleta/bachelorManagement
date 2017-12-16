using System.Linq;
using BachelorManagement.BusinessLayer.Contracts;
using BachelorManagement.BusinessLayer.Interfaces;
using BachelorManagement.Interfaces;

namespace BachelorManagement.BusinessLayer.Services
{
    public class AccountService: IAccountService
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
    }
}
