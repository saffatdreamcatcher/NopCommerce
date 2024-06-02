using Nop.Core.Caching;
using Nop.Core.Domain.Extendion.Homepage;
using Nop.Services.Media;
using Nop.Services.PublicHomePageSlider.Extension;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Extension.HomePageSliderAdmin;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories.Extension;

public class HomePageSliderFactory :IHomePageSliderFactory
{
    private readonly IHomePageSliderService _homepageSliderService;
    private readonly IStaticCacheManager _cacheManager;
    private readonly IPictureService _pictureService;


    public HomePageSliderFactory(IHomePageSliderService homepageSliderService, IStaticCacheManager cacheManager, IPictureService pictureService)
    {
        _homepageSliderService = homepageSliderService;
        _cacheManager = cacheManager;
        _pictureService = pictureService;
    }
    public async Task<HomepageSliderListModel> PrepareHomepageSliderListModel(HomepageSliderSearchModel searchModel)
    {
        if (searchModel == null)
            throw new ArgumentNullException(nameof(searchModel));

        //get manufacturers
        var homepageSliders = await _homepageSliderService.GetHomePageSliders(showHidden: true,
            pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);



        var model = await new HomepageSliderListModel().PrepareToGridAsync(searchModel, homepageSliders, () =>
        {
            var slidermodel = homepageSliders.SelectAwait(async homepageslider =>
            {
                var imgUrl = await _pictureService.GetPictureUrlAsync(homepageslider.HomepageSliderPictureId, 200);
                HomepageSliderModel homepageSliderMode = new HomepageSliderModel();
                var homepagesliderModel = homepageslider.ToModel(homepageSliderMode);
                homepageSliderMode.HomepageSliderUrl = imgUrl;
                return homepagesliderModel;
            });
            return slidermodel;
        });

        return model;
    }
    public async Task InsertHomepageSlider(HomepageSliderModel homepageSliderModel)
    {
        var domain = homepageSliderModel.ToEntity<HomePageSlider>();
        await _homepageSliderService.InsertHomepageSlider(domain);
    }

    public async Task UpdateHomepageSlider(HomepageSliderModel homepageSliderModel)
    {
        var domainUpdate = homepageSliderModel.ToEntity<HomePageSlider>();
        var imgUrl = await _pictureService.GetPictureUrlAsync(homepageSliderModel.HomepageSliderPictureId);
        domainUpdate.HomepageSliderUrl = imgUrl;
        await _homepageSliderService.UpdateHomepageSlider(domainUpdate);
    }

    public async Task<HomepageSliderModel> GetHomepageSliderById(int Id)
    {
        var sliderDomain = await _homepageSliderService.HomepageSliderId(Id);
        var homepageSliderModel = sliderDomain.ToModel<HomepageSliderModel>();

        return homepageSliderModel;
    }

}

