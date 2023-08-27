using FluentMigrator;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Integration.Sql.DataModels;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308272023)]
public class _202308272023_SeedDataForFlatRateTaxConfigTable : Migration
{
    public override void Up()
    {
        Insert.IntoTable("FlatRateTaxConfig")
            .Row(new { FlatRatePercentage = 17.5 });
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}