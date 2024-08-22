using dotnetFullstack.DataService.Data;
using dotnetFullstack.DataService.Repositories.Interfaces;
using dotnetFullstack.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dotnetFullstack.DataService.Repositories;

public class PartRepository : GenericRepository<Part>, IPartRepository
{
    public PartRepository(AppDbContext dbContext, ILogger logger)
        : base(dbContext, logger) { }

    public async Task<Part?> GetRentablePartAsync(Guid rentableId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.RentableId == rentableId);
        }
        catch (Exception e)
        {
            _logger.LogError(
                e,
                "{Repo} GetRentablePartAsync function error",
                typeof(RentableRepository)
            );
            throw;
        }
    }

    public override async Task<IEnumerable<Part>> All()
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
            _logger.LogError(e, "{Repo} All function error", typeof(PartRepository));
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
            _logger.LogError(e, "{Repo} Delete function error", typeof(PartRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Part part)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == part.Id);
            if (result == null)
                return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.Title = part.Title;
            result.Note = part.Note;
            result.RentableId = part.RentableId;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update function error", typeof(PartRepository));
            throw;
        }
    }
}
