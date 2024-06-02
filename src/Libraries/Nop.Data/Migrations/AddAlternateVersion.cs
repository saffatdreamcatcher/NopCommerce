using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Core.Infrastructure;

namespace Nop.Data.Migrations;

[NopSchemaMigration("2024-05-07 00:00:00", "Category. Add alternate version")]
public class AddAlternateVersion : ForwardOnlyMigration
{
    public override void Up()
    {
        var categoryTableName = nameof(Category);
        if (!Schema.Table(categoryTableName).Column(nameof(Category.AlternateVersion)).Exists())
            Alter.Table(categoryTableName)
               .AddColumn(nameof(Category.AlternateVersion)).AsString(255).Nullable();
    }

}
