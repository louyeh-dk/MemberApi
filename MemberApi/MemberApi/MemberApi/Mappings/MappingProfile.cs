using AutoMapper;
using MemberApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AutoMapper.Internal.ExpressionFactory;
using MemberApi.DAL.Entities;
using Project = MemberApi.DAL.Entities;
namespace MemberApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project.Member, MemberDtoRead>() 
                .ForMember(dest => dest.Name, source => source.MapFrom(source => source.FirstName + " " + source.MiddelName + " " + source.LastName
                     ));

            CreateMap<Project.Member, MemberDtoWrite>().ReverseMap();

        }
    }
}
