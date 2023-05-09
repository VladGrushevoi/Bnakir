namespace KozakBank.Persistence.Common.Utils;

public class CheckOnNullOrDefault
{
    public static bool IsDefaultValue(object value)
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