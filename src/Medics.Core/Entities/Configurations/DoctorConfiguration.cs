using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Core.Entities.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasOne(d => d.DoctorCategory)
                   .WithMany(dc => dc.Doctors)
                   .HasForeignKey(d => d.DoctorCategoryId);

            builder.HasOne(d => d.User)
                   .WithMany()
                   .HasForeignKey(d => d.UserId);

            builder.HasMany(d => d.Appointments)
                   .WithOne(a => a.Doctor)
                   .HasForeignKey(a => a.DoctorId);

            builder.HasMany(d => d.Chats)
                   .WithOne(c => c.Doctor)
                   .HasForeignKey(c => c.DoctorId);
        }
    }
}
