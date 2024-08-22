using dotnetFullstack.Entities.DbSet;

namespace dotnetFullstack.DataService.Repositories.Interfaces;

public interface IPartRepository : IGenericRepository<Part>
{
    Task<Part?> GetRentablePartAsync(Guid rentableId);
}
