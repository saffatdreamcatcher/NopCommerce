using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Slide;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Areas.Admin.Models.Slider;

namespace Nop.Web.Areas.Admin.Factories;

public partial interface ISliderModelFactory
{
    Task<InfoSearchModel> PrepareInfoSearchModelAsync(InfoSearchModel searchModel);

    Task<InfoSummaryListModel> PrepareInfoSummaryListModelAsync(InfoSearchModel searchModel);

    Task<InfoSummaryModel> PrepareInfoSummaryModelAsync(InfoSummaryModel model, Info info, bool excludeProperties = false);


}
