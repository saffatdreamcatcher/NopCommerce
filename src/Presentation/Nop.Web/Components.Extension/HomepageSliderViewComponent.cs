using Microsoft.AspNetCore.Mvc;
using Nop.Core.Caching;
using Nop.Services.PublicHomePageSlider.Extension;
using Nop.Web.Areas.Admin.Models.Extension.HomePageSliderPublicModel;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components.Extension;

[ViewComponent(Name = "HomepageSliderViewComponent")]
public class HomepageSliderViewComponent : NopViewComponent
{
    private readonly string cacheKeyHomepageSlider = "Nop.homepages.custom.sliderquery";
    private readonly IStaticCacheManager _cacheManager;
    private readonly IHomePageSliderService _homepageSliderService;
    public HomepageSliderViewComponent(IStaticCacheManager cacheManager, IHomePageSliderService homepageSliderService)
    {
        _cacheManager = cacheManager;
        _homepageSliderService = homepageSliderService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HomePageSliderPublicModel homepageSliderModel = new HomePageSliderPublicModel();
        var model = await _cacheManager.GetAsync(new CacheKey(cacheKeyHomepageSlider), async () =>
        {
            var homepageSliders = await _homepageSliderService.GetHomePageSliders(showHidden: false, pageSize: 10);
            foreach (var homepageSlider in homepageSliders)
            {
                homepageSliderModel.homepageSliderLeftImageModels.Add(new HomepageSliderImageModel
                {
                    Id = homepageSlider.Id,
                    ImageUrl = homepageSlider.HomepageSliderUrl,
                    ImageAlt = homepageSlider.HomepageSliderAlt,
                    ImageTitle = homepageSlider.HomepageSliderTitle,
                    NavigationUrl = homepageSlider.HomepageSliderNavigationUrl
                });
            }
            return homepageSliderModel;
        });



        return View("~/Themes/SimplexTheme/Views/Shared/Components/HomepageSlider/Default.cshtml", model);
    }
    }
