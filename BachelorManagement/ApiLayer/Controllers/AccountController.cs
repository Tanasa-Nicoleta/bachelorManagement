using System.Net;
using System.Net.Http;
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("api/Login")]
        public HttpResponseMessage Post([FromBody]AccountDTO accountDto)
        {
            if (!ModelState.IsValid)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            
            if (!_accountService.CheckIfAccountExists(accountDto.Username, accountDto.Password))
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            
            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}