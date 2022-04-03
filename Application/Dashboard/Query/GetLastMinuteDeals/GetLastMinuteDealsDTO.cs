using Application.Common.Mapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dashboard.Query.GetLastMinuteDeals
{
    public class GetLastMinuteDealsDTO : IMapFor<Domain.Entities.Court>
    {
        //public List<Domain.Entities.Court> Courts { get; set; }
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string WorkingHours { get; set; }
        public string PriceForHour { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateModify { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Court, GetLastMinuteDealsDTO>()
                .ForMember(d => d.Id, opts => opts.MapFrom(s => s.Id))
                .ForMember(d => d.AccountId, opts => opts.MapFrom(s => s.AccountId))
                .ForMember(d => d.CreatedAt, opts => opts.MapFrom(s => s.CreateAt))
                .ForMember(d => d.DateOfCreation, opts => opts.MapFrom(s => s.DateOfCreation))
                .ForMember(d => d.DateModify, opts => opts.MapFrom(s => s.DateOfCreation));
        }
    }
}
