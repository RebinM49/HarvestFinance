using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFinance.Domain.Models;
public class CustomProjectDto
{
    public Guid Id { get; set; }
    public Guid FarmerId { get; set; }
    public string FarmerInfo { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string ProductType { get; set; } = string.Empty;
    public string HarvestType { get; set; } = string.Empty;
    public string ContractKind { get; set; } = string.Empty;
    public long Cost { get; set; } 
    public string Address { get; set; } = string.Empty;
    public string CombineName { get; set; } = string.Empty;
    public double Weight { get; set; } 
    public double Area { get; set; } 
}
