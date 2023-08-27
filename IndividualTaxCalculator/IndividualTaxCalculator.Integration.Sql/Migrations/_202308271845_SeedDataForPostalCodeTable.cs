using FluentMigrator;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Integration.Sql.DataModels;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308271845)]
public class _202308271845_SeedDataForPostalCodeTable : Migration
{
    public override void Up()
    {
        Insert.IntoTable("PostalCode")
            .Row(new { Code = "7441" })
            .Row(new { Code = "A100" })
            .Row(new { Code = "7000" })
            .Row(new { Code = "1000" });
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}