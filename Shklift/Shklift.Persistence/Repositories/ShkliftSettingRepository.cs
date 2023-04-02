using Shklift.Domain.Entities;
using Shklift.Persistence.Context;
using ShkliftApplication.Repositories;

namespace Shklift.Persistence.Repositories;

public class ShkliftSettingRepository : BaseRepository<ShkliftSetting>, ISettingRepository
{
    public ShkliftSettingRepository(DataContext context) : base(context)
    {
    }
}