using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Court.Query.GetCourtByAccountId
{
    public class GetCourtByAccountIdHandler : IRequestHandler<GetCourtByAccountIdQuery, GetCourtByAccountIdDTO>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCourtByAccountIdHandler(ISportAppDbContext context,
           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCourtByAccountIdDTO> Handle(GetCourtByAccountIdQuery request, CancellationToken cancellationToken)
        {
            GetCourtByAccountIdDTO customerByAccountIdDTO = new GetCourtByAccountIdDTO();
            var getCustomer = await _context.Courts.Where(c => c.AccountId == request.Account.Id).SingleOrDefaultAsync(cancellationToken);
            customerByAccountIdDTO.Court = getCustomer;

            return customerByAccountIdDTO;
        }
    }
}
