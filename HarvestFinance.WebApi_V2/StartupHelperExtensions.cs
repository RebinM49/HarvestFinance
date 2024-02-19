using DataAccess;
using DataAccess.Repositories;
using HarvestFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HarvestFinance.WebApi;

internal static class StartupHelperExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSingleton<IConfiguration>(config);
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddDbContext<DbContext, HarvestFinanceDbcontext>(
        op => op.UseSqlServer(
            builder.Configuration.GetConnectionString("HarvestFinance_I")
        ));

        builder.Services.AddScoped<IFarmerRepository, FarmerRepository>();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("OOPs , SomeThing bad just happened !");
                });
            });
        }

        app.MapControllers();
        return app;
    }

}
