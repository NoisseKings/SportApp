using Application.Account.Query.GetAccountByToken;
using Application.Court.Query.GetCourtByAccountId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class CourtController : BaseApiController
    {
        [HttpGet("LoginCourt")]
        public async Task<GetCourtByAccountIdDTO> LoginAccountAsync([FromQuery] string token)
        {
            GetCourtByAccountIdDTO court = new GetCourtByAccountIdDTO();
            var account = await Mediator.Send(new GetAccountByTokenQuery
            {
                Token = token
            });
            if (account != null)
            {
                //HttpContext.Session.SetString(SessionKeyUserName, account.Account.Customer.Username);
                court = await Mediator.Send(new GetCourtByAccountIdQuery
                {
                    Account = account.Account
                });
                if (court != null)
                {
                    HttpContext.Session.SetString("Court_Id", court.Court.Id.ToString());
                }
            }
            return court;
        }
    }
}
