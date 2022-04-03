using Application.Common.Mapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dashboard.Query.GetCourtById
{
    public class GetCourtByIdDTO : IMapFor<Domain.Entities.Court>
    {
        public int Id { get; set; }
        //public int AdressId { get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string WorkingHours { get; set; }
        public string PriceForHour { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateModify { get; set; }
        public string PhoneNumber { get; set; }

        public int AccountId { get; set; }
        public Domain.Entities.Account Account { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Court, GetCourtByIdDTO>()
                .ForMember(d => d.Id, opts => opts.MapFrom(s => s.Id))
                .ForMember(d => d.WorkingHours, opts => opts.MapFrom(s => s.WorkingHours))
                .ForMember(d => d.Account, opts => opts.MapFrom(s => s.Account))
                //.ForMember(d => d.AdressId, opts => opts.MapFrom(s => s.AdressId))
                .ForMember(d => d.PriceForHour, opts => opts.MapFrom(s => s.PriceForHour))
                .ForMember(d => d.WorkingHours, opts => opts.MapFrom(s => s.WorkingHours))
                //.ForMember(d => d.Email, opts => opts.MapFrom(s => s.Account.Email))
                .ForMember(d => d.Name, opts => opts.MapFrom(s => s.Name));
        }
    }
}
