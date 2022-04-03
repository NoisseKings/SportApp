using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Query.GetCustomerByAccountId
{
    public class GetCustomerByAccountIdQuery : IRequest<GetCustomerByAccountIdDTO>
    {
        public Domain.Entities.Account Account { get; set; }
    }
}
