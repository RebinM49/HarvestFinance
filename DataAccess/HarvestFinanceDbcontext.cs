using DataAccess.Configuration;
using HarvestFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;


namespace DataAccess;

public class HarvestFinanceDbcontext : DbContext
{
    public IConfiguration Configuration { get; } = null;
    public HarvestFinanceDbcontext(DbContextOptions options, IConfiguration config)
        : base(options) 
    { 
        Configuration = config;
    }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("HarvestFinance_I")); 
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(projectConfiguration).Assembly);  
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<Project> Projects { get; set; }
}
