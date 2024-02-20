using HarvestFinance.Domain.Constants;

namespace HarvestFinance.WebApi_V2.Models
{
    public class ProjectForCreationDto
    {

        public double Weight { get; set; }
        public double Area { get; set; }
        public ProductType ProductType { get; set; }
        public HarvestType HarvestType { get; set; }
        public string Address { get; set; } = string.Empty;
        public string CombineName { get; set; } = string.Empty;
        public ContractType ContractKind { get; set; }
    }
}
