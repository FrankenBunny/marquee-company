using MarqueeBackend.Entities.DbSet;

namespace MarqueeBackend.DataService.Repositories.Interfaces;

public interface IRentableRepository : IGenericRepository<Rentable>
{
    Task<Rentable?> GetCategoryRentablesAsync(Guid categoryId);
}
