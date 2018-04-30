using BachelorManagement.ApiLayer.Models;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "true";
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

        [HttpPost("register")]
        public IActionResult Register([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_accountService.CheckIfUserNameExists(accountDto.Username))
                return  BadRequest("Username exists");

            if (!_accountService.AddNewUser(accountDto.Username, accountDto.Password))
                return BadRequest();

            return NoContent();
        }
    }
}