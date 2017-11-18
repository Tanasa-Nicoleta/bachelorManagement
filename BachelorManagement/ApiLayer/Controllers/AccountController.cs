using System.Net;
using System.Net.Http;
using ApiLayer.Models;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService AccountService;

        public AccountController(IAccountService accountService)
        {
            AccountService = accountService;
        }

        // POST: api/Account
        public HttpResponseMessage Post([FromBody]AccountDTO accountDTO)
        {
            if (!ModelState.IsValid)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            
            if (!AccountService.CheckIfAccountExists(accountDTO.Username, accountDTO.Password))
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            
            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}