using Mapster;

namespace Business.Models.Base;

public abstract class BaseDto<TDto, TEntity> : IRegister, IBaseDto
{
    public Guid Id { get; set; }
    private TypeAdapterConfig Config { get; set; } = null!;

    public virtual void AddCustomMappings() { }

    protected TypeAdapterSetter<TDto, TEntity> SetCustomMappings() =>
        Config.ForType<TDto, TEntity>();

    protected TypeAdapterSetter<TEntity, TDto> SetCustomMappingsInverse() =>
        Config.ForType<TEntity, TDto>();

    public void Register(TypeAdapterConfig config)
    {
        Config = config;
        AddCustomMappings();
    }
}