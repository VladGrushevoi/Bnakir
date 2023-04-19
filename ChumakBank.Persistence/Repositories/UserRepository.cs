using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using ChumakBank.Persistence.Context;

namespace ChumakBank.Persistence.Repositories;

public sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}