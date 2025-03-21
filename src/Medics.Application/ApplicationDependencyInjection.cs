using Medics.Application.AutoMapping;
using Medics.Application.OTP_Service;
using Medics.Application.Service;
using Medics.Application.Service.Impl;
using Medics.Shared.Services;
using Medics.Shared.Services.Impl;
using Microsoft.AspNetCore.Hosting;
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
        services.AddScoped<IOtpService, OtpService>();
        services.AddScoped<ICustomEmailSender, EmailSender>();
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