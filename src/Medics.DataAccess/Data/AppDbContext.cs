using Medics.Core.Comman;
using Medics.Core.Entities;
using Medics.DataAccess.Identity;
using Medics.Shared.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Medics.DataAccess.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    private IClaimService? _claimService;
    public AppDbContext(DbContextOptions<AppDbContext> options, IClaimService claimService) : base(options)
    {
        _claimService = claimService;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    

    public DbSet<Ambulance> Ambulances { get; set; }
    public DbSet<AppointmentPayment> Appointments { get; set; }
    public DbSet<AppointmentPayment> AppointmentPayments { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorCategory> DoctorCategories { get; set; }
    public DbSet<DoctorDetails> DoctorDetails { get; set; }
    public DbSet<Geolocation> Geolocations { get; set; }
    public DbSet<PersonalCabinet> PersonalCabinets { get; set; }
    public DbSet<Pharmacy> Pharmacies { get; set; }
    public DbSet<PharmacyDetails> PharmacyDetails { get; set; }
    public DbSet<PharmacyPayment> PharmacyPayments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<VideoCall> VideoCalls { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        if (_claimService != null)
        {
            foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _claimService.GetUserId();
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _claimService.GetUserId();
                        entry.Entity.UpdatedOn = DateTime.Now;
                        break;
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
