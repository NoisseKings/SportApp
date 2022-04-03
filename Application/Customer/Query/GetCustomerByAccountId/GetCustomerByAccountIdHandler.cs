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

namespace Application.Customer.Query.GetCustomerByAccountId
{
    public class GetCustomerByAccountIdHandler : IRequestHandler<GetCustomerByAccountIdQuery, GetCustomerByAccountIdDTO>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByAccountIdHandler(ISportAppDbContext context,
           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetCustomerByAccountIdDTO> Handle(GetCustomerByAccountIdQuery request, CancellationToken cancellationToken)
        {
            GetCustomerByAccountIdDTO customerByAccountIdDTO = new GetCustomerByAccountIdDTO();
            var getCustomer = await _context.Customers.Where(c => c.AccountId == request.Account.Id).SingleOrDefaultAsync(cancellationToken);

            customerByAccountIdDTO.Customer = getCustomer;

            return customerByAccountIdDTO;
        }
    }
}
