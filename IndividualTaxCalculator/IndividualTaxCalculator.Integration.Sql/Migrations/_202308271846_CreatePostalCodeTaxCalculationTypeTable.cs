using FluentMigrator;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308271846)]
public class _202308271846_CreatePostalCodeTaxCalculationTypeTable : Migration
{
    public override void Up()
    {
        Create.Table("PostalCodeTaxCalculationType")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("PostalCodeId").AsInt32().ForeignKey("PostalCode", "Id")
            .WithColumn("TaxCalculationTypeId").AsInt32().ForeignKey("TaxCalculationType", "Id");
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}