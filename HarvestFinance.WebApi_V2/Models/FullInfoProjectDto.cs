using HarvestFinance.Domain.Constants;

namespace HarvestFinance.WebApi_V2.Models
{
    public class FullInfoProjectDto
    {
        public Guid Id { get; set; }
        public Guid FarmerId { get; set; }
        public string farmerInfo { get; set; } = string.Empty;
        public DateTime Date { get; protected set; }
        public string ProductType { get; set; } = string.Empty;
        public string HarvestType { get; set; } = string.Empty;
        public string ContractKind { get; set; } = string.Empty;
        public long Cost { get; set; }
        public string Address { get; set; } = string.Empty;
        public string CombineName { get; set; } = string.Empty;
        public double Weight { get; set; }
        public double Area { get; set; }
    }
}
