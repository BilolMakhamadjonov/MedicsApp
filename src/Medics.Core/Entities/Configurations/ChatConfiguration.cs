using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Core.Entities.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasOne(c => c.User)
                   .WithMany(u => u.Chats)
                   .HasForeignKey(c => c.UserId);

            builder.HasOne(c => c.Doctor)
                   .WithMany(d => d.Chats)
                   .HasForeignKey(c => c.DoctorId);

            builder.Property(c => c.Message).IsRequired().HasMaxLength(500);
        }
    }
}
