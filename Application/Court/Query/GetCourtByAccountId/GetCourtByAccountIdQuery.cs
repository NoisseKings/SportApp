using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Court.Query.GetCourtByAccountId
{
    public class GetCourtByAccountIdQuery : IRequest<GetCourtByAccountIdDTO>
    {
        public Domain.Entities.Account Account { get; set; }
    }
}
