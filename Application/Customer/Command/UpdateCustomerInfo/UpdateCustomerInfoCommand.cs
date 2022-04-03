using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Command.UpdateCustomerInfo
{
    public class UpdateCustomerInfoCommand : IRequest<bool>
    {
        public Domain.Entities.Customer Customer { get; set; }
    }
}
