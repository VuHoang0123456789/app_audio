using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Interfaces;

public interface IAdminContext : IBaseDbContext
{
    public DbSet<test_table> test_table { get; set; }
}
