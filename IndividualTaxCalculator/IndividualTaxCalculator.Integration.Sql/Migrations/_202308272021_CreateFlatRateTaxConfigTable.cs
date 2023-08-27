using FluentMigrator;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308272021)]
public class _202308272021_CreateFlatRateTaxConfigTable : Migration
{
    public override void Up()
    {
        Create.Table("FlatRateTaxConfig")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("FlatRatePercentage").AsDouble().NotNullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}