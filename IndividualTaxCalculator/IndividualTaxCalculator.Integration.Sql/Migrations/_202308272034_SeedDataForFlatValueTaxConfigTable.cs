using FluentMigrator;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Integration.Sql.DataModels;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308272034)]
public class _202308272034_SeedDataForFlatValueTaxConfigTable : Migration
{
    public override void Up()
    {
        Insert.IntoTable("FlatValueTaxConfig")
            .Row(new { FlatValueAmount = 10000, AnnualThresholdAmount = 200000, TaxPercentage = 5 });
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}