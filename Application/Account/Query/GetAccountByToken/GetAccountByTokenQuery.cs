using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Query.GetAccountByToken
{
    public class GetAccountByTokenQuery : IRequest<GetAccountByTokenDTO>
    {
        public string Token { get; set; }
    }
}
