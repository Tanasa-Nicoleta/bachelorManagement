using BachelorManagement.ApiLayer.Models;
using BachelorManagement.BusinessLayer.Contracts;
using BachelorManagement.BusinessLayer.Interfaces;
using BachelorManagement.BusinessLayer.Services;
using BachelorManagement.DataLayer.Repositories;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    [Route("api")]
    public class AccountController : Controller
    {
        private IRepository<User> _repository;
        private readonly IAccountService _accountService;

        public AccountController()
        {
            _repository = new Repository<User>();
            _accountService = new AccountService(_repository);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_accountService.CheckIfAccountExists(accountDto.Username, accountDto.Password))
                return BadRequest();

            return Ok();

        }
    }
}