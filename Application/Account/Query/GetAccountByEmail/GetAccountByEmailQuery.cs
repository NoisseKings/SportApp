using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Query.GetAccountByEmail
{
    public class GetAccountByEmailQuery : IRequest<GetAccountByEmailDTO>
    {
        public string EmailInput { get; set; }
    }
}
