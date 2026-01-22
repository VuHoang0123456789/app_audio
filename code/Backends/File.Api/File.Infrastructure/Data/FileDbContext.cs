using File.Application.Interfaces;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure;
using System.Reflection;

namespace File.Infrastructure.Data;

public class FileDbContext : BaseDbContext<FileDbContext>, IFileDbContext
{
    public FileDbContext(DbContextOptions<FileDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options, auditableEntitySaveChangesInterceptor)
    {
    }

    public DbSet<test_table> test_Tables { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
