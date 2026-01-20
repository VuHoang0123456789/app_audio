using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Infrastructure.Data;

public class AdminContextInitial
{
    private readonly AdminContext _adminContext;

    public AdminContextInitial(AdminContext adminContext)
    {
        _adminContext = adminContext;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _adminContext.Database.MigrateAsync();
        }
        catch (Exception ex) { 
        }
    }

    public async Task SeedAsync()
    {
        try
        {

        }
        catch (Exception ex)
        {
        }
    }
}
