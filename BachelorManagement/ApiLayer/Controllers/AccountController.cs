using System.Web.Http;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    [RoutePrefix("api")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController()
        {
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("login")]
        public string Get()
        {
            //if (!ModelState.IsValid)
            //    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest));

            //if (!_accountService.CheckIfAccountExists(accountDto.Username, accountDto.Password))
            //    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest));

            return "OK";

        }
    }
}