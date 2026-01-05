using Microsoft.EntityFrameworkCore;

namespace Main.Infrastructure.Data;

public class MainDbContextInitial
{
    private readonly MainDbContext _dbContext;

    public MainDbContextInitial(MainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _dbContext.Database.MigrateAsync();
        }
        catch (Exception ex) { }
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
