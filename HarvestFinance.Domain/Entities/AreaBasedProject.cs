using HarvestFinance.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFinance.Domain.Entities;

public class AreaBasedProject : Project
{
    private int _areaUnitPrice;
    public AreaBasedProject() :base()
    {
        Cost = CalculateCost();
        Date = DateTime.Now;
        ContractKind = ContractType.AreaBased;
    }
    public int AreaUnitPrice
    {
        get => _areaUnitPrice;
        set
        {
            if (_areaUnitPrice < 1000_000)
                throw new ArgumentOutOfRangeException(nameof(AreaUnitPrice)
                    , message: "The value for area unit price is not valid.");
            _areaUnitPrice = value;
        }
    }
    public override long Cost
    {
        get => _cost;
        protected set
        {
            if (value < 10000)
                throw new ArgumentOutOfRangeException(nameof(Cost) 
                    ,message:"calculated value for cost is invalid due to wrong input");
            _cost = value;
        }
    }


    public override long CalculateCost()
        => (long)(Area * AreaUnitPrice);

}