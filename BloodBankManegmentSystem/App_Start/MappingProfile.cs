using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodBankManegmentSystem.Dtos;
using AutoMapper;
using BloodBankManegmentSystem.Models;

namespace BloodBankManegmentSystem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Donors, DonorsDto>();
            Mapper.CreateMap<Acceptors, AcceptorsDto>();
            Mapper.CreateMap<BloodType, BloodTypeDto>();
            Mapper.CreateMap<DonorsDto, Donors>();
            Mapper.CreateMap<AcceptorsDto, Acceptors>();
            Mapper.CreateMap<GenderDto, Gender>();

            Mapper.CreateMap<GenderDto, Gender>()
                .ForMember(c => c.id, opt => opt.Ignore());
            Mapper.CreateMap<AcceptorsDto, Acceptors>()
              .ForMember(c => c.id, opt => opt.Ignore());
            
        }
    }
}
