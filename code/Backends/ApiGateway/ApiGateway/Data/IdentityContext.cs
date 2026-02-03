using ApiGateway.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiGateway.Data;

public class IdentityContext : DbContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {

    }

    public DbSet<Client> clients { get; set; }
    public DbSet<ClientSecret> ClientSecret { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
