using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.CreateUser
{
    public class CreateUserCommand: IRequest<CreateUserCommand>
    {
        public Domain.Entities.Customer Customer { get; set; }
        public Domain.Entities.Court Court { get; set; }
    }
}
