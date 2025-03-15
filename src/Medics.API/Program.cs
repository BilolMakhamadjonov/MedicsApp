using Medics.DataAccess.Data;
using Medics.Shared.Services.Impl;
using Medics.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Medics.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Servislarni ro‘yxatdan o‘tkazamiz
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration); // DI chaqirish

var app = builder.Build();

// Database migratsiyasini bajarish
await app.Services.MigrateDatabaseAsync();

// Middleware konfiguratsiyasi
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

