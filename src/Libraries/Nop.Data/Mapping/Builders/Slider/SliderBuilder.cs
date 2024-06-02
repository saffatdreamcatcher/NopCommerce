using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Slide;

namespace Nop.Data.Mapping.Builders.Slider;
public partial class SliderBuilder : NopEntityBuilder<Info>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(Info.Image)).AsString(1000).Nullable()
            .WithColumn(nameof(Info.ImageUrl)).AsString(1000).Nullable()
            .WithColumn(nameof(Info.AlterText)).AsString(1000).Nullable();
    }
}
