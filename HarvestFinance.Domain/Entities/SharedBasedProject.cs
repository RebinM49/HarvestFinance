using HarvestFinance.Domain.Constants;

namespace HarvestFinance.Domain.Entities;

public class SharedBasedProject : Project
{

    public int ProductUnitPrice { get; set; }
    private double _contractRate;
    private SharedBasedProject()
    {

    }
    public SharedBasedProject(
        Guid farmerId,
        double weight,
        double area,
        ProductType product,
        HarvestType harvestingType,
        string address,
        string combineName,
        int unitPrice,
        double contractRate
    ) : base(farmerId, weight, area, product, harvestingType, address, combineName)
    {
        ProductUnitPrice = unitPrice;
        ContractRate = contractRate;
        ContractKind = ContractType.AreaBased;
        Cost = CalculateCost();
    }
    public double ContractRate
    {
        get => _contractRate;
        set
        {
            if (value > 0.13 || value < 0)
                throw new ArgumentOutOfRangeException(nameof(ContractRate)
                    , message: "ContractRate should be between 0.13 and zero.");
            _contractRate = value;
        }
    }
    public override long Cost
    {
        get => _cost;
        protected set
        {
            if (value < 10000)
                throw new ArgumentOutOfRangeException(nameof(Cost)
                    , message: "calculated value for cost is invalid due to wrong input");
            _cost = value;
        }
    }

    public override long CalculateCost()
    {
        var result = (long)(Weight * ContractRate * ProductUnitPrice);
        return result;
    }

}
