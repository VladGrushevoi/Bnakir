using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Common;
using ChumakBank.Persistence.Context;
using ChumakBank.Persistence.Helpers;
using Dapper;

namespace ChumakBank.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }
    public Task<TEntity> GetAsync(Guid Id, CancellationToken cls)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cls)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cls)
    {
        var fieldsString = QueryHelpers.InstanceFieldToString(entity);
        var valueString = QueryHelpers.InstanceFieldToValueString(entity);
        string tableName = $"\"{typeof(TEntity).Name}\"";
        entity.Id = Guid.NewGuid();
        entity.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        
        var query = $"INSERT INTO public.{tableName} ({fieldsString}) VALUES({valueString});";

        await _context.Connection.ExecuteAsync(query, entity, transaction: _context.DbTransaction);
        
        return entity;
    }

    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cls)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cls)
    {
        throw new NotImplementedException();
    }
}