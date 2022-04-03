using Application.Account.Command.CreateUser;
using Application.Account.Command.UpdateUser;
using Application.Account.Query.GetAccountByEmail;
using Application.Account.Query.GetAccountByEmailAndPassword;
//using Application.Account.Command.UpdateUser;
using Application.Account.Query.GetAccountByUserNameAndPassword;
using Microsoft.AspNetCore.Http;
//using Application.CourtAccount.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    
    public class AccountController : BaseApiController
    {
        public const string SessionKeyUserName = "_Username";

        [HttpGet("LoginCustomer")]
        public async Task<GetAccountByUserNameAndPasswordDTO> LoginAccountAsync([FromQuery] AccountVM account)
        {
            var vm = await Mediator.Send(new GetAccountByUserNameAndPasswordQuery
            {
                UsernameInput = account.UserName,
                PasswordInput = account.Password
            });

            if (vm.Token != "")
            {
                HttpContext.Session.SetString(SessionKeyUserName, account.UserName);
                return vm;
            }
            else
            {
                return null;
            }
        }
        [HttpPost("CreateUserCommand")]
        public async Task<ActionResult<CreateUserCommand>> RegistrationAccountAsync([FromBody] CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("GetCustomerSession")]
        public async Task<string> GetCustomerSessionAsync()
        {
            string session = HttpContext.Session.GetString(SessionKeyUserName);
            return session;
        }
        

        [HttpGet("LoginCourt")]
        public async Task<GetAccountByEmailAndPasswordDTO> LoginCourtAsync([FromQuery] CourtAccountVM courtAccount)
        {
            var vm = await Mediator.Send(new GetAccountByEmailAndPasswordQuery
            {
                Email = courtAccount.Email,
                Password = courtAccount.Password
            });

            return vm;
        }

        [HttpGet("UserForgotPassword")]
        public async Task<ActionResult<GetAccountByEmailDTO>> UserForgotPasswordAsync([FromQuery] string email)
        {
            var vm = await Mediator.Send(new GetAccountByEmailQuery
            {
                EmailInput = email
            });

            return vm;
        }

        //[HttpPost("UpdateUserInfo")]
        //public async Task<ActionResult<bool>> UpdateUserInfo([FromBody] UpdateuserCommand command)
        //{
        //    return (ActionResult<bool>)await Mediator.Send(command);
        //}
    }
}
