﻿using AutoMapper;
using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Models;
using HarvestFinance.WebApi_V2.Models;

namespace HarvestFinance.WebApi_V2.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<SharedBasedProject , ProjectDto>();
            CreateMap<AreaBasedProject , ProjectDto>();
            CreateMap<Project , FullInfoProjectDto>();
            CreateMap<CustomProjectDto , FullInfoProjectDto>();
            CreateMap<AreaBasedProject , AreaBaseForPatchDto>()
                .ReverseMap().ForMember( patch => patch.AreaUnitPrice ,
                options => options.MapFrom( area => area.UnitPrice )
                );

        }
    }
}
