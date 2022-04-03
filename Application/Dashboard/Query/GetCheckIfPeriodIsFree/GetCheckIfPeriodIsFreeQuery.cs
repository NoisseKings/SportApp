using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dashboard.Query.GetCheckIfPeriodIsFree
{
    public class GetCheckIfPeriodIsFreeQuery : IRequest<bool>
    {
        public Domain.Entities.Reservation Reservation { get; set; } 
    }
}
