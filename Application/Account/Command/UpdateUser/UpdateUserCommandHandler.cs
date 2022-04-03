//using Application.Common.Interfaces;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Account.Command.UpdateUser
//{
//    public class UpdateUserCommandHandler : IRequestHandler<UpdateuserCommand, bool>
//    {
//        private readonly ISportAppDbContext _context;

//        public UpdateUserCommandHandler(ISportAppDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<bool> Handle(UpdateuserCommand request, CancellationToken cancellationToken)
//        {
//            var entity = new Domain.Entities.Account
//            {
//                 = request.User.Customer.FirstName,
//                LastName = request.User.LastName,
//                Email = request.User.Email,
//                UserName = request.User.UserName,
//                Password = request.User.Password,
//                PhoneNumber = request.User.PhoneNumber
//            };

//            var user = _context.Accounts.First(a => a.Id == request.User.Id);

//            if (user != null)
//            {
//                user.FirstName = request.User.FirstName;
//                user.LastName = request.User.LastName;
//                user.UserName = request.User.UserName;
//                user.Email = request.User.Email;
//                user.PhoneNumber = request.User.PhoneNumber;
//                user.Password = request.User.Password;
//                user.DateModify = DateTime.Now;
//                user.Country = request.User.Country;
//                user.City = request.User.City;
//                user.Street = request.User.Street;
//                user.ZipCode = request.User.ZipCode;

//                await _context.SaveChangesAsync(cancellationToken);

//                return true;
//            }
//            else { return false; }
//            return true;
//        }
//    }
//}
