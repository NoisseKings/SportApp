//using Application.Common.Interfaces;
//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.CourtAccount.Query
//{
//    public class GetCourtAccountByUserNameAndPasswordQueryHandler : IRequestHandler<GetCourtAccountByUserNameAndPasswordQuery, GetCourtAccountByUserNameAndPasswordDTO>
//    {
//        private readonly ISportAppDbContext _context;
//        private readonly IMapper _mapper;

//        public GetCourtAccountByUserNameAndPasswordQueryHandler(ISportAppDbContext context,
//            IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<GetCourtAccountByUserNameAndPasswordDTO> Handle(GetCourtAccountByUserNameAndPasswordQuery request, CancellationToken cancellationToken)
//        {
//            GetCourtAccountByUserNameAndPasswordDTO result = new GetCourtAccountByUserNameAndPasswordDTO();
//            //GetCourtAccountByUserNameAndPasswordDTO result = await _context.Courts
//            //                            .Where(a => (a.Name == request.NameInput || a.Email == request.EmailInput)
//            //                                    && a.Password == request.PasswordInput)
//            //                            .ProjectTo<GetCourtAccountByUserNameAndPasswordDTO>(_mapper.ConfigurationProvider)
//            //                            .SingleOrDefaultAsync(cancellationToken);
//            return result;
//        }
//    }
//}
