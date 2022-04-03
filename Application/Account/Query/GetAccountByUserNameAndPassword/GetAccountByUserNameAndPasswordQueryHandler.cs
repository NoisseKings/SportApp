using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.Account.Query.GetAccountByUserNameAndPassword
{
    public class GetAccountByUserNameAndPasswordQueryHandler : IRequestHandler<GetAccountByUserNameAndPasswordQuery, GetAccountByUserNameAndPasswordDTO>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountByUserNameAndPasswordQueryHandler(ISportAppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        

        public async Task<GetAccountByUserNameAndPasswordDTO> Handle(GetAccountByUserNameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            GetAccountByUserNameAndPasswordDTO getAccountByUserNameAndPasswordDTO = new GetAccountByUserNameAndPasswordDTO();
            var result = await _context.Customers.Where(x => x.Username == request.UsernameInput)
                                                 .Join(
                                                    _context.Accounts,
                                                    c => c.AccountId,
                                                    a => a.Id,
                                                    (c, a) => new { c.AccountId, a.TokenId,a.Password }
                                                 )
                                                 .Where(a => a.Password == request.PasswordInput)
                                                 .Join(
                                                    _context.Tokens,
                                                    a => a.TokenId,
                                                    t => t.Id,
                                                    (a, t) => new 
                                                    {
                                                        Token = t.Title,
                                                    })
                                                 .SingleOrDefaultAsync(cancellationToken);

            getAccountByUserNameAndPasswordDTO.Token = result.Token;
            return getAccountByUserNameAndPasswordDTO;
        }
    }
}