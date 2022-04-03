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

namespace Application.Account.Query.GetAccountByEmailAndPassword
{
    public class GetAccountByEmailAndPasswordHandler : IRequestHandler<GetAccountByEmailAndPasswordQuery, GetAccountByEmailAndPasswordDTO>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountByEmailAndPasswordHandler(ISportAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetAccountByEmailAndPasswordDTO> Handle(GetAccountByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            GetAccountByEmailAndPasswordDTO getAccountByEmailAndPasswordDTO = new GetAccountByEmailAndPasswordDTO();

            var result = await this._context.Accounts.Where(a => a.Email == request.Email && a.Password == request.Password)
                                                .Join(_context.Courts,a => a.Id, c => c.AccountId, (a,c) => new { a.TokenId, c.AccountId })
                                                .Join(_context.Tokens,a => a.TokenId, t => t.Id, (a, t) => new
                                                {
                                                    Token = t.Title,
                                                }).SingleOrDefaultAsync(cancellationToken);
            getAccountByEmailAndPasswordDTO.Token = result.Token;

            return getAccountByEmailAndPasswordDTO;
        }
    }
}
