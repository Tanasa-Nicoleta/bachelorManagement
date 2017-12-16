using System.Net;
using System.Net.Http;
using System.Web.Http;
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.Interfaces;

namespace BachelorManagement.ApiLayer.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("api/Login")]
        public IHttpActionResult Post([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest));

            if (!_accountService.CheckIfAccountExists(accountDto.Username, accountDto.Password))
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest));

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));

        }
    }
}