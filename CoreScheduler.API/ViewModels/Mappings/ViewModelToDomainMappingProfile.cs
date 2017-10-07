using AutoMapper;
using CoreScheduler.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreScheduler.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ScheduleViewModel, Schedule>()
               .ForMember(s => s.Creator, map => map.UseValue(null))
               .ForMember(s => s.Attendees, map => map.UseValue(new List<Attendee>()));

            CreateMap<UserViewModel, User>();
        }
    }
}
