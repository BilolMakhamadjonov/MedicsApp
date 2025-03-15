using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Core.Entities.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(a => a.Reason).IsRequired().HasMaxLength(500);
            builder.HasOne(a => a.User).WithMany(u => u.Appointments).HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Doctor).WithMany(d => d.Appointments).HasForeignKey(a => a.DoctorId);
            builder.HasOne(a => a.Payment).WithOne(p => p.Appointment).HasForeignKey<AppointmentPayment>(p => p.AppointmentId);
        }
    }
}
