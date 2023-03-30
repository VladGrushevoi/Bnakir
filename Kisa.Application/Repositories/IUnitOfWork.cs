namespace Kisa.Application.Repositories;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cls);
}