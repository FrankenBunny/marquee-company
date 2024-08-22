using MarqueeBackend.Entities.DbSet;

namespace MarqueeBackend.DataService.Repositories.Interfaces;

public interface IPartRepository : IGenericRepository<Part>
{
    Task<Part?> GetRentablePartAsync(Guid rentableId);
}
