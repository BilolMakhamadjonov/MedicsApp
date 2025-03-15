using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Core.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Balance).HasDefaultValue(0);
            builder.HasMany(u => u.Appointments).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasMany(u => u.Carts).WithOne(c => c.User).HasForeignKey(c => c.UserId);
            builder.HasMany(u => u.Chats).WithOne(c => c.User).HasForeignKey(c => c.UserId);
        }
    }
}
