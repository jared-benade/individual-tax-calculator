using FluentMigrator;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Integration.Sql.DataModels;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308271843)]
public class _202308271843_SeedDataForTaxCalculationTypeTable : Migration
{
    public override void Up()
    {
        Insert.IntoTable("TaxCalculationType")
            .Row(new { TypeId = (int)TaxCalculationType.Progressive, Description = "Progressive" })
            .Row(new { TypeId = (int)TaxCalculationType.FlatValue, Description = "Flat Value" })
            .Row(new { TypeId = (int)TaxCalculationType.FlatRate, Description = "Flat Rate"});
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}