using AutoMapper;
using HarvestFinance.Domain.Entities;
using HarvestFinance.Domain.Models;
using HarvestFinance.WebApi_V2.Models;

namespace HarvestFinance.WebApi_V2.Profiles
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<AreaBasedProject, FullInfoProjectDto>();
            CreateMap<AreaBasedProject, FullInfoProjectDto>();
            CreateMap<Project, FullInfoProjectDto>();
            CreateMap<CustomProjectDto,FullInfoProjectDto>();

        }
    }
}
