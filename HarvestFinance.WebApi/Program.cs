using DataAccess;
using DataAccess.Repositories;
using HarvestFinance.Domain;
using HarvestFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(config);
builder.Services.AddDbContext<DbContext,HarvestFinanceDbcontext>(
    op => op.UseSqlServer(
        builder.Configuration.GetConnectionString("HarvestFinance_I")
        ));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFarmerRepository , FarmerRepository>();
builder.Services.AddScoped<IProjectRepository , ProjectRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
