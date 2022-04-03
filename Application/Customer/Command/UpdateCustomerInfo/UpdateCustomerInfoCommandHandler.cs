using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customer.Command.UpdateCustomerInfo
{
    public class UpdateCustomerInfoCommandHandler : IRequestHandler<UpdateCustomerInfoCommand, bool>
    {
        private readonly ISportAppDbContext _context;

        public UpdateCustomerInfoCommandHandler(ISportAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateCustomerInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Customer
            {
                Id = request.Customer.Id,
                FirstName = request.Customer.FirstName,
                LastName = request.Customer.LastName,
                Username = request.Customer.Username,
                PhoneNumber = request.Customer.PhoneNumber,
                ModifyAt = DateTime.Now,
            };

            var account = new Domain.Entities.Account
            {
                Id = request.Customer.Account.Id,
                Email = request.Customer.Account.Email,
                Password = request.Customer.Account.Password,
                ModifyAt = DateTime.Now,
            };

            var customer = _context.Customers.First(a => a.Id == request.Customer.Id);
            var accounts = _context.Accounts.First(a => a.Id == request.Customer.Account.Id);

            if (entity != null && account != null)
            {
                customer.FirstName = request.Customer.FirstName;
                customer.LastName = request.Customer.LastName;
                customer.Username = request.Customer.Username;
                customer.PhoneNumber = request.Customer.PhoneNumber;
                accounts.Email = request.Customer.Account.Email;
                accounts.Password = request.Customer.Account.Password;

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            else
                return false;
        }
    }
}
