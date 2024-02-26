using HarvestFinance.Domain.Common;
using HarvestFinance.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFinance.Domain.Entities;

public abstract class Project : Entity
{
    protected Project() { }
    public Project(
        Guid farmerId,
        double weight,
        double area,
        ProductType product,
        HarvestType harvestingType,
        string address,
        string combineName

        )
    {
        Id = Guid.NewGuid();
        FarmerId = farmerId;
        Weight = weight;
        Area = area;
        Date = DateTime.Now;
        ProductType = product;
        HarvestType = harvestingType;
        Address = address;
        CombineName = combineName;

    }
    public Guid FarmerId { get; set; }
    public double Weight { get; set; }
    public double Area { get; set; }
    public DateTime Date { get; protected set; }
    public ProductType ProductType { get; set; }
    public HarvestType HarvestType { get; set; }
    protected long _cost;
    public abstract long Cost { get; protected set; }
    public abstract void CalculateCost();
    public string Address { get; set; }
    public string CombineName { get; set; }
    public ContractType ContractKind { get; set; }



    // Navigation Properties
    public Farmer Farmer { get; set; }

}
