﻿namespace HarvestFinance.WebApi_V2.Models
{
    public class FarmerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set;} = string.Empty;

    }
}
