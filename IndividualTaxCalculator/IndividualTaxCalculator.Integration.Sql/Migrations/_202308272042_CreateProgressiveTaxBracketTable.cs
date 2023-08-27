using FluentMigrator;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308272042)]
public class _202308272042_CreateProgressiveTaxBracketTable : Migration
{
    public override void Up()
    {
        Create.Table("ProgressiveTaxBrackets")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("TaxPercentage").AsDouble().NotNullable()
            .WithColumn("LowerBound").AsDecimal().NotNullable()
            .WithColumn("UpperBound").AsDouble().Nullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}