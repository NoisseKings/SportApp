using Application.Common.Mapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Query.GetAccountByToken
{
    public class GetAccountByTokenDTO 
    {
        public Domain.Entities.Account Account { get; set; }

    }
}
