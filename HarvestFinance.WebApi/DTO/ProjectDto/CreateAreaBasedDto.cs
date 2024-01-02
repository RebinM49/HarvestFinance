using HarvestFinance.Domain.Constants;

namespace HarvestFinance.WebApi.DTO.ProjectDto
{
    public record CreateAreaBasedDto
    (
        Guid FarmerId,
        double Area,
        ProductType ProductType,
        HarvestType HarvestType,
        string Address,
        string CombineName,
        int AreaUnitPrice

    )
    { }
}
