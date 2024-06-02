using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;
using static LinqToDB.Reflection.Methods.LinqToDB;

namespace Nop.Data.Migrations;
[NopSchemaMigration("2024-05-28 08:08:00", "nevigation column type changed to string")]
public class HomePageSliderModified :Migration
{
    public override void Up()
    {
        Create.Table("HomePageSlider")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("HomepageSliderPictureId").AsInt64()
                .WithColumn("HomepageSliderUrl").AsString()
                .WithColumn("HomepageSliderAlt").AsString()
                .WithColumn("HomepageSliderTitle").AsString()
                .WithColumn("HomepageSliderNavigationUrl").AsString()
                .WithColumn("HomepageSliderDisplayOrder").AsInt64()
                .WithColumn("HomepageSliderVisibility").AsBoolean();
                 
    }

    public override void Down()
    {
        Delete.Table("HomePageSlider");
    }
}
