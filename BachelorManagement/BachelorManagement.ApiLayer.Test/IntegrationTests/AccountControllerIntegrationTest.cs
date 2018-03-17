using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Results;
using BachelorManagement.ApiLayer.Controllers;
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.BusinessLayer.Contracts;
using BachelorManagement.BusinessLayer.Contracts.Enums;
using BachelorManagement.BusinessLayer.Interfaces;
using BachelorManagement.BusinessLayer.Services;
using BachelorManagement.DataLayer.Repositories;
using BachelorManagement.Interfaces;
using NUnit.Framework;

namespace BachelorManagement.ApiLayer.Test.IntegrationTests
{
    [TestFixture]
    internal class AccountControllerIntegrationTest
    {

        private AccountController _accountController;

        private AccountDto _accountDto;

        private IAccountService _accountService;

        private IRepository<User> _userRepository;

        private const string username = "accountIntegrationTest@endava.com";
        private const string password = "Test1!";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            //_accountDto = new AccountDto();
            //_userRepository =new Repository<User>();
            //_accountService = new AccountService(_userRepository);
        }

        [SetUp]
        //public void SetUp()
        //{
        //    _accountController = new AccountController()
        //    {
        //        Request = new HttpRequestMessage(),
        //        Configuration = new HttpConfiguration()
        //    };

        //    _userRepository.Add(new User()
        //    {
        //        UserType = UserType.Student,
        //        Email = username,
        //        Password = password
        //    });

        //    _accountDto.Username = username;
        //    _accountDto.Password = password;
        //}


        [Test]
        public void PostWithInvalidUsername_ReturnsBadRequest()
        {
            //_accountController.ModelState.AddModelError("checkIfInvalid", "false");

            ////change username to invalid so that the model state becomes invalid
            //_accountDto.Username = "invalidUsername";

            //var result = _accountController.Post(_accountDto);
            //var statusCode = result.ExecuteAsync(CancellationToken.None).Result.StatusCode;

            //Assert.IsInstanceOf<ResponseMessageResult>(result);
            //Assert.AreEqual(statusCode, HttpStatusCode.BadRequest);
        }
    }
}
