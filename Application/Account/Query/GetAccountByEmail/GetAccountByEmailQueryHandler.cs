using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Query.GetAccountByEmail
{
    public class GetAccountByEmailQueryHandler : IRequestHandler<GetAccountByEmailQuery, GetAccountByEmailDTO>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountByEmailQueryHandler(ISportAppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetAccountByEmailDTO> Handle(GetAccountByEmailQuery request, CancellationToken cancellationToken)
        {
            GetAccountByEmailDTO getAccountByEmailDTO = new GetAccountByEmailDTO();

            var result = await _context.Accounts.Where(x => x.Email == request.EmailInput)
                                         .SingleOrDefaultAsync(cancellationToken);
            if (result.Email != "")
            {
                getAccountByEmailDTO.CheckEmail = true;

                Email email = new Email()
                {
                    From = request.EmailInput,
                    Body = "Youre code is 123",
                    Subject = "SportsApp change password.",
                    To = "aleksandartornjanski72@gmail.com"

                };
                email.SendSmtpMail(email);

            }
            else
            {
                getAccountByEmailDTO.CheckEmail = false;
            }

            return getAccountByEmailDTO;

        }
    }
}
