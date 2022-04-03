using Application.Common.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dashboard.Query.GetCheckIfPeriodIsFree
{
    public class GetCheckIfPeriodIsFreeDTO
    {
        public Domain.Entities.Reservation Reservation { get; set; }
    }
}
