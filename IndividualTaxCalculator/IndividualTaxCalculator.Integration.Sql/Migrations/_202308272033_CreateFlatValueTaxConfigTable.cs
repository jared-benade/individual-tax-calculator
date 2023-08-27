using FluentMigrator;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308272033)]
public class _202308272033_CreateFlatValueTaxConfigTable : Migration
{
    public override void Up()
    {
        Create.Table("FlatValueTaxConfig")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("FlatValueAmount").AsDecimal().NotNullable()
            .WithColumn("AnnualThresholdAmount").AsDecimal().NotNullable()
            .WithColumn("TaxPercentage").AsDouble().NotNullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}