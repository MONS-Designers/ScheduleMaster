using Microsoft.EntityFrameworkCore;
using Repositories;
using ScheduleMasterServer.Middlewares;
using Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration _configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ScheduleMasterContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.UseErrorHandlerMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
