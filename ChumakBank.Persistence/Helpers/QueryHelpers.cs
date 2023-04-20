using System.Text;
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

    public static string GetUpdateQuery<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        var propertiesInfo = entity.GetType().GetProperties();
        var importantProps = propertiesInfo.Where(x => !x.PropertyType.IsGenericType)
            .Where(x => x.Name != "Id")
            .Select(x => $"\"{x.Name}\" = @{x.Name}");
        var queryBuilder = new StringBuilder($"UPDATE public.\"{typeof(TEntity).Name}\" SET ");
        var propMapString = string.Join(", ", importantProps);
        queryBuilder.Append(propMapString).Append($" WHERE \"Id\" = @Id;");

        return queryBuilder.ToString();
    }
}