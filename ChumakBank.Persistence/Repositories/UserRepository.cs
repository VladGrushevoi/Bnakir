using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Persistence.Repositories;

public sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    
}