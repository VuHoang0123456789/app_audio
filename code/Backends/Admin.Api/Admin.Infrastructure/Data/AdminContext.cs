using Admin.Domain;
using Admin.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure;
using System.Reflection;
namespace Admin.Infrastructure.Data;

public class AdminContext : BaseDbContext<AdminContext>, IAdminContext
{
    public AdminContext(DbContextOptions<AdminContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) 
        : base(options, auditableEntitySaveChangesInterceptor)
    {

    }

    #region dbset
    public DbSet<test_table> test_table { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
