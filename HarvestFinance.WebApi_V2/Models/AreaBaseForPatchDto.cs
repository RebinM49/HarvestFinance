using HarvestFinance.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace HarvestFinance.WebApi_V2.Models;

public class AreaBaseForPatchDto
{
    [Required]
    [Range( 0 , 4 )]
    public ProductType ProductType { get; set; }
    [Required]
    [Range( 0 , 1 )]
    public HarvestType HarvestType { get; set; }
    [Required]
    [Range( 1_500_000 , 50_000_000 )]
    public int UnitPrice { get; set; }
    [Required]
    [Range( 0.2 , 100 )]
    public double Area { get; set; }
}
