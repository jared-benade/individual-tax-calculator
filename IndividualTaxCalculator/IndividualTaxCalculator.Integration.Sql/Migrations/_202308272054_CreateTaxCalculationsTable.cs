using FluentMigrator;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308272054)]
public class _202308272054_CreateTaxCalculationsTable : Migration
{
    public override void Up()
    {
        Create.Table("TaxCalculations")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("AnnualIncome").AsDecimal().NotNullable()
            .WithColumn("PostalCode").AsString(20).NotNullable()
            .WithColumn("TaxAmount").AsDecimal().NotNullable()
            .WithColumn("DateCreated").AsDateTime().NotNullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}