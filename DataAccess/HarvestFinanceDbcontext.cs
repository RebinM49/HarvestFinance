using HarvestFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;


namespace DataAccess;

public class HarvestFinanceDbcontext : DbContext
{
    public IConfiguration Configuration { get; }
    public HarvestFinanceDbcontext(DbContextOptions options,IConfiguration config) 
        : base(options)
    {
        Configuration = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("HarvestFinance_I")); 
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<Project> Projects { get; set; }
}
