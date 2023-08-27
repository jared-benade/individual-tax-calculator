using FluentMigrator;

namespace IndividualTaxCalculator.Integration.Sql.Migrations;

[Migration(202308271844)]
public class _202308271844_CreatePostalCodeTable : Migration
{
    public override void Up()
    {
        Create.Table("PostalCode")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Code").AsString(20).NotNullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}