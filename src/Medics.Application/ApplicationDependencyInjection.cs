using Medics.Application.AuthenticationService;
using Medics.Application.AutoMapping;
using Medics.Application.Common;
using Medics.Application.Service;
using Medics.Application.Service.Impl;
using Medics.Application.Service.OTP_Service;
using Medics.Core.Entities;
using Medics.DataAccess.Data;
using Medics.Shared.Services;
using Medics.Shared.Services.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Medics.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        services.RegisterCashing();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<IAmbulanceService, AmbulanceService>();
        services.AddScoped<IAppointmentPaymentService, AppointmentPaymentService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IDoctorDetailsService, DoctorDetailsService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IGeolocationService, GeolocationService>();
        services.AddScoped<IPersonalCabinetService, PersonalCabinetService>();
        services.AddScoped<IPharmacyDetailsService, PharmacyDetailsService>();
        services.AddScoped<IPharmacyPaymentService, PharmacyPaymentService>();
        services.AddScoped<IPharmacyService, PharmacyService>();

        services.AddScoped<ICustomEmailSender, EmailSender>();
        services.AddScoped<IOtpService, OtpService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddIdentityServices();
        services.AddScoped<RoleManager<ApplicationRole>>();
    }

    private static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<Guid>>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = true;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped<IRoleStore<ApplicationRole>, RoleStore<ApplicationRole, AppDbContext, Guid>>();

        services.AddScoped<UserManager<User>>();
        services.AddScoped<RoleManager<ApplicationRole>>();
        services.AddScoped<SignInManager<User>>();

        return services;
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    private static void RegisterCashing(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }
}