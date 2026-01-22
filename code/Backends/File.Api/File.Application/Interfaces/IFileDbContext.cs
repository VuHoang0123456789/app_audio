using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Interfaces;

namespace File.Application.Interfaces;

public interface IFileDbContext : IBaseDbContext
{
    public DbSet<test_table> test_Tables { get; set; }
}
