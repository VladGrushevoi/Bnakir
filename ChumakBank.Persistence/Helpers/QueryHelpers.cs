using ChumakBank.Domain.Common;

namespace ChumakBank.Persistence.Helpers;

public static class QueryHelpers
{
    public static string InstanceFieldToString<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        var propertiesInfo = entity.GetType().GetProperties();
        var importantProps = propertiesInfo.Where(x => !x.PropertyType.IsGenericType)  
            .Select(x => "\"" + x.Name + "\"");
        string fields = string.Join(", ", importantProps);
        return fields;
    }

    public static string InstanceFieldToValueString<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        var fieldsInfo = entity.GetType().GetProperties();
        var fieldStringFormat = fieldsInfo.Where(x => !x.PropertyType.IsGenericType)
            .Select(s => "@" + s.Name);
        var fieldsParameters = string.Join(", ", fieldStringFormat);

        return fieldsParameters;
    }
    
    
}