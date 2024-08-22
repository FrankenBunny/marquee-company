namespace dotnetFullstack.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRentableRepository Rentables { get; }
    IPartRepository Parts { get; }

    Task<bool> CompleteAsync();
}
