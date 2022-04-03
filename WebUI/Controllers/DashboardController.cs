using Application.Account.Query.GetAccountByToken;
using Application.Customer.Query.GetCustomerByAccountId;
using Application.Dashboard.Command.CreateReservation;
using Application.Dashboard.Query.GetCheckIfPeriodIsFree;
using Application.Dashboard.Query.GetCourtById;
using Application.Dashboard.Query.GetLastMinuteDeals;
using Application.Dashboard.Query.GetListOfCourts;
using Microsoft.AspNetCore.Http;
//using Application.Dashboard.Query.GetCourtById;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class DashboardController : BaseApiController
    {
        //[HttpGet("GetAccountDetailsByToken")]
        //public async Task<GetCustomerByAccountIdDTO> LoginAccountAsync([FromQuery] string token)
        //{
        //    var customer = new GetCustomerByAccountIdDTO();
        //    var account = await Mediator.Send(new GetAccountByTokenQuery
        //    {
        //        Token = token
        //    });
        //    if(account != null)
        //    {
        //        customer = await Mediator.Send(new GetCustomerByAccountIdQuery{ 
        //            Account = account.Account
        //        });
        //    }
        //    return customer;
        //}

        [HttpGet("GetCourtById")]
        public async Task<GetCourtByIdDTO> GetCourtById([FromQuery] int Id)
        {
            var vm = await Mediator.Send(new GetCourtByIdQuery
            {
                Id = Id
            });

            return vm;
        }

        [HttpGet("GetLastMinutesDeals")]
        public async Task<List<Application.Dashboard.Query.GetLastMinuteDeals.GetLastMinuteDealsDTO>> GetLastMinutesDealsAsync()
        {
            return await Mediator.Send(new GetLastMinuteDealsQuery());
        }

        [HttpGet("GetListOfCourts")]
        public async Task<List<Application.Dashboard.Query.GetListOfCourts.GetListOfCourtsDTO>> GetListOfCourtsAsync()
        {
            return await Mediator.Send(new GetListOfCourtsQuery());
        }
        [HttpPost("CreateReservation")]
        public async Task<int> CreateReservationAsync([FromBody] CreateReservationCommand command)
        {
            command.CustomerReservation = HttpContext.Session.GetString("_Username");
            return await Mediator.Send(command);
        }
        [HttpPost("CheckIfPeriodIsFree")]
        public async Task<bool> CheckIfPeriodIsFree([FromBody] GetCheckIfPeriodIsFreeDTO getCheckIfPeriodIsFree)
        {
            return await Mediator.Send(new GetCheckIfPeriodIsFreeQuery
            {
                Reservation = getCheckIfPeriodIsFree.Reservation
            });
        }
    }
}
