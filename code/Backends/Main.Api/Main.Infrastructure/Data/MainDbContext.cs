using Main.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure;
using System.Reflection;

namespace Main.Infrastructure.Data;

public class MainDbContext : BaseDbContext<MainDbContext>, IMainDbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : 
        base(options, auditableEntitySaveChangesInterceptor)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
