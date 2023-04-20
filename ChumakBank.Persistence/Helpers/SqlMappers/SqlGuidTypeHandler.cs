using System.Data;
using Dapper;

namespace ChumakBank.Persistence.Helpers.SqlMappers;

public sealed class SqlGuidTypeHandler : SqlMapper.TypeHandler<Guid>
{
    public override void SetValue(IDbDataParameter parameter, Guid value)
    {
        parameter.Value = value.ToString();
    }

    public override Guid Parse(object value)
    {
        return new Guid(value.ToString());
    }
}