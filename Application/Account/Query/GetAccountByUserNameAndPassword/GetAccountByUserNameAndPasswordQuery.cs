using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Query.GetAccountByUserNameAndPassword
{
    public class GetAccountByUserNameAndPasswordQuery : IRequest<GetAccountByUserNameAndPasswordDTO>
    {
        public string UsernameInput { get; set; }
        public string PasswordInput { get; set; }
    }
}
