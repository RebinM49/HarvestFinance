using HarvestFinance.Domain.Constants;

namespace HarvestFinance.WebApi.DTO.ProjectDto
{
    public record CreateSharedBasedDTo
   (
       Guid FarmerId,
       double Area,
       double Weight,
       ProductType ProductType,
       HarvestType HarvestType,
       string Address,
       string CombineName,
       int ProductUnitPrice,
       double ContractRate
   )
    { }
}
