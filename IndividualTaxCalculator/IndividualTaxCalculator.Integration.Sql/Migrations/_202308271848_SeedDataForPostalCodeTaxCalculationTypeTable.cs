using FluentMigrator;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Integration.Sql.DataModels;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308271848)]
public class _202308271848_SeedDataForPostalCodeTaxCalculationTypeTable : Migration
{
    public override void Up()
    {
        Insert.IntoTable("PostalCodeTaxCalculationType")
            .Row(new { PostalCodeId = 1, TaxCalculationTypeId = 1 })
            .Row(new { PostalCodeId = 2, TaxCalculationTypeId = 2 })
            .Row(new { PostalCodeId = 3, TaxCalculationTypeId = 3 })
            .Row(new { PostalCodeId = 4, TaxCalculationTypeId = 1 });
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}