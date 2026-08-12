using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Log.Infrastructure.Data;

public class LogDbConextInitial
{
    private readonly LogDbContext _context;
    
    public LogDbConextInitial(LogDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        await _context.Database.MigrateAsync();
    }
}
