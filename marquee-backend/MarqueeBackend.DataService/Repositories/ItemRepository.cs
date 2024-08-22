using MarqueeBackend.DataService.Data;
using MarqueeBackend.DataService.Repositories.Interfaces;
using MarqueeBackend.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MarqueeBackend.DataService.Repositories;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    public ItemRepository(AppDbContext dbContext, ILogger logger)
        : base(dbContext, logger) { }

    public override async Task<IEnumerable<Item>> All()
    {
        try
        {
            return await _dbSet
                .Where(x => x.Status == 1)
                .AsNoTracking()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} All function error", typeof(ItemRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return false;

            result.Status = 0;
            result.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(ItemRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Item item)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (result == null)
                return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.Title = item.Title;
            result.Note = item.Note;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update function error", typeof(ItemRepository));
            throw;
        }
    }
}
