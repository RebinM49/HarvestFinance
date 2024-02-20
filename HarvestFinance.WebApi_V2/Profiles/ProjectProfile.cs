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
            CreateMap<SharedBasedProject, ProjectDto>();
            CreateMap<AreaBasedProject, ProjectDto>();
            CreateMap<Project, FullInfoProjectDto>();
            CreateMap<ProjectForCreationDto , AreaBasedProject>();
            CreateMap<ProjectForCreationDto , SharedBasedProject>();
            CreateMap<CustomProjectDto,FullInfoProjectDto>();

        }
    }
}
