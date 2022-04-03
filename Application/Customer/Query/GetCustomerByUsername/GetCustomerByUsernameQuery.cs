using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Query.GetCustomerByUsername
{
    public class GetCustomerByUsernameQuery : IRequest<GetCustomerByUsernameDTO>
    {
        public string InputUsername { get; set; }
    }
}
