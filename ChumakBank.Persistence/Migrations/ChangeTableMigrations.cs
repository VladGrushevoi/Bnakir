using ChumakBank.Domain.Entities;
using FluentMigrator;

namespace ChumakBank.Persistence.Migrations;

[Migration(202305011053)]
public sealed class ChangeTableMigrations : Migration
{
    public override void Up()
    {
        Alter.Table(nameof(ChumakInfo))
            .AddColumn(nameof(ChumakInfo.BankIdentifier))
            .AsString(4)
            .Nullable();
    }

    public override void Down()
    {
        Delete.Table(nameof(ChumakInfo));
    }
}