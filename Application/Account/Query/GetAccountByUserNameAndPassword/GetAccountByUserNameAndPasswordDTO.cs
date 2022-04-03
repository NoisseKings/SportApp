using Application.Common.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using AutoMapper;

namespace Application.Account.Query.GetAccountByUserNameAndPassword
{
    public class GetAccountByUserNameAndPasswordDTO
    {
        public string Token { get; set; }
    }
}
