using AutoMapper;
using HarvestFinance.Domain.Entities;
using HarvestFinance.WebApi_V2.Models;

namespace HarvestFinance.WebApi_V2.Profiles
{
    public class FarmerProfile: Profile
    {
        public FarmerProfile()
        {
            CreateMap<Farmer, FarmerDto>()
                .ForMember(dest => dest.Name,
                option => option.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<FarmerForCreationDto, Farmer>();
            CreateMap<FarmerForPatchDto, Farmer>().ReverseMap();
                
        }
    }
}
