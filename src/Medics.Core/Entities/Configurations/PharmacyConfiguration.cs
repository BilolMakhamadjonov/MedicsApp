using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Core.Entities.Configurations
{
    public class PharmacyConfiguration : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
        {
            builder.Property(p => p.DrugName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
