using HarvestFinance.Domain.Constants;
using HarvestFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class projectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Farmer)
                .WithMany(f => f.Projects)
                .HasForeignKey(p => p.FarmerId);
            builder.HasDiscriminator(h => h.ContractKind)
                .HasValue<AreaBasedProject>(ContractType.AreaBased)
                .HasValue<SharedBasedProject>(ContractType.SharedBased);
        }
    }
}
