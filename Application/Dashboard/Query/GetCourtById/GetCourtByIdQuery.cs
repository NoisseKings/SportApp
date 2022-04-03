using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dashboard.Query.GetCourtById
{
    public class GetCourtByIdQuery : IRequest<GetCourtByIdDTO>
    {
        public int Id { get; set; }
    }
}
