using ChumakBank.Domain.Entities;
using ChumakBank.Persistence.Helpers;

namespace ChumakBank.Test.QueryHelpersTests;

public class QueryHelpersTests
{
    [Fact]
    public void InstanceFieldToString__QueryHelper()
    {
        var entity = new User()
        {
            Country = "Ukraine",
            Name = "Jorge",
            Surname = "hui",
            Phone = "1111122222",
            CreatedAt = new DateOnly(2023,04,19),
            UpdatedAt = default,
            
        };

        var resultString = QueryHelpers.InstanceFieldToString(entity);
        
        Assert.NotNull(resultString);
        Assert.NotEqual(0, resultString.Length);
    }
    
    [Fact]
    public void InstanceFieldToStringParameters__QueryHelper()
    {
        var entity = new User()
        {
            Country = "Ukraine",
            Name = "Jorge",
            Surname = "hui",
            Phone = "1111122222",
            CreatedAt = new DateOnly(2023,04,19),
            UpdatedAt = default,
            
        };

        var resultString = QueryHelpers.InstanceFieldToValueString(entity);
        
        Assert.NotNull(resultString);
        Assert.NotEqual(0, resultString.Length);
    }
    
    [Fact]
    public void BuildingUpdateQueryTest__QueryHelper()
    {
        var entity = new User()
        {
            Country = "Ukraine",
            Name = "Jorge",
            Surname = "hui",
            Phone = "1111122222",
            CreatedAt = new DateOnly(2023,04,19),
            UpdatedAt = default,
            
        };

        var resultString = QueryHelpers.GetUpdateQuery(entity);
        
        Assert.NotNull(resultString);
        Assert.NotEqual(0, resultString.Length);
    }
}