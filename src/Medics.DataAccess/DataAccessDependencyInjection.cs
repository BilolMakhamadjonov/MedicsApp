using Medics.DataAccess.Data;
using Medics.DataAccess.Identity;
using Medics.DataAccess.Repositories.Impl;
using Medics.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Medics.Shared.Services.Impl;
using Medics.Shared.Services;

namespace Medics.DataAccess;

public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity();
        services.AddRepositories();
        services.AddSignalR();
        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {   
        services.AddScoped<IPharmacyRepository, PharmacyRepository>();
        services.AddScoped<IAmbulanceRepository, AmbulanceRepository>();
        services.AddScoped<IAppointmentPaymentRepo, AppointmentPaymentRepo>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IDoctorCategoryRepository, DoctorCategoryRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IDoctorDetailsRepository, DoctorDetailsRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IGeolocationRepository, GeolocationRepository>();
        services.AddScoped<IPersonalCabinetRepository, PersonalCabinetRepository>();
        services.AddScoped<IPharmacyDetailsRepository,PharmacyDetailsRepository>();
        services.AddScoped<IPharmacyPaymentRepository, PharmacyPaymentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IClaimService, ClaimService>();
    }


    private static void AddIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AppDbContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });
    }
}

