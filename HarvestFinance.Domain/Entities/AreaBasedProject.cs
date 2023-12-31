using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFinance.Domain.Entities;

public class AreaBasedProject : Project
{
    public int AreaUnitPrice { get; set; }
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
    public AreaBasedProject()
    {
        Cost = CalculateCost();
    }

    public override long CalculateCost()
        => (long)(Area * AreaUnitPrice);

}