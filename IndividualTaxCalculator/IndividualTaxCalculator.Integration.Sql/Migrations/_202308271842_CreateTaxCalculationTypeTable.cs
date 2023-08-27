using FluentMigrator;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308271842)]
public class _202308271842_CreateTaxCalculationTypeTable : Migration
{
    public override void Up()
    {
        Create.Table("TaxCalculationType")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("TypeId").AsInt32().NotNullable()
            .WithColumn("Description").AsString().NotNullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}