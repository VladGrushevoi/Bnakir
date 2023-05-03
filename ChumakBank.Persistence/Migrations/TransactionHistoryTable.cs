using ChumakBank.Domain.Entities;
using FluentMigrator;

namespace ChumakBank.Persistence.Migrations;

[Migration(202305031447)]
public class TransactionHistoryTable : Migration
{
    public override void Up()
    {
        Create.Table(nameof(TransactionHistory))
            .WithColumn(nameof(TransactionHistory.Id)).AsGuid().NotNullable().PrimaryKey()
            .WithColumn(nameof(TransactionHistory.FromCardId)).AsGuid().NotNullable()
            ;
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}