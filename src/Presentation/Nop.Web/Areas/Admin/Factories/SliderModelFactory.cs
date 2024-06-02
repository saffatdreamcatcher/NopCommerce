using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Polls;
using Nop.Core.Domain.Slide;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Polls;
using Nop.Services.Slide;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Localization;
using Nop.Web.Areas.Admin.Models.Polls;
using Nop.Web.Areas.Admin.Models.Slider;
using Nop.Web.Framework.Extensions;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories;

public partial class SliderModelFactory : ISliderModelFactory
{
    protected readonly IBaseAdminModelFactory _baseAdminModelFactory;
    protected readonly IDateTimeHelper _dateTimeHelper;
    protected readonly ILanguageService _languageService;
    protected readonly IInfoService _infoService;
    protected readonly IStoreMappingSupportedModelFactory _storeMappingSupportedModelFactory;


    public SliderModelFactory(IBaseAdminModelFactory baseAdminModelFactory,
        IDateTimeHelper dateTimeHelper,
        ILanguageService languageService,
        IInfoService infoService,
        IStoreMappingSupportedModelFactory storeMappingSupportedModelFactory)
    {
        _baseAdminModelFactory = baseAdminModelFactory;
        _dateTimeHelper = dateTimeHelper;
        _languageService = languageService;
        _infoService = infoService;
        _storeMappingSupportedModelFactory = storeMappingSupportedModelFactory;
       

    }

    public virtual Task<InfoSearchModel> PrepareInfoSearchModelAsync(InfoSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(searchModel);

        //prepare page parameters
        searchModel.SetGridPageSize();

        return Task.FromResult(searchModel);


    }

    public virtual async Task<InfoSummaryListModel> PrepareInfoSummaryListModelAsync(InfoSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(searchModel);

        
        //get infos
        var infos = (await _infoService.GetAllInfosAsync(showHidden: true)).ToPagedList(searchModel);

        //prepare list model
        var model = new InfoSummaryListModel().PrepareToGrid(searchModel, infos, () =>
        {
            return infos.Select(info =>
            {
                //fill in model values from the entity
                var infoModel = info.ToModel<InfoSummaryModel>();
                return infoModel;
            });

        });

        return model;

    }

    public virtual async Task<InfoSummaryModel> PrepareInfoSummaryModelAsync(InfoSummaryModel model, Info info, bool excludeProperties = false)
    {
        if (info != null)
        {
            //fill in model values from the entity
            model ??= info.ToModel<InfoSummaryModel>();

        }

        return model;
    }

}
