namespace MarqueeBackend.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRentableRepository Rentables { get; }
    IPartRepository Parts { get; }
    ICategoryRepository Categories { get; }

    Task<bool> CompleteAsync();
}
