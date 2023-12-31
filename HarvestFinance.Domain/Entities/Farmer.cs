﻿using HarvestFinance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestFinance.Domain.Entities
{
    public class Farmer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid ProjectId { get; set; }

        // Navigation Properties
        public List<Project> Projects { get; set; }


    }
}
