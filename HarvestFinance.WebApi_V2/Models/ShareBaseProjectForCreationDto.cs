using HarvestFinance.Domain.Constants;

namespace HarvestFinance.WebApi_V2.Models
{
    public class ShareBaseProjectForCreationDto
    {
        public ProductType ProductType { get; set; }
        public HarvestType HarvestType { get; set; }
        public int UnitPrice { get; set; }
        public double contractRate { get; set; }
        public double Weight { get; set; }
        public string Address { get; set; } = string.Empty;
        public string CombineName { get; set; } = string.Empty;
        public double Area { get; set; }

    }
}
