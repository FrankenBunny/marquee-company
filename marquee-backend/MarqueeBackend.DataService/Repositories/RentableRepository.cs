using MarqueeBackend.DataService.Data;
using MarqueeBackend.DataService.Repositories.Interfaces;
using MarqueeBackend.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MarqueeBackend.DataService.Repositories;

public class RentableRepository : GenericRepository<Rentable>, IRentableRepository
{
    public RentableRepository(AppDbContext dbContext, ILogger logger)
        : base(dbContext, logger) { }

    public async Task<Rentable?> GetCategoryRentablesAsync(Guid categoryId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.CategoryId == categoryId);
        }
        catch (Exception e)
        {
            _logger.LogError(
                e,
                "{Repo} GetCategoryRentablesAsync function error",
                typeof(CategoryRepository)
            );
            throw;
        }
    }

    public override async Task<IEnumerable<Rentable>> All()
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
            _logger.LogError(e, "{Repo} All function error", typeof(RentableRepository));
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
            _logger.LogError(e, "{Repo} Delete function error", typeof(RentableRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Rentable rentable)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == rentable.Id);
            if (result == null)
                return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.Title = rentable.Title;
            result.Note = rentable.Note;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update function error", typeof(RentableRepository));
            throw;
        }
    }
}
