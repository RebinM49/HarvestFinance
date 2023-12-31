using HarvestFinance.Domain.Common;
using HarvestFinance.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFinance.Domain.Entities
{
    public abstract class Project : Entity
    {
        public Guid FarmerId { get; set; }
        public double Weight { get; set; }
        public double Area { get; set; }
        public DateTime DateTime { get; set; }
        public ProductType ProductType { get; set; }
        public HarvestType HarvestType { get; set; }
        protected long _cost;
        public abstract long Cost { get; protected set; }
        public abstract long CalculateCost(); 

        

        // Navigation Properties
        public Farmer Farmer { get; set; }

    }
}
