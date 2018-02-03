using BachelorManagement.ApiLayer.Models;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    [Route("api")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        [HttpPost("login")]
        public IActionResult Login(AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_accountService.CheckIfAccountExists(accountDto.Username, accountDto.Password))
                return BadRequest();

            return Ok();

        }
    }
}