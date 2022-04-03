using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Dashboard.Query.GetListOfCourts
{
    public class GetListOfCourtsQueryHandler : IRequestHandler<GetListOfCourtsQuery, List<GetListOfCourtsDTO>>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetListOfCourtsQueryHandler(ISportAppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetListOfCourtsDTO>> Handle(GetListOfCourtsQuery request, CancellationToken cancellationToken)
        {
            List<GetListOfCourtsDTO> result = await _context.Courts
                   .OrderBy(x => x.Name)
                   .Take(8)
                   .ProjectTo<GetListOfCourtsDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return result;
        }
    }
}
