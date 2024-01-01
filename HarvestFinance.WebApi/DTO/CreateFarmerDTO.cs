using HarvestFinance.Domain.Entities;

namespace HarvestFinance.WebApi.DTO
{
    public record CreateFarmerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
