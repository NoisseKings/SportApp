using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace Application.Dashboard.Query.GetLastMinuteDeals
{
    public class GetLastMinuteDealsQueryHandler : IRequestHandler<GetLastMinuteDealsQuery, List<GetLastMinuteDealsDTO>>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetLastMinuteDealsQueryHandler(ISportAppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetLastMinuteDealsDTO>> Handle(GetLastMinuteDealsQuery request, CancellationToken cancellationToken)
        {
            List<GetLastMinuteDealsDTO> result = await _context.Courts
                .OrderBy(x => x.Name)
                .Take(4)
                .ProjectTo<GetLastMinuteDealsDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return result;
        }
    }
}
