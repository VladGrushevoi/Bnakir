using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;

namespace KozakBank.Persistence.Repositories;

public sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DataContext.DataContext context) : base(context)
    {
    }
}