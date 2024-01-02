using HarvestFinance.Domain.Constants;

namespace HarvestFinance.Domain.Entities;

public class SharedBasedProject : Project
{

    public int ProductUnitPrice { get; set; }
    private double _contractRate;
    public SharedBasedProject()
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
        int UnitPrice
    ) : base(farmerId, weight, area, product, harvestingType, address, combineName)
    {
        ProductUnitPrice = UnitPrice;
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
            if (value > 10000)
                _cost = value;
            throw new ArgumentOutOfRangeException();
        }
    }

    public override long CalculateCost()
        => (long)(Weight * ContractRate * ProductUnitPrice);

}
