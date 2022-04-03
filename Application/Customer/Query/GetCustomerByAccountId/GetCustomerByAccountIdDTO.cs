using Application.Common.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Query.GetCustomerByAccountId
{
    public class GetCustomerByAccountIdDTO
    {
        public Domain.Entities.Customer Customer { get; set; }
    }
}
