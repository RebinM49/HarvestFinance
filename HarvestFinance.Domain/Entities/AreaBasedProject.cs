using HarvestFinance.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFinance.Domain.Entities;

public class AreaBasedProject : Project
{
    private int _areaUnitPrice;

    private AreaBasedProject()
    {

    }
    public AreaBasedProject(
        Guid farmerId ,
        double weight ,
        double area ,
        ProductType product ,
        HarvestType harvestingType ,
        string address ,
        string combineName ,
        int UnitPrice
        ) : base( farmerId , weight , area , product , harvestingType , address , combineName )
    {
        AreaUnitPrice = UnitPrice;
        ContractKind = ContractType.AreaBased;
        CalculateCost();
    }

    public int AreaUnitPrice
    {
        get => _areaUnitPrice;
        set
        {
            if (value < 1_000_000)
                throw new ArgumentOutOfRangeException( nameof( AreaUnitPrice )
                    , message: "The value for area unit price is not valid." );
            _areaUnitPrice = value;
        }
    }
    public override long Cost
    {
        get => _cost;
        protected set
        {
            if (value < 10000)
                throw new ArgumentOutOfRangeException( nameof( Cost )
                    , message: "calculated value for cost is invalid due to wrong input" );
            _cost = (long)Area * AreaUnitPrice;
        }
    }

    public override void CalculateCost()
    {

        Cost = (long)(Area * AreaUnitPrice);
    }


}