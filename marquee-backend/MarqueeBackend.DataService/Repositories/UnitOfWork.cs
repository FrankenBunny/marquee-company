using MarqueeBackend.DataService.Data;
using MarqueeBackend.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace MarqueeBackend.DataService.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;
    public IRentableRepository Rentables { get; }
    public IPartRepository Parts { get; }
    public ICategoryRepository Categories { get; }

    public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");

        Rentables = new RentableRepository(_context, logger);
        Parts = new PartRepository(_context, logger);
        Categories = new CategoryRepository(_context, logger);
    }

    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
