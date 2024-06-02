using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Nop.Data.Migrations;

[NopSchemaMigration("2024-05-28 05:13:00", "Add Info to newly added NopDb")]
public class AddHomePageSliderToDb : Migration
{
    
    public override void Up()
    {
    //    Create.Table("HomePageSlider")
    //            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
    //            .WithColumn("HomepageSliderPictureId").AsInt64()
    //            .WithColumn("HomepageSliderUrl").AsString()
    //            .WithColumn("HomepageSliderAlt").AsString()
    //            .WithColumn("HomepageSliderTitle").AsString()
    //            .WithColumn("HomepageSliderNavigationUrl").AsBoolean()
    //            .WithColumn("HomepageSliderDisplayOrder").AsInt64();

    }

    public override void Down()
    {
        Delete.Table("HomePageSlider");
    }
}
