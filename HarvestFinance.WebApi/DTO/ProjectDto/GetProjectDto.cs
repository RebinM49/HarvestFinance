using HarvestFinance.Domain.Constants;

namespace HarvestFinance.WebApi.DTO.ProjectDto;

public record GetProjectDto(
    Guid Id,
    Guid FarmerId,
    double Weight,
    double Area,
    DateTime Date,
    ProductType Product,
    HarvestType HarvestType,
    long Cost,
    ContractType Contract,
    string Address
    )
{ }
