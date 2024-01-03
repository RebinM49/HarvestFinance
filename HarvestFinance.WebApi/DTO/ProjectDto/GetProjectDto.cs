using HarvestFinance.Domain.Constants;

namespace HarvestFinance.WebApi.DTO.ProjectDto;

public record GetProjectDto(
    Guid Id,
    Guid FarmerId,
    double Weight,
    double Area,
    DateTime Date,
    string Product,
    string HarvestType,
    long Cost,
    string Contract,
    string Address,
    string CombineName
    )
{ }
