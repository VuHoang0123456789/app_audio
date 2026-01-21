using File.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure;
using System.Reflection;

namespace File.Infrastructure.Data;

public class FileDbContext : BaseDbContext<FileDbContext>, IFileDbContext
{
    public FileDbContext(DbContextOptions<FileDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options, auditableEntitySaveChangesInterceptor)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
