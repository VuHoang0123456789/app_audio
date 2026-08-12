using Log.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure;
using System.Reflection;

namespace Log.Infrastructure.Data;

public class LogDbContext : BaseDbContext<LogDbContext>, ILogDbContext
{
    public LogDbContext(DbContextOptions<LogDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options, auditableEntitySaveChangesInterceptor)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
