using Medics.DataAccess.Data;
using Medics.Shared.Services.Impl;
using Medics.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Medics.DataAccess;
using Medics.Application.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();

builder.Services.AddDataAccess(builder.Configuration)
   .AddApplication(builder.Environment);


var app = builder.Build();

using var scope = app.Services.CreateScope();
await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
