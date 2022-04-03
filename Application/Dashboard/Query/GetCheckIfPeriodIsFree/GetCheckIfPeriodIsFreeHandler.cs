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

namespace Application.Dashboard.Query.GetCheckIfPeriodIsFree
{
    public class GetCheckIfPeriodIsFreeHandler : IRequestHandler<GetCheckIfPeriodIsFreeQuery, bool>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCheckIfPeriodIsFreeHandler(ISportAppDbContext context,
           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(GetCheckIfPeriodIsFreeQuery request, CancellationToken cancellationToken)
        {
            
            
            var result = await this._context.Reservations.Where(r => r.StartDate == request.Reservation.StartDate && r.EndDate == request.Reservation.EndDate).SingleOrDefaultAsync(cancellationToken);
            if(result != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
