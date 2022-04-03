using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.UpdateUser
{
    public class UpdateuserCommand : IRequest<bool>
    {
        public Domain.Entities.Account User { get; set; }
    }
}
