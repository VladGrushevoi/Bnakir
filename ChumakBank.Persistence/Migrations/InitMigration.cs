using ChumakBank.Domain.Entities;
using FluentMigrator;

namespace ChumakBank.Persistence.Migrations;

[Migration(202304181355)]
public class InitMigration : Migration
{
    public override void Up()
    {
        Create.Table(nameof(ChumakInfo))
            .WithColumn(nameof(ChumakInfo.Id)).AsGuid().NotNullable().PrimaryKey()
            .WithColumn(nameof(ChumakInfo.Balance)).AsFloat().NotNullable()
            .WithColumn(nameof(ChumakInfo.CommissionForOperation)).AsFloat().NotNullable()
            .WithColumn(nameof(ChumakInfo.CreatedAt)).AsDate()
            .WithColumn(nameof(ChumakInfo.UpdatedAt)).AsDate();

        Create.Table(nameof(User))
            .WithColumn(nameof(User.Id)).AsGuid().NotNullable().PrimaryKey()
            .WithColumn(nameof(User.Name)).AsString(50).NotNullable()
            .WithColumn(nameof(User.Surname)).AsString(50).NotNullable()
            .WithColumn(nameof(User.Phone)).AsString(50).NotNullable()
            .WithColumn(nameof(User.Country)).AsString(50).NotNullable()
            .WithColumn(nameof(User.CreatedAt)).AsDate()
            .WithColumn(nameof(User.UpdatedAt)).AsDate();

        Create.Table(nameof(KisaCard))
            .WithColumn(nameof(KisaCard.Id)).AsGuid().NotNullable().PrimaryKey()
            .WithColumn(nameof(KisaCard.CardIdFromSystem)).AsGuid().NotNullable()
            .WithColumn(nameof(KisaCard.Balance)).AsFloat().NotNullable().WithDefaultValue(0)
            .WithColumn(nameof(User) + "Id").AsGuid().NotNullable().ForeignKey(nameof(User), nameof(User.Id))
            .WithColumn(nameof(KisaCard.CreatedAt)).AsDate()
            .WithColumn(nameof(KisaCard.UpdatedAt)).AsDate();
        
        Create.Table(nameof(MapsterCard))
            .WithColumn(nameof(MapsterCard.Id)).AsGuid().NotNullable().PrimaryKey()
            .WithColumn(nameof(MapsterCard.CardIdFromSystem)).AsGuid().NotNullable()
            .WithColumn(nameof(MapsterCard.Balance)).AsFloat().NotNullable().WithDefaultValue(0)
            .WithColumn(nameof(User) + "Id").AsGuid().NotNullable().ForeignKey(nameof(User), nameof(User.Id))
            .WithColumn(nameof(MapsterCard.CreatedAt)).AsDate()
            .WithColumn(nameof(MapsterCard.UpdatedAt)).AsDate();

    }

    public override void Down()
    {
        Delete.Table(nameof(ChumakInfo));
        Delete.Table(nameof(KisaCard));
        Delete.Table(nameof(MapsterCard));
        Delete.Table(nameof(User));
    }
}