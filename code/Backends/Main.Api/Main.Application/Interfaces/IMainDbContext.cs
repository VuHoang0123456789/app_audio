using Main.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Interfaces;

namespace Main.Application.Interfaces;

public interface IMainDbContext : IBaseDbContext
{
    public DbSet<test_table> test_table { get; set; }
}
