using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Core.Entities.Configurations
{
    public class VideoCallConfiguration : IEntityTypeConfiguration<VideoCall>
    {
        public void Configure(EntityTypeBuilder<VideoCall> builder)
        {
            builder.HasOne(vc => vc.User)
                   .WithMany()
                   .HasForeignKey(vc => vc.UserId);

            builder.HasOne(vc => vc.Doctor)
                   .WithMany()
                   .HasForeignKey(vc => vc.DoctorId);
        }
    }
}
