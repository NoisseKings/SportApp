//using Application.Common.Mapper;
//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.CourtAccount.Query
//{
//    public class GetCourtAccountByUserNameAndPasswordDTO : IMapFor<Domain.Entities.Court>
//    {

//        public int Id { get; set; }
//        public int AdressId { get; set; }
//        public string Name { get; set; }
//        public string Email { get; set; }
//        public string Password { get; set; }
//        public DateTime DateOfCreation { get; set; }
//        public string WorkingHours { get; set; }
//        public string PriceForHour { get; set; }
//        //public string FirstName { get; set; }
//        //public string LastName { get; set; }
//        public DateTime CreatedAt { get; set; }
//        public DateTime DateModify { get; set; }

//        //public void Mapping(Profile profile)
//        //{
//        //    profile.CreateMap<Domain.Entities.Court, GetCourtAccountByUserNameAndPasswordDTO>()
//        //        .ForMember(d => d.Id, opts => opts.MapFrom(s => s.Id))
//        //        .ForMember(d => d.WorkingHours, opts => opts.MapFrom(s => s.WorkingHours))
//        //        .ForMember(d => d.AdressId, opts => opts.MapFrom(s => s.AdressId))
//        //        .ForMember(d => d.PriceForHour, opts => opts.MapFrom(s => s.PriceForHour))
//        //        .ForMember(d => d.WorkingHours, opts => opts.MapFrom(s => s.WorkingHours))
//        //        .ForMember(d => d.Email, opts => opts.MapFrom(s => s.Email))
//        //        .ForMember(d => d.Name, opts => opts.MapFrom(s => s.Name))
//        //        .ForMember(d => d.Password, opts => opts.MapFrom(s => s.Password));
//        //}
//    }
//}
