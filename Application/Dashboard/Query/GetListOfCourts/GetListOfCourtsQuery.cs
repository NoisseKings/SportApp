using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dashboard.Query.GetListOfCourts
{
    public class GetListOfCourtsQuery : IRequest<List<GetListOfCourtsDTO>>
    {
    }
}
