using HarvestFinance.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace HarvestFinance.WebApi_V2.Models;

public class ShareBaseProjectForCreationDto
{
    [Required]
    [Range( 0 , 4 )]
    public ProductType ProductType { get; set; }
    [Required]
    [Range( 0 , 1 )]
    public HarvestType HarvestType { get; set; }
    [Required]
    [Range(10_000,200_000)]
    public int UnitPrice { get; set; }
    [Required]
    [Range(0.02,0.12)]
    public double contractRate { get; set; }
    [Required]
    public double Weight { get; set; }
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public string CombineName { get; set; } = string.Empty;
    public double Area { get; set; }

}
