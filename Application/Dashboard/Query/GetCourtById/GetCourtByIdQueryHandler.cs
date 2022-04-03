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

namespace Application.Dashboard.Query.GetCourtById
{
    public class GetCourtByIdQueryHandler : IRequestHandler<GetCourtByIdQuery, GetCourtByIdDTO>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCourtByIdQueryHandler(ISportAppDbContext context,
           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCourtByIdDTO> Handle(GetCourtByIdQuery request, CancellationToken cancellationToken)
        {
            //GetCourtByIdDTO result = new GetCourtByIdDTO();
            var result = await _context.Courts.Where(x => x.Id == request.Id)
                                        .ProjectTo<GetCourtByIdDTO>(_mapper.ConfigurationProvider)
                                       .SingleOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}