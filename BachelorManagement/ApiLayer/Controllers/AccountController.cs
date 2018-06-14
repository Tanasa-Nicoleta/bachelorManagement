using BachelorManagement.ApiLayer.Models;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BachelorManagement.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IStudentService _studentService;

        public AccountController(IAccountService accountService, IStudentService studentService)
        {
            _accountService = accountService;
            _studentService = studentService;
        }

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
                return BadRequest("Invalid model state");

            if (_accountService.CheckIfUserNameExists(accountDto.Username))
                return BadRequest("Username exists");

            if (!_accountService.AddNewUser(accountDto.Username, accountDto.Password))
                return BadRequest();
            
            _studentService.AddStudent(new Student 
                { 
                    Accepted = false,
                    Denied = false,
                    Pending = false,
                    Email = accountDto.Username,
                    TeacherId = 4
                });

            return NoContent();
        }

        [HttpPost("register/check")]
        public IActionResult Register([FromBody] RegisterCheckDto registerCheckDto)
        {
            if (_accountService.CheckIfUserNameExists(registerCheckDto.Email))
                return BadRequest("Username exists");

            return NoContent();
        }

        [HttpPost("checkUserType")]
        public IActionResult CheckUserType([FromBody] AccountDto accountDto)
        {
            if (_accountService.IsTeacher(accountDto.Username))
                return Ok("True");

            return Ok("False");
        }

        [HttpGet("getAccessToken/{email}")]
        public IActionResult GetAccesToken(string email)
        {
            var token = _accountService.GetAccesToken(email);

            if ( token != Guid.Empty)
                return Ok(token);

            return Ok("False");
        }

        [HttpPut("addAccessToken")]
        public IActionResult AddAccesToken([FromBody] AccountDto accountDto)
        {
            var token = _accountService.AddAccesToken(accountDto.Username);

            return Ok(token);
        }
    }
}