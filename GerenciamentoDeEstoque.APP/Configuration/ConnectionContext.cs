using GerenciamentoDeEstoque.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeEstoque.Configuration;

public class ConnectionContext : DbContext
{
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
}