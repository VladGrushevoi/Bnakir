using Mapster;

namespace ShkliftApplication.Common;

public abstract class BaseDto<TDto, TEntity> : IRegister 
    where TDto : class 
    where TEntity : class
{
    private TypeAdapterConfig _config { get; set; }

    public TEntity ToEntity()
    {
        return this.Adapt<TEntity>();
    }

    public TEntity ToEntity(TEntity entity)
    {
        return (this as TDto).Adapt(entity);
    }

    public static TDto FromEntity(TEntity entity)
    {
        return entity.Adapt<TDto>();
    }
    
    public virtual void AddCustomMappings(){ }

    protected TypeAdapterSetter<TDto, TEntity> SetCustomMappings()
        => _config.ForType<TDto, TEntity>();

    protected TypeAdapterSetter<TEntity, TDto> SetCustomMappingsReverse()
        => _config.ForType<TEntity, TDto>();

    public void Register(TypeAdapterConfig config)
    {
        _config = config;
        AddCustomMappings();
    }
}