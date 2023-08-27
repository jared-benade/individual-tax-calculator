using FluentMigrator;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Integration.Sql.DataModels;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308272043)]
public class _202308272043_SeedDataForProgressiveTaxBracketsTable : Migration
{
    public override void Up()
    {
        Insert.IntoTable("ProgressiveTaxBrackets")
            .Row(new { TaxPercentage = 10, LowerBound = 0, UpperBound = 8350 })
            .Row(new { TaxPercentage = 15, LowerBound = 8351, UpperBound = 33950 })
            .Row(new { TaxPercentage = 25, LowerBound = 33951, UpperBound = 82250 })
            .Row(new { TaxPercentage = 28, LowerBound = 82251, UpperBound = 171550 })
            .Row(new { TaxPercentage = 33, LowerBound = 171551, UpperBound = 372950 })
            .Row(new { TaxPercentage = 35, LowerBound = 372951 });
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}