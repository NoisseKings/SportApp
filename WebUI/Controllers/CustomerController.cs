using Application.Account.Query.GetAccountByToken;
using Application.Customer.Command.UpdateCustomerInfo;
using Application.Customer.Query.GetCustomerByAccountId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class CustomerController : BaseApiController
    {
        public const string SessionKeyUserName = "_Username";
        [HttpGet("LoginCustomer")]
        public async Task<GetCustomerByAccountIdDTO> LoginCustomerAsync([FromQuery] string token)
        {
            var customer = new GetCustomerByAccountIdDTO();
            var account = await Mediator.Send(new GetAccountByTokenQuery
            {
                Token = token
            });
            if (account != null)
            {
                //HttpContext.Session.SetString(SessionKeyUserName, account.Account.Customer.Username);
                customer = await Mediator.Send(new GetCustomerByAccountIdQuery
                {
                    Account = account.Account
                });
                if(customer != null)
                {
                    HttpContext.Session.SetString(SessionKeyUserName, customer.Customer.Username);
                }
            }
            return customer;
        }

        [HttpPost("UpdateCustomerInfo")]
        public async Task<ActionResult<bool>> UpdateCustomerInfo([FromBody] UpdateCustomerInfoCommand command)
        {
            return (ActionResult<bool>)await Mediator.Send(command);
        }
    }
}
