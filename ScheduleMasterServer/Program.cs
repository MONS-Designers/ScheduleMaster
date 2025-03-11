using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog.Web;
using Repositories;
using ScheduleMasterServer.Middlewares;
using Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration _configuration;

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ScheduleMasterContext>(options => options.UseNpgsql(connectionString));

builder.Host.UseNLog();

var app = builder.Build();

app.UseCors((service) => service.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseErrorHandlerMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
