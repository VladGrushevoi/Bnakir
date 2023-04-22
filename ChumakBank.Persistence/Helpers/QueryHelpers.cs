using System.Reflection;
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

    public static string GetDeleteQuery<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        var queryBuilder = new StringBuilder($"DELETE FROM public.\"{typeof(TEntity).Name}\" WHERE ");
        var propsWithData = GetPropertiesWithoutDefaultValue(entity)
                                                .Select(x => $"\"{x.Name}\" = @{x.Name}");
        queryBuilder.Append(string.Join(", ", propsWithData));
        return queryBuilder.ToString();
    }

    public static IEnumerable<PropertyInfo> GetPropertiesWithoutDefaultValue<TEntity>(TEntity entity) where TEntity : class
    {
        var props = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => !IsDefaultValue(x.GetValue(entity)));
        return props;
    }

    private static bool IsDefaultValue(object value)
    {
        return value == null || (value.GetType().IsValueType && value.Equals(GetDefault(value.GetType())));
    }
    
    static object GetDefault(Type type)
    {
        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }
        return null;
    }
}