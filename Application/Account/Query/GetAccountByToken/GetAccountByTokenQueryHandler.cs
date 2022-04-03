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

namespace Application.Account.Query.GetAccountByToken
{
    public class GetAccountByTokenQueryHandler : IRequestHandler<GetAccountByTokenQuery, GetAccountByTokenDTO>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountByTokenQueryHandler(ISportAppDbContext context,
           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAccountByTokenDTO> Handle(GetAccountByTokenQuery request, CancellationToken cancellationToken)
        {
            GetAccountByTokenDTO getAccountByTokenDTO = new GetAccountByTokenDTO();
            var getToken = await _context.Tokens.Where(t => t.Title == request.Token)
                                        .SingleOrDefaultAsync(cancellationToken);
            if(getToken != null)
            {
                var getAccountByToken = await _context.Accounts.Where(a => a.TokenId == getToken.Id).SingleOrDefaultAsync(cancellationToken);

                getAccountByTokenDTO.Account = getAccountByToken;
            }
            return getAccountByTokenDTO;

        }
    }
}
