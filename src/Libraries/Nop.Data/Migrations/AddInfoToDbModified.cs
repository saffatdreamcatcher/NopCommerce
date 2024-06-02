using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Nop.Data.Migrations;
[NopSchemaMigration("2024-05-27 01:53:00", "Add Info Modified")]
public class AddInfoToDbModified : Migration
{
    public override void Up()
    {
        //Create.Table("Info")
        //        .WithColumn("Id").AsInt64().PrimaryKey().Identity()
        //        .WithColumn("Image").AsBinary()
        //        .WithColumn("ImageUrl").AsString()
        //        .WithColumn("AlterText").AsString();
    }

    public override void Down()
    {
        Delete.Table("Info");
    }
}
