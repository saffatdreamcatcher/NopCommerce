using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Caching;
using Nop.Core.Domain.Extendion.Homepage;
using Nop.Core;
using Nop.Data;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.PublicHomePageSlider.Extension;

public class HomepageSliderService : IHomePageSliderService
{
    private readonly IRepository<HomePageSlider> _homepageSlider;
    private readonly IStaticCacheManager _staticCacheManager;

    public HomepageSliderService(IRepository<HomePageSlider> homepageSlider, IStaticCacheManager staticCacheManager)
    {
        _homepageSlider = homepageSlider;
        _staticCacheManager = staticCacheManager;
    }
    public async Task DeleteHomepageSlider(HomePageSlider homepageSlider)
    {
        await _homepageSlider.DeleteAsync(homepageSlider);
        await _staticCacheManager.RemoveAsync(new CacheKey("Nop.homepages.custom.sliderquery"));
    }

    public virtual async Task DeleteHomepageSlidersAsync(IList<HomePageSlider> homepageSliders)
    {
        if (homepageSliders == null)
            throw new ArgumentNullException(nameof(homepageSliders));

        foreach (var homepageSlider in homepageSliders)
            await _homepageSlider.DeleteAsync(homepageSlider);
    }
    public async Task<IPagedList<HomePageSlider>> GetHomePageSliders(int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
    {
        var query = await _homepageSlider.GetAllAsync(query =>
        {
            if (!showHidden)
                query = query.Where(p => p.HomepageSliderVisibility);

            query = query.OrderByDescending(x => x.Id);
            return query;
        });
        /*, cache => _staticCacheManager.PrepareKeyForDefaultCache(new CacheKey("Nop.homepages.custom.sliderquery")));*/


        return new PagedList<HomePageSlider>(query, pageIndex, pageSize);

    }

    public async Task<HomePageSlider> HomepageSliderId(int Id)
    {
        return await _homepageSlider.GetByIdAsync(Id);
    }

    public virtual async Task<IList<HomePageSlider>> GetHomepageSliderByIdsAsync(int[] homepageSliderIds)
    {
        return await _homepageSlider.GetByIdsAsync(homepageSliderIds, includeDeleted: false);
    }
    public async Task InsertHomepageSlider(HomePageSlider homepageSlider)
    {
        await _homepageSlider.InsertAsync(homepageSlider);
        await _staticCacheManager.RemoveAsync(new CacheKey("Nop.homepages.custom.sliderquery"));

    }

    public async Task UpdateHomepageSlider(HomePageSlider homepageSlider)
    {
        await _homepageSlider.UpdateAsync(homepageSlider);
        await _staticCacheManager.RemoveAsync(new CacheKey("Nop.homepages.custom.sliderquery"));


    }
}