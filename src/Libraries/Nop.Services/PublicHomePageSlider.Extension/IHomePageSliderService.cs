using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Extendion.Homepage;
using Nop.Core;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.PublicHomePageSlider.Extension;
public interface IHomePageSliderService
{
    Task InsertHomepageSlider(HomePageSlider homepageSlider);
    Task DeleteHomepageSlider(HomePageSlider homepageSlider);
    Task DeleteHomepageSlidersAsync(IList<HomePageSlider> homepageSliders);
    Task UpdateHomepageSlider(HomePageSlider homepageSlider);
    Task<HomePageSlider> HomepageSliderId(int Id);
    Task<IList<HomePageSlider>> GetHomepageSliderByIdsAsync(int[] homepageSliderIds);
    Task<IPagedList<HomePageSlider>> GetHomePageSliders(int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

}
