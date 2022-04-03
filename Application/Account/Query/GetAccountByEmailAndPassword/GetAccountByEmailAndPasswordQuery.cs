﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Query.GetAccountByEmailAndPassword
{
    public class GetAccountByEmailAndPasswordQuery : IRequest<GetAccountByEmailAndPasswordDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
