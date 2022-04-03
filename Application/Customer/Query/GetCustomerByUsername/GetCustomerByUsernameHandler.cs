using Application.Common.Interfaces;
using Application.Dashboard.Command.CreateReservation;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customer.Query.GetCustomerByUsername
{
    public class GetCustomerByUsernameHandler : IRequestHandler<GetCustomerByUsernameQuery, GetCustomerByUsernameDTO>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByUsernameHandler(ISportAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCustomerByUsernameDTO> Handle(GetCustomerByUsernameQuery request, CancellationToken cancellationToken)
        {
            GetCustomerByUsernameDTO getCustomerByUsernameDTO = new GetCustomerByUsernameDTO();
            var result = await _context.Customers.Where(x => x.Username == request.InputUsername)
                                        .SingleOrDefaultAsync(cancellationToken);
            getCustomerByUsernameDTO.Customer = result;
            return getCustomerByUsernameDTO;
        }
    }
}
