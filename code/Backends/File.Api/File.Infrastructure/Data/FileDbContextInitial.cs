using Microsoft.EntityFrameworkCore;

namespace File.Infrastructure.Data;

public class FileDbContextInitial
{
    private readonly FileDbContext _fileDbContext;

    public FileDbContextInitial(FileDbContext fileDbContext)
    {
        _fileDbContext = fileDbContext;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _fileDbContext.Database.MigrateAsync();
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
